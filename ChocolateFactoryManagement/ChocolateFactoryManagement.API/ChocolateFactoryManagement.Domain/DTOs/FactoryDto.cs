namespace ChocolateFactoryManagement.Domain.DTOs
{
    public class FactoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ChocolateBarDto> ChocolateBars { get; set; }
    }
}
