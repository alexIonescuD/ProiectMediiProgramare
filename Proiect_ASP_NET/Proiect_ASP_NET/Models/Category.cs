namespace Proiect_ASP_NET.Models
{
    public class Category
    {

        public int ID { get; set; }
        public string CategoryName { get; set; }
        public ICollection<Car>? Cars { get; set; }
    }
}
