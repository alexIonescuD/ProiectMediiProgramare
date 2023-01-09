using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP_NET.Data;
using Proiect_ASP_NET.Models;

namespace Proiect_ASP_NET.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_ASP_NET.Data.Proiect_ASP_NETContext _context;

        public IndexModel(Proiect_ASP_NET.Data.Proiect_ASP_NETContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get; set; } = default!;

        public IEnumerable<Car> AuxCar { get; set; } = default!;
        public CarData CarD { get; set; }
        public int CarID { get; set; }
        public int CategoryID { get; set; }

        public string ModelSort { get; set; }
        public string BrandSort { get; set; }

        public string DealerSort { get; set; }

        public string CurrentFilter { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            ModelSort = String.IsNullOrEmpty(sortOrder) ? "model_desc" : "";
            BrandSort = String.IsNullOrEmpty(sortOrder) ? "brand_desc" : "";
            DealerSort = String.IsNullOrEmpty(sortOrder) ? "dealer_desc" : "";

            CurrentFilter = searchString;

            if (_context.Car != null)
            {
                Car = await _context.Car
                .Include(c => c.Dealer)
                .Include(c => c.Brand)
                .Include(c => c.Category)
                .OrderBy(c => c.Brand.Name)
                .AsNoTracking()
                .ToListAsync();
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                Car = (Car.Where(s => s.Model.Contains(searchString)
                                   || s.Brand.Name.Contains(searchString)
                                   || s.Dealer.DealerName.Contains(searchString)
                                   || s.Category.CategoryName.Contains(searchString))).ToList();
            }



            switch (sortOrder)
            {
                case "model_desc":
                    Car = await _context.Car
                .Include(c => c.Dealer)
                .Include(c => c.Brand)
                .Include(c => c.Category)
                .OrderByDescending(c => c.Model)
                .AsNoTracking()
                .ToListAsync();
                    break;
                case "brand_desc":
                    Car = await _context.Car
                .Include(c => c.Dealer)
                .Include(c => c.Brand)
                .Include(c => c.Category)
                .OrderByDescending(c => c.Brand.Name)
                .AsNoTracking()
                .ToListAsync();
                    break;
                case "dealer_desc":
                    Car = await _context.Car
                .Include(c => c.Dealer)
                .Include(c => c.Brand)
                .Include(c => c.Category)
                .OrderByDescending(c => c.Dealer.DealerName)
                .AsNoTracking()
                .ToListAsync();
                    break;
            }
        }
    }
}
