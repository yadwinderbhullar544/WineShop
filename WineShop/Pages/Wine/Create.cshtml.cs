using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WineShop.Bussiness;
using WineShop.Data;

namespace WineShop.Pages.Wine
{
    public class CreateModel : PageModel//create class
    {
        private readonly WineShop.Data.ApplicationDbContext _context;

        public CreateModel(WineShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WineShop.Bussiness.Wine Wine { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Wines.Add(Wine);//add wine
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}