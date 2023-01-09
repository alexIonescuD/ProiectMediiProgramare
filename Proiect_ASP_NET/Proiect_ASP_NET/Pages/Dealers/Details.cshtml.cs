using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP_NET.Data;
using Proiect_ASP_NET.Models;

namespace Proiect_ASP_NET.Pages.Dealers
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_ASP_NET.Data.Proiect_ASP_NETContext _context;

        public DetailsModel(Proiect_ASP_NET.Data.Proiect_ASP_NETContext context)
        {
            _context = context;
        }

      public Dealer Dealer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dealer == null)
            {
                return NotFound();
            }

            var dealer = await _context.Dealer.FirstOrDefaultAsync(m => m.ID == id);
            if (dealer == null)
            {
                return NotFound();
            }
            else 
            {
                Dealer = dealer;
            }
            return Page();
        }
    }
}
