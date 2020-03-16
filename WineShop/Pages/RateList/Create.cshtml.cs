using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WineShop.Bussiness;
using WineShop.Data;

namespace WineShop.Pages.RateList
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
            return Page();
        }

        [BindProperty]
        public WineShop.Bussiness.RateList RateList { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.RateList.Add(RateList);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}