using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WineShop.Bussiness;
using WineShop.Data;

namespace WineShop.Pages.RateList
{
    public class IndexModel : PageModel
    {
        private readonly WineShop.Data.ApplicationDbContext _context;

        public IndexModel(WineShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WineShop.Bussiness.RateList> RateList { get;set; }

        public async Task OnGetAsync()
        {
            RateList = await _context.RateList.ToListAsync();
        }
    }
}
