using System.Security.Policy;

namespace Proiect_ASP_NET.Models.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Car> Cars { get; set; }

    }
}
