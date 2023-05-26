namespace ChocolateFactoryManagement.Domain.DTOs
{
    public class ChocolateBarRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FactoryId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
