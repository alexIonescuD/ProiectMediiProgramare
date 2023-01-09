using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_ASP_NET.Data;
using Proiect_ASP_NET.Models;


namespace Proiect_ASP_NET.Pages.Cars
{
    [Authorize(Roles = "Admin")]

    public class CreateModel : PageModel
    {
        private readonly Proiect_ASP_NET.Data.Proiect_ASP_NETContext _context;

        public CreateModel(Proiect_ASP_NET.Data.Proiect_ASP_NETContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DealerID"] = new SelectList(_context.Set<Dealer>(), "ID",
"DealerName");
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID",
"Name");
            ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID",
"CategoryName");

            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Car.Add(Car);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
