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
        public string SerialNumber { get; set; }
        public int FactoryId { get; set; }
        public Factory Factory { get; set; }
        public virtual ICollection<WholesalerStock> WholesalerStocks { get; set; }
    }
}
