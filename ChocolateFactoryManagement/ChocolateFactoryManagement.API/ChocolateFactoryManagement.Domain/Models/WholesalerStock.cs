using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChocolateFactoryManagement.Domain.Models
{
    public class WholesalerStock
    {
        public int ChocolateBarId { get; set; }
        public int WholesalerId { get; set; }
        public int Quantity { get; set; }

        public virtual ChocolateBar ChocolateBar { get; set; }
        public virtual Wholesaler Wholesaler { get; set; }
    }
}
