namespace ChocolateFactoryManagement.Domain.Models
{
    public class Factory
    {
        public Factory()
        {
            ChocolateBars = new HashSet<ChocolateBar>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ChocolateBar> ChocolateBars { get; set; }
    }
}
