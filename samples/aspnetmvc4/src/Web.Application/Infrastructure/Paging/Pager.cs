namespace Mvc4Sample.Web.Application.Infrastructure.Paging
{
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Threading;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;
    using ByndyuSoft.Infrastructure.Web.Mvc.Paging;

    internal class Pager
    {
        private const int PagesDeviation = 4;
        private const int PagingLength = 9;
        private readonly PageInfo _pageInfo;
        private readonly HttpRequestBase _request;
        private readonly RequestContext _requestContext;
        private readonly IEnumerable<string> _queryKeysForCut;

        private bool _isRtl = Thread.CurrentThread.CurrentCulture.TextInfo.IsRightToLeft;

        private string _restQueryPart;
        private string _virtualPath;

        public Pager(RequestContext requestContext, PageInfo pageInfo, IEnumerable<string> queryKeysForCut)
        {
            _requestContext = requestContext;
            _request = _requestContext.HttpContext.Request;
            _pageInfo = pageInfo;
            _queryKeysForCut = queryKeysForCut;
        }

        public void Initialize()
        {
            _virtualPath = _request.Path;
            _restQueryPart = GetQueryPartWithoutPage(_request.QueryString);
        }

        private string GetQueryPartWithoutPage(NameValueCollection query)
        {
            Dictionary<string, string> queryValues = query
                .AllKeys
                .ToDictionary(key => key.ToLower(),
                              key => query.Get(key).ToLower());

            foreach (var keyForCut in _queryKeysForCut)
            {
                queryValues.Remove(keyForCut);
            }

            queryValues.Remove("page");

            return string.Join("", queryValues.Select(x => string.Format("&{0}={1}", x.Key, x.Value)));
        }

        public MvcHtmlString RenderHtml()
        {
            if (IfNoItems())
                return new MvcHtmlString(string.Empty);

            if (NoItemsOnThatPage())
                return new MvcHtmlString(string.Empty);

            if (OnlyOnePage())
                return new MvcHtmlString(string.Empty);

            TagBuilder mainContainer = GetMainContainer();

            FillPagination(mainContainer);

            return new MvcHtmlString(mainContainer.ToString());
        }

        private bool OnlyOnePage()
        {
            return _pageInfo.TotalItemsCount <= _pageInfo.PageSize;
        }

        private void FillPagination(TagBuilder mainContainer)
        {
            var div = new TagBuilder("div");
            div.AddCssClass("btn-group");

            FillLeftArrow(div);

            FillPages(div);

            FillRightArrow(div);

            mainContainer.InnerHtml += div;
        }

        private void FillLeftArrow(TagBuilder ul)
        {
            if (ItIsNotFirstPage())
            {
                ul.InnerHtml += GetTag(_pageInfo.Number - 1, GetLeftArrow())
                    .ToString();
            }
        }

        private string GetLeftArrow()
        {
            return _isRtl ? "&rarr;" : "&larr;";
        }

        private void FillPages(TagBuilder ul)
        {
            int firstPage = _pageInfo.Number - PagesDeviation <= 1
                                ? 1
                                : _pageInfo.Number - PagesDeviation;

            int lastPageNumber = firstPage + PagingLength > _pageInfo.PagesCount
                                     ? _pageInfo.PagesCount + 1
                                     : firstPage + PagingLength;

            if (lastPageNumber - PagingLength + 1 > 1)
                firstPage = lastPageNumber - PagingLength;

            for (int i = firstPage; i < lastPageNumber; i++)
            {
                TagBuilder currentTag = GetTag(i, i.ToString());

                if (ItIsCurrentPage(i))
                    MarkAsCurrentPage(currentTag);

                ul.InnerHtml += currentTag.ToString();
            }
        }

        private void FillRightArrow(TagBuilder ul)
        {
            if (ItIsNotLastPage())
            {
                ul.InnerHtml += GetTag(_pageInfo.Number + 1, GetRightArrow())
                    .ToString();
            }
        }

        private string GetRightArrow()
        {
            return _isRtl ? "&larr;" : "&rarr;";
        }

        private bool IfNoItems()
        {
            return _pageInfo.TotalItemsCount == 0;
        }

        private bool NoItemsOnThatPage()
        {
            return _pageInfo.Index * _pageInfo.PageSize >= _pageInfo.TotalItemsCount;
        }

        private static void MarkAsCurrentPage(TagBuilder tag)
        {
            tag.AddCssClass("active");
        }

        private bool ItIsCurrentPage(int i)
        {
            return _pageInfo.Number == i;
        }

        private static TagBuilder GetMainContainer()
        {
            var section = new TagBuilder("section");
            section.AddCssClass("pagination");
            return section;
        }

        private bool ItIsNotLastPage()
        {
            return _pageInfo.Index != _pageInfo.PagesCount - 1;
        }

        private bool ItIsNotFirstPage()
        {
            return _pageInfo.Index != 0;
        }

        private TagBuilder GetTag(int page, string innerHtml)
        {
            var div = new TagBuilder("button");
            div.Attributes.Add("type", "button");

            div.AddCssClass("btn");
            div.AddCssClass("btn-default");

            var href = new TagBuilder("a");

            href.Attributes.Add("href", string.Format("{0}?page={1}{2}", _virtualPath, page, _restQueryPart));
            href.InnerHtml += innerHtml;

            div.InnerHtml += href;

            return div;
        }
    }
}