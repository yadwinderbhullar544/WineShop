using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WineShop.Bussiness;
using WineShop.Data;

namespace WineShop.Pages.Wine
{
    public class DeleteModel : PageModel
    {
        private readonly WineShop.Data.ApplicationDbContext _context;

        public DeleteModel(WineShop.Data.ApplicationDbContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Wine = await _context.Wines.FindAsync(id);

            if (Wine != null)
            {
                _context.Wines.Remove(Wine);//delete wine
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
