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
        [HttpGet("ID")]
        public async Task<IActionResult> GetById([FromQuery]int id)
        {
            Factura? factura = await _service.GetById(id);
            if (factura == null)
                return NotFound("No se ha encontrado una factura con ese id");
            return Ok(factura);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Factura factura)
        {
            List<Factura> facturas = await _service.GetAll();
            Factura? f = null;
            foreach(Factura oFactura in facturas)
            {
                if (oFactura.IdFactura == factura.IdFactura)
                    f = oFactura;
            }
            if (f == null)
                return NotFound();
            string? validacion = ValidarFactura(factura);
            if (validacion != null)
                return BadRequest(validacion);
            bool result = await _service.Insert(factura);
            if (result)
                return Ok("Se ha agregado una factura con exito");
            return StatusCode(500,"Ha ocurrido un error al intentar insertar una factura en la base de datos");
        }




        private string? ValidarFactura(Factura factura)
        {
            string? result = null;
            if (factura.Fecha > DateOnly.FromDateTime(DateTime.Today.Date) || factura.Fecha < DateOnly.FromDateTime(DateTime.Today.Date))
            {
                result = "La factura solo se puede cargar si es de hoy";
            }
            return result;
        }
    }
}
