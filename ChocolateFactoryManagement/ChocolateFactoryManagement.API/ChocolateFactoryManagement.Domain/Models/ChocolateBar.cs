using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryManagement.Domain.Models
{
    public class ChocolateBar
    {
        public ChocolateBar()
        {
            WholesalerStocks = new HashSet<WholesalerStock>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Cacao { get; set; }
        public decimal Price { get; set; }
        public int FactoryId { get; set; }
        public Factory Factory { get; set; }
        public virtual ICollection<WholesalerStock> WholesalerStocks { get; set; }
    }
}
