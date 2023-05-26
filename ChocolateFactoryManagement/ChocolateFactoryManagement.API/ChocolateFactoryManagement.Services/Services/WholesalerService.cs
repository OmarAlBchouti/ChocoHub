using AutoMapper;
using ChocolateFactoryManagement.Domain.DTOs;
using ChocolateFactoryManagement.Domain.Models;
using ChocolateFactoryManagement.Infrastructure.Repositories;

namespace ChocolateFactoryManagement.Services.Services
{
    public interface IWholesalerService
    {
        Task CreateWholesalerStock(WholesalerStockDto stock);
        Task UpdateWholesalerStock(int wholesalerId, StockRequestDto stock);
        Task<QuoteSummaryDto> GenerateQuote(RequestDto quote);
    }

    public class WholesalerService : IWholesalerService
    {
        private readonly IWholesalerRepository _wholesalerRepository;
        private readonly IChocolateBarRepository _chocolateBarRepository;

        private readonly IMapper _mapper;
        public WholesalerService(IWholesalerRepository wholesalerRepository, IChocolateBarRepository chocolateBarRepository, IMapper mapper)
        {
            _wholesalerRepository = wholesalerRepository;
            _chocolateBarRepository = chocolateBarRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Create Wholesaler Stock 
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task CreateWholesalerStock(WholesalerStockDto stock)
        {
            var mappedStock = _mapper.Map<WholesalerStock>(stock);

            var existingChocolateBar = await _chocolateBarRepository.GetChocolateBarById(stock.ChocolateBarId);
            if (existingChocolateBar == null)
                throw new Exception("The ChocolateBar must exist!");

            var existingwholesaler = await _wholesalerRepository.GetWholesalerById(stock.WholesalerId);
            if (existingwholesaler == null)
                throw new Exception("The Wholesaler must exist!");

            await _wholesalerRepository.AddStock(mappedStock);
        }

        /// <summary>
        /// Update Wholesaler Stock
        /// </summary>
        /// <param name="wholesalerId"></param>
        /// <param name="stock"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task UpdateWholesalerStock(int wholesalerId, StockRequestDto stock)
        {
            var existingChocolateBar = await _chocolateBarRepository.GetChocolateBarById(stock.ChocolateBarId);
            if (existingChocolateBar == null)
                throw new Exception("The ChocolateBar must exist!");

            var existingwholesaler = await _wholesalerRepository.GetWholesalerById(wholesalerId);
            if (existingwholesaler == null)
                throw new Exception("The Wholesaler must exist!");

            var existingStock = await _wholesalerRepository.GetWholesalerStock(wholesalerId, stock.ChocolateBarId);
            if (existingStock != null)
            {
                existingStock.Quantity += stock.Quantity;
                await _wholesalerRepository.UpdateWholesalerStock(existingStock);
            }
            else
            {
                existingStock = new WholesalerStock()
                {
                    ChocolateBarId = stock.ChocolateBarId,
                    WholesalerId = wholesalerId,
                    Quantity = stock.Quantity
                };

                await _wholesalerRepository.AddStock(existingStock);
            }
        }


        /// <summary>
        /// Generate Quote From Wholesaler For Client
        /// </summary>
        /// <param name="quote"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<QuoteSummaryDto> GenerateQuote(RequestDto quote)
        {
            decimal totalPrice = 0;
            var quoteSummary = _mapper.Map<QuoteSummaryDto>(quote);

            // Check if the order is empty
            if (quote.ChocolateBars == null)
                throw new Exception("The order cannot be empty!");

            // Check for duplicates in the order
            var orderItems = quote.ChocolateBars.GroupBy(o => o.Id)
                                           .Where(o => o.Skip(1).Any());
            if (orderItems.Any())
                throw new Exception("Duplicate items not allowed in the order!");


            // Check if the wholesaler exists
            var wholesaler = await _wholesalerRepository.GetWholesalerById(quote.WholesalerId) ?? throw new Exception("The wholesaler must exist!");


            // Check if the chocolate bar is sold by the wholesaler and the quantity is not greater than the wholesaler's stock
            foreach (var item in quoteSummary.OrderSummary)
            {
                var quoteItem = new ChocolateBarRequestDto();
                var chocolateBar = await _chocolateBarRepository.GetChocolateBarById(item.Id);
                var wholesalerStock = await _wholesalerRepository.GetWholesalerStock(quote.WholesalerId, item.Id) ?? throw new Exception($"Chocolate bar {chocolateBar.Name} not sold by the wholesaler");
                var quantity = item.Quantity;
                if (quantity > wholesalerStock.Quantity)
                {
                    throw new Exception($"Quantity of chocolate bar {chocolateBar.Name} in order is greater than the wholesaler's stock");
                }

                item.Price = quantity * chocolateBar.Price;
                totalPrice += item.Price;
            }

            // Apply discounts if applicable           
            var discount = quoteSummary.OrderSummary.Sum(o => o.Quantity) > 10 ? totalPrice * 0.1m
                : quoteSummary.OrderSummary.Sum(o => o.Quantity) > 20 ? totalPrice * 0.2m
                : 0;

            quoteSummary.Discount = quoteSummary.OrderSummary.Sum(o => o.Quantity) > 10 ? "10%"
                : quoteSummary.OrderSummary.Sum(o => o.Quantity) > 20 ? "20%"
                : "0%";

            quoteSummary.TotalPrice = totalPrice - discount;

            return quoteSummary;
        }
    }
}
