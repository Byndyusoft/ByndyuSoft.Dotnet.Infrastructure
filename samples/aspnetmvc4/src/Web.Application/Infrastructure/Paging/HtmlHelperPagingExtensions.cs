namespace Mvc4Sample.Web.Application.Infrastructure.Paging
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using ByndyuSoft.Infrastructure.Web.Mvc.Paging;
    using JetBrains.Annotations;

    ///<summary>
    ///</summary>
    public static class HtmlHelperPagingExtensions
    {
        #region HtmlHelper extensions

        /// <summary>
        /// Контрол пейджер
        /// </summary>
        /// <param name="htmlHelper"><see cref="HtmlHelper"/></param>
        /// <param name="pageInfo"></param>
        /// <returns>HTML текст с пейджером</returns>
        public static MvcHtmlString Pager(this HtmlHelper htmlHelper,
                                          [NotNull] PageInfo pageInfo)
        {
            var pager = new Pager(htmlHelper.ViewContext.RequestContext, pageInfo, Enumerable.Empty<string>());

            pager.Initialize();

            return pager.RenderHtml();
        }

        /// <summary>
        /// Контрол пейджер
        /// </summary>
        /// <param name="htmlHelper"><see cref="HtmlHelper"/></param>
        /// <param name="pageInfo"></param>
        /// <param name="queryKeysForCut"> Ключи запроса, которые необходимо удалять. В полученном адресе перехода соответствующие ключи будут отсутствовать</param>
        /// <returns>HTML текст с пейджером</returns>
        public static MvcHtmlString Pager(this HtmlHelper htmlHelper,
                                          [NotNull] PageInfo pageInfo,
                                          [NotNull] IEnumerable<string> queryKeysForCut)
        {
            var pager = new Pager(htmlHelper.ViewContext.RequestContext, pageInfo, queryKeysForCut);

            pager.Initialize();

            return pager.RenderHtml();
        }

        #endregion
    }
}