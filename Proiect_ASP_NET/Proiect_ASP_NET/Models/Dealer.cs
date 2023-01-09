namespace Proiect_ASP_NET.Models
{
    public class Dealer
    {

        public int ID { get; set; }
        public string DealerName { get; set; }
        public ICollection<Car>? Cars { get; set; }

    }
}
