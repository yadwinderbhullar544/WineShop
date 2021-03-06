﻿using System;
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
    public class CreateModel : PageModel//Create class for functionality of crating customer
    {
        private readonly WineShop.Data.ApplicationDbContext _context;

        public CreateModel(WineShop.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["RateListID"] = new SelectList(_context.RateList, "ID", "Price");//this is for ratelist dropdown
        ViewData["WineID"] = new SelectList(_context.Wines, "ID", "Name");//this is for wine dropdown
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

            _context.Customer.Add(Customer);//adding customer
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}