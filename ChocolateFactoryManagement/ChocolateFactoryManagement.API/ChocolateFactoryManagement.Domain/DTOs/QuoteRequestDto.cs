namespace ChocolateFactoryManagement.Domain.DTOs
{
    public class QuoteRequestDto
    {
        public string ClientName { get; set; }
        public int WholesalerId { get; set; }
        public List<ChocolateBarRequestDto> ChocolateBars { get; set; }
    }
}
