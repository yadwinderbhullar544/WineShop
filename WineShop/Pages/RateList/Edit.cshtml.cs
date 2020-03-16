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

namespace WineShop.Pages.RateList
{
    public class EditModel : PageModel//edit class
    {
        private readonly WineShop.Data.ApplicationDbContext _context;

        public EditModel(WineShop.Data.ApplicationDbContext context)
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

            RateList = await _context.RateList.SingleOrDefaultAsync(m => m.ID == id);//edit ratelist

            if (RateList == null)
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

            _context.Attach(RateList).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RateListExists(RateList.ID))
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

        private bool RateListExists(int id)
        {
            return _context.RateList.Any(e => e.ID == id);
        }
    }
}
