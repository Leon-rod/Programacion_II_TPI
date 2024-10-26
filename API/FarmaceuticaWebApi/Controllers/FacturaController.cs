using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _service;
        public FacturaController(IFacturaService service)
        {
            this._service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Factura> facturas = await _service.GetAll();
            return Ok(facturas);
        }
        [HttpGet("Client")]
        public async Task<IActionResult> GetByClient([FromQuery]int client)
        {
            List<Factura> facturas = await _service.GetByClient(client);
            return Ok(facturas);
        }
        [HttpGet("Dates")]
        public async Task<IActionResult> GetByDates([FromQuery]DateOnly startDate, [FromQuery] DateOnly endDate)
        {
            List<Factura> facturas = await _service.GetByDates(startDate, endDate);
            return Ok(facturas);
        }
        [HttpGet("Employee")]
        public async Task<IActionResult> GetByEmployee([FromQuery] int employee)
        {
            List<Factura> facturas = await _service.GetByEmployee(employee);
            return Ok(facturas);
        }
        [HttpGet("Establishment")]
        public async Task<IActionResult> GetByEstablishment([FromQuery]int establishment)
        {
            List<Factura> facturas = await _service.GetByEstablishment(establishment);
            return Ok(facturas);
        }
    }
}
