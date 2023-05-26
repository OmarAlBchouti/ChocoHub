namespace ChocolateFactoryManagement.Domain.DTOs
{
    public class ChocolateBarDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FactoryId { get; set; }
        public string Cacao { get; set; }
        public decimal Price { get; set; }
    }
}
