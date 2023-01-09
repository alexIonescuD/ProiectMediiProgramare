using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP_NET.Data;
using Proiect_ASP_NET.Models;
using Proiect_ASP_NET.Models.ViewModels;

namespace Proiect_ASP_NET.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_ASP_NET.Data.Proiect_ASP_NETContext _context;

        public IndexModel(Proiect_ASP_NET.Data.Proiect_ASP_NETContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int CarID { get; set; }


        public async Task OnGetAsync(int? id, int? carID)
        {
            CategoryData = new CategoryIndexData();

            
                CategoryData.Categories = await _context.Category
                .Include(i => i.Cars)
                .ThenInclude(c => c.Brand)
                .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                .Where(i => i.ID == id.Value).Single();
                CategoryData.Cars = category.Cars;
            }
        }
    }
}
