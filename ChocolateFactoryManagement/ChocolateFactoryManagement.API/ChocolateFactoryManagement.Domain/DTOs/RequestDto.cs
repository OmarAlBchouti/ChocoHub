namespace ChocolateFactoryManagement.Domain.DTOs
{
    public class RequestDto
    {
        public string ClientName { get; set; }
        public int WholesalerId { get; set; }
        public List<ChocolateBarRequestDto> ChocolateBars { get; set; }
    }
}
