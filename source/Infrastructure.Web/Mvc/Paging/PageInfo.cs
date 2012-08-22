using System;

namespace ByndyuSoft.Infrastructure.Web.Mvc.Paging
{
    /// <summary>
    /// Информаия о странице
    /// </summary>
    public class PageInfo
    {
        /// <summary>
        /// Возвращает информацию о пустой странице
        /// </summary>
        public static PageInfo Empty
        {
            get { return new PageInfo(0, 1, 0); }
        }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="index">Индекс страницы</param>
        /// <param name="pageSize">Размер страницы</param>
        /// <param name="totalItemsCount">Количество элементов</param>
        public PageInfo(int index, int pageSize, int totalItemsCount)
        {
            if (index < 0)
                throw new ArgumentOutOfRangeException("index", @"Index cannot be below 0.");

            if (pageSize < 1)
                throw new ArgumentOutOfRangeException("pageSize", @"PageSize cannot be less than 1.");

            Index = index;
            PageSize = pageSize;
            TotalItemsCount = totalItemsCount;
        }

        /// <summary>
        /// Количество страниц
        /// </summary>
        public int PagesCount
        {
            get { return TotalItemsCount / PageSize + (TotalItemsCount % PageSize != 0 ? 1 : 0); }
        }

        /// <summary>
        /// Всего элементов
        /// </summary>
        public int TotalItemsCount { get; private set; }

        /// <summary>
        /// Индекс страницы
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Номер страницы <see cref="Index"/>+1
        /// </summary>
        public int Number
        {
            get { return Index + 1; }
        }

        /// <summary>
        /// Размер страницы
        /// </summary>
        public int PageSize { get; private set; }
    }
}