using System;
using System.Collections.Generic;

namespace ByndyuSoft.Infrastructure.Common
{
    public interface IPagedEnumerable<out T> : IEnumerable<T>
    {
        int TotalCount { get; }
    }
}