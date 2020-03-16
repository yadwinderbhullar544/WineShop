using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WineShop.Bussiness;
using WineShop.Data;

namespace WineShop.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly WineShop.Data.ApplicationDbContext _context;

        public IndexModel(WineShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WineShop.Bussiness.Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer
                .Include(c => c.RateList)
                .Include(c => c.Wine).ToListAsync();
        }
    }
}
