using System.Security.Policy;

namespace Proiect_ASP_NET.Models.ViewModels
{
    public class DealerIndexData
    {
        public IEnumerable<Dealer> Dealers { get; set; }
        public IEnumerable<Car> Cars { get; set; }

    }
}
