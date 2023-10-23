

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace man_power_planning.Shared.Helper
{
    public class PageList<T>
    {
        private PageList(IQueryable<T> items, int? page, int? pageSize, int totalCountData)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalCountData = totalCountData;
        }

        public IQueryable<T> Items { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public int TotalCountData { get; set; }
        // public bool HasNextPage => Page * PageSize < TotalCountData;
        // public bool HasPrevious => PageSize > 1;
        public static async Task<PageList<T>> ShowDataAsync(IQueryable<T> allT, IQueryable<T> result, int? page, int? pageSize)
        {
            int totalCountData = await allT.AsQueryable().CountAsync();
            return new PageList<T>(result, page, pageSize, totalCountData);
        }

    }
}