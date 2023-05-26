using ChocolateFactoryManagement.Domain.DTOs;
using ChocolateFactoryManagement.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace ChocolateFactoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholesalerController : ControllerBase
    {
        private IWholesalerService _wholesalerService;
        public WholesalerController(IWholesalerService wholesalerService)
        {
            _wholesalerService = wholesalerService;
        }

        /// <summary>
        /// add ChocolateBar quantity to new  wholesaler stock 
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        [HttpPost("{wholesalerId}/Sale")]
        public async Task<IActionResult> PostStock([FromBody] WholesalerStockDto stock)
        {
            try
            {
                await _wholesalerService.CreateWholesalerStock(stock);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// add ChocolateBar quantity to existing or new  wholesaler stock 
        /// </summary>
        /// <param name="wholesalerId"></param>
        /// <param name="stock"></param>
        /// <returns></returns>
        [HttpPut("{wholesalerId}/Stock")]
        public async Task<IActionResult> PutStock(int wholesalerId, [FromBody] StockRequestDto stock)
        {
            try
            {
                await _wholesalerService.UpdateWholesalerStock(wholesalerId, stock);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Request a quote from a wholesaler
        /// </summary>
        /// <param name="quote"></param>
        /// <returns></returns>
        [HttpPost("Quote")]
        public async Task<IActionResult> SubmitQuote([FromBody] RequestDto quote)
        {
            try
            {
                return Ok(await _wholesalerService.GenerateQuote(quote));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
