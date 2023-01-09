using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP_NET.Data;
using Proiect_ASP_NET.Models;

namespace Proiect_ASP_NET.Pages.Contracts
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_ASP_NET.Data.Proiect_ASP_NETContext _context;

        public CreateModel(Proiect_ASP_NET.Data.Proiect_ASP_NETContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var carList = _context.Car
                      .Include(c => c.Brand)
                   .Select(x => new
                     {
                        x.ID,
                        CarFullName = x.Brand.Name + " " + x.Model
                     });

        ViewData["DealerID"] = new SelectList(_context.Dealer, "ID", "DealerName");
        ViewData["CarID"] = new SelectList(carList, "ID", "CarFullName");
        ViewData["ClientID"] = new SelectList(_context.Client, "ID", "FullName");
        ViewData["CarPrice"] = new SelectList(_context.Car, "ID", "Price");
            return Page();
        }

        [BindProperty]
        public Contract Contract { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Contract.Add(Contract);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
