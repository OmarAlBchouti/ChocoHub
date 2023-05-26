namespace ChocolateFactoryManagement.Domain.DTOs
{
    public class QuoteSummaryDto
    {
        public string ClientName { get; set; }
        public int WholesalerId { get; set; }
        public decimal TotalPrice { get; set; }
        public string Discount { get; set; }

        public ICollection<ChocolateBarRequestDto> OrderSummary { get; set; }
    }
}
