using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_ASP_NET.Models
{
    public class Brand
    {
        public int ID { get; set; }
        [Display(Name = "Brand Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime EstablishedDate { get; set; }

        public ICollection<Brand>? Brands { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
