using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP_NET.Data;
using Proiect_ASP_NET.Models;

namespace Proiect_ASP_NET.Pages.Brands
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_ASP_NET.Data.Proiect_ASP_NETContext _context;

        public DetailsModel(Proiect_ASP_NET.Data.Proiect_ASP_NETContext context)
        {
            _context = context;
        }

      public Brand Brand { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Brand == null)
            {
                return NotFound();
            }

            var brand = await _context.Brand.FirstOrDefaultAsync(m => m.ID == id);
            if (brand == null)
            {
                return NotFound();
            }
            else 
            {
                Brand = brand;
            }
            return Page();
        }
    }
}
