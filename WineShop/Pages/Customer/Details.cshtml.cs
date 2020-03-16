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
    public class DetailsModel : PageModel
    {
        private readonly WineShop.Data.ApplicationDbContext _context;

        public DetailsModel(WineShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public WineShop.Bussiness.Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customer
                .Include(c => c.RateList)
                .Include(c => c.Wine).SingleOrDefaultAsync(m => m.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
