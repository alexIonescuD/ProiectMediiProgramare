using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP_NET.Data;
using Proiect_ASP_NET.Models;
using Proiect_ASP_NET.Models.ViewModels;

namespace Proiect_ASP_NET.Pages.Dealers
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_ASP_NET.Data.Proiect_ASP_NETContext _context;

        public IndexModel(Proiect_ASP_NET.Data.Proiect_ASP_NETContext context)
        {
            _context = context;
        }

        public IList<Dealer> Dealer { get; set; } = default!;

        public DealerIndexData DealerData { get; set; }

        public int DealerID { get; set; }
        public int CarID { get; set; }
        public async Task OnGetAsync(int? id, int? carID)
        {
            DealerData = new DealerIndexData();
            DealerData.Dealers = await _context.Dealer
            .Include(i => i.Cars)
            .ThenInclude(c => c.Brand)
            .OrderBy(i => i.DealerName)
            .ToListAsync();
            if (id != null)
            {
                DealerID = id.Value;
                Dealer dealer = DealerData.Dealers
                .Where(i => i.ID == id.Value).Single();
                DealerData.Cars = dealer.Cars;
            }

        }
    }
}
