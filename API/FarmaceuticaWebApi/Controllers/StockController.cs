using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;
        public StockController(IStockService stockService)
        {
            this._stockService = stockService;
        }
        [HttpGet("/Establishment")]
        public async Task<IActionResult> GetByEstablishment([FromQuery]int id)
        {
            List<Stock> stocks = await _stockService.GetByEstablishment(id);
            return Ok(stocks);
        }
        [HttpGet("/Establishment/Articles")]
        public async Task<IActionResult> GetByEstablishmentArticle([FromQuery]int id, [FromQuery]string? product, [FromQuery] string? medicine)
        {
            List<Stock> stocks = await _stockService.GetByEstablishmentAndArticle(id, product, medicine);
            return Ok(stocks);
        }
    }
}
