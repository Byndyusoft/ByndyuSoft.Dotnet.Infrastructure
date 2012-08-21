using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web.Routing;
using ByndyuSoft.Infrastructure.Web.Properties;

namespace ByndyuSoft.Infrastructure.Web.Mvc.Paging
{
    internal class Pager
    {
        private static readonly string pagesCaption = string.Format("{0}:",LocalizedStrings.Pages);
        private static readonly string totalItemCountCaption = LocalizedStrings.Found;
        private readonly int currentPage;
        private readonly RouteValueDictionary linkWithoutPageValuesDictionary;
        private readonly RequestContext requestContext;
        private readonly int totalItemCount;
        private int pagesCount;

        public Pager(RequestContext requestContext, RouteValueDictionary valuesDictionary, PageInfo pageInfo)
        {
            this.requestContext = requestContext;

            linkWithoutPageValuesDictionary = valuesDictionary;
            linkWithoutPageValuesDictionary.Remove("page");

            currentPage = pageInfo.Number;
            totalItemCount = pageInfo.TotalItemsCount;
            pagesCount = pageInfo.PagesCount;
        }

        public string RenderHtml()
        {
            if (pagesCount == 0)
            {
                pagesCount = 1;
            }
            const int nrOfPagesToDisplay = 10;

            var list = new List<string>();

            // Previous
            if (currentPage > 1)
            {
                list.Add(GeneratePageLink("&lt;", currentPage - 1));
            }
            else
            {
                list.Add("<span class=\"disabled\">&lt;</span>");
            }

            int start = 1;
            int end = pagesCount;

            if (pagesCount > nrOfPagesToDisplay)
            {
                int middle = (int)Math.Ceiling(nrOfPagesToDisplay / 2d) - 1;
                int below = (currentPage - middle);
                int above = (currentPage + middle);

                if (below < 4)
                {
                    above = nrOfPagesToDisplay;
                    below = 1;
                }
                else if (above > (pagesCount - 4))
                {
                    above = pagesCount;
                    below = (pagesCount - nrOfPagesToDisplay);
                }

                start = below;
                end = above;
            }

            if (start > 3)
            {
                list.Add(GeneratePageLink("1", 1));
                list.Add(GeneratePageLink("2", 2));
                list.Add("...");
            }
            for (int i = start; i <= end; i++)
            {
                if (i == currentPage)
                {
                    list.Add("<span class=\"current\">" + i + "</span>");
                }
                else
                {
                    list.Add(GeneratePageLink(i.ToString(), i));
                }
            }
            if (end < (pagesCount - 3))
            {
                list.Add("...");
                list.Add(GeneratePageLink((pagesCount - 1).ToString(), pagesCount - 1));
                list.Add(GeneratePageLink(pagesCount.ToString(), pagesCount));
            }

            // Next
			if (currentPage < pagesCount)
            {
                list.Add(GeneratePageLink("&gt;", (currentPage + 1)));
            }
            else
            {
                list.Add("<span class=\"disabled\">&gt;</span>");
            }

            string pages = string.Join(" | ", list);

            return string.Format("{2}&nbsp;<strong>{3}</strong>.&nbsp;&nbsp;&nbsp;{0}&nbsp;{1}", pagesCaption, pages, totalItemCountCaption, totalItemCount);
        }

        private string GeneratePageLink(string linkText, int pageNumber)
        {
            const string page = "page";

            var pageLinkValueDictionary = new RouteValueDictionary(linkWithoutPageValuesDictionary);
            pageLinkValueDictionary[page] = pageNumber;

            NameValueCollection contextQueryString = requestContext.HttpContext.Request.QueryString;
            foreach (string queryStrings in contextQueryString)
            {
                if (queryStrings.Equals(page, StringComparison.OrdinalIgnoreCase) ||
                    pageLinkValueDictionary.ContainsKey(queryStrings))
                    continue;

                pageLinkValueDictionary.Add(queryStrings, contextQueryString[queryStrings]);
            }

            VirtualPathData virtualPathData = RouteTable.Routes.GetVirtualPath(requestContext, pageLinkValueDictionary);

            if (virtualPathData == null)
                return null;

            return string.Format("<a href=\"{0}\" data-page=\"{1}\">{2}</a>",
                                 virtualPathData.VirtualPath,
                                 pageNumber,
                                 linkText);
        }
    }
}