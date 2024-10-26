using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DispensacionController : ControllerBase
    {
        private readonly IDispensacionService _service;
        public DispensacionController(IDispensacionService service)
        {
            this._service = service;
        }
        [HttpGet("Factura")]
        public async Task<IActionResult> GetByFactura(int id)
        {
            List<Dispensacion> dispensacions = await _service.GetByIdFactura(id);
            return Ok(dispensacions);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Dispensacion d)
        {
            List<Dispensacion> dispensacion = await _service.GetByIdFactura(d.IdFactura);
            int id = 0;
            if (dispensacion.Count == 0)
                id = 1;
            else
                foreach (Dispensacion dis in dispensacion)
                {
                    if(dis.IdFactura <= id)
                        id = dis.IdFactura + 1;
                }
            d.IdFactura = id;
            bool result = await _service.Insert(d);
            if (result)
                return Ok("Se ha agregado una dispensacion con exito!");
            return StatusCode(500, "Ha ocurrido un error al intentar agregar una dispensacion");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            bool result = await _service.Delete(id);
            if (result)
                return Ok("Se ha eliminado con exito una dispensacion de la base de datos1");
            return StatusCode(500, "Ha ocurrido un error al intentar eliminar una dispensacion");
        }
    }
}
