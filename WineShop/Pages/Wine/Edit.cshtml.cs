using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WineShop.Bussiness;
using WineShop.Data;

namespace WineShop.Pages.Wine
{
    public class EditModel : PageModel//updating the wine class
    {
        private readonly WineShop.Data.ApplicationDbContext _context;

        public EditModel(WineShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WineShop.Bussiness.Wine Wine { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wine = await _context.Wines.SingleOrDefaultAsync(m => m.ID == id);

            if (Wine == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Wine).State = EntityState.Modified;//update wine

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WineExists(Wine.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WineExists(int id)
        {
            return _context.Wines.Any(e => e.ID == id);
        }
    }
}
