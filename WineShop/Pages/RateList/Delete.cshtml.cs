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
    public class DeleteModel : PageModel
    {
        private readonly WineShop.Data.ApplicationDbContext _context;

        public DeleteModel(WineShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            RateList = await _context.RateList.FindAsync(id);

            if (RateList != null)
            {
                _context.RateList.Remove(RateList);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
