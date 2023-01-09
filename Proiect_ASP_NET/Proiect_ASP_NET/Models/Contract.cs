using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;

namespace Proiect_ASP_NET.Models
{
    public class Contract
    {

        public int ID { get; set; }
        [Display(Name = "Client Name")]
        public int? ClientID { get; set; }
        public Client? Client { get; set; }
        [Display(Name = "Car Model")]
        public int? CarID { get; set; }
        public Car? Car { get; set; }
        public int? DealerID { get; set; }
        public Dealer? Dealer { get; set; }

        [Column(TypeName = "decimal(15, 2)")]
        [Range(10, 5000000)]

        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime ContractDate { get; set; }

    }
}
