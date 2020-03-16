using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WineShop.Bussiness;
using WineShop.Data;

namespace WineShop.Pages.Customer
{
    public class CreateModel : PageModel
    {
        private readonly WineShop.Data.ApplicationDbContext _context;

        public CreateModel(WineShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RateListID"] = new SelectList(_context.RateList, "ID", "Price");
        ViewData["WineID"] = new SelectList(_context.Wines, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public WineShop.Bussiness.Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customer.Add(Customer);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}