using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAuslink.Models
{
    public class Paging<T>:List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; set; }

        public Paging(List<T> items,int count,int pIndex,int pageSize)
        {
            this.PageIndex = pIndex;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);


        }

        public bool PrevsiouPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }
        public bool NextPage
        {
            get 
            {
                return PageIndex < TotalPages;
            }
        
        }
        public static async Task<Paging<T>> CreateAsync(IQueryable<T> source, int pageIndex, int PageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * PageSize).Take(PageSize).ToListAsync();
            return new Paging<T>(items, count, pageIndex, PageSize);
        }
    }
}
