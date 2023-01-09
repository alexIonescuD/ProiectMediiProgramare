using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP_NET.Data;
using Proiect_ASP_NET.Models;

namespace Proiect_ASP_NET.Pages.Contracts
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_ASP_NET.Data.Proiect_ASP_NETContext _context;

        public DetailsModel(Proiect_ASP_NET.Data.Proiect_ASP_NETContext context)
        {
            _context = context;
        }

      public Contract Contract { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contract == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract.FirstOrDefaultAsync(m => m.ID == id);
            if (contract == null)
            {
                return NotFound();
            }
            else 
            {
                Contract = contract;
            }
            return Page();
        }
    }
}
