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
    public class IndexModel : PageModel
    {
        private readonly Proiect_ASP_NET.Data.Proiect_ASP_NETContext _context;

        public IndexModel(Proiect_ASP_NET.Data.Proiect_ASP_NETContext context)
        {
            _context = context;
        }

        public IList<Contract> Contract { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Contract != null)
            {
                Contract = await _context.Contract
                .Include(c => c.Car)
                .ThenInclude(c => c.Brand)
                .Include(c => c.Client)
                .Include(c => c.Dealer)
                .ToListAsync();
            }
        }
    }
}
