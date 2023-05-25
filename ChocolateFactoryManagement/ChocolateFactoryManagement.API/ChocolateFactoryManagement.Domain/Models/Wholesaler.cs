using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryManagement.Domain.Models
{
    public class Wholesaler
    {
        public Wholesaler()
        {
            WholesalerStocks = new HashSet<WholesalerStock>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<WholesalerStock> WholesalerStocks { get; set; }
    }
}
