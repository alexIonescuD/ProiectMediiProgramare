using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace Proiect_ASP_NET.Models
{
    public class Car
    {
        public int ID { get; set; }
        [Display(Name = "Car Model")]
        public string Model { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        [Range(10, 5000000)]

        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime FabricationDate { get; set; }

        public int? DealerID { get; set; }
        public Dealer? Dealer { get; set; }

        public int? BrandID { get; set; }
        public Brand? Brand { get; set; }

        public int? CategoryID { get; set; }
        public Category? Category { get; set; }


    }
}
