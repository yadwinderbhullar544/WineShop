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
    public class DetailsModel : PageModel
    {
        private readonly WineShop.Data.ApplicationDbContext _context;

        public DetailsModel(WineShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public WineShop.Bussiness.RateList RateList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RateList = await _context.RateList.SingleOrDefaultAsync(m => m.ID == id);

            if (RateList == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
