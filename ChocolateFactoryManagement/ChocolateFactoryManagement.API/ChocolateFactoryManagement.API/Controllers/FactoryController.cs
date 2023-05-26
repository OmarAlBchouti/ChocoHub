using ChocolateFactoryManagement.Domain.Models;
using ChocolateFactoryManagement.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChocolateFactoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FactoryController : ControllerBase
    {

        private readonly IFactoryService _factoryService;
        public FactoryController(IFactoryService factoryService)
        {
            _factoryService = factoryService;
        }

        /// <summary>
        /// Get list of all factories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await _factoryService.GetAllAsync();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Create Chocolate Bar by factory
        /// </summary>
        /// <param name="factoryId"></param>
        /// <param name="chocolateBar"></param>
        /// <returns></returns>
        [HttpPost("{factoryId}/chocolateBar")]
        public async Task<IActionResult> Post(int factoryId, [FromBody] ChocolateBar chocolateBar)
        {
            try
            {
                await _factoryService.CreateChocolateBar(factoryId, chocolateBar);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Delete Chocoloate Bar by factory
        /// </summary>
        /// <param name="factoryId"></param>
        /// <param name="chocolateBarId"></param>
        /// <returns></returns>
        [HttpDelete("{factoryId}/ChocoloateBar/{chocolateBarId}")]
        public async Task<IActionResult> DeleteChocoloateBar(int factoryId, int chocolateBarId)
        {
            try
            {
                await _factoryService.DeleteChocolateBar(factoryId, chocolateBarId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
