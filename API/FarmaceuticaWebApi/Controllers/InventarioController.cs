using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : Controller
    {
        private readonly IInventarioService _inventarioService;

        public InventarioController(IInventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllInventarios()
        {
            return Ok(await _inventarioService.GetAll());
        }

        [HttpGet("Factura")]

        public async Task<IActionResult> GetInventarioByFactura(int id, DateTime from, DateTime to)
        {
            try
            {
                var inventario = await _inventarioService.GetInventarioByFactura(id, from, to);

                if (inventario != null)
                {
                    foreach(Inventario i in inventario)
                    {
                        i.DetallesPedido = null;
                        i.IdTipoMovNavigation = null;
                        i.IdStockNavigation = null; 
                    }
                    return Ok(inventario);
                }
                else
                {
                    return BadRequest("No se encontraron coincidencias.");
                }
            }
            catch (Exception exc)
            {
                return StatusCode(500, "Error de servidor");
            }

        }

        [HttpGet("Pedido")]

        public async Task<IActionResult> GetInventarioByPedido(int id, DateTime from, DateTime to)
        {
            try
            {
                var inventario = await _inventarioService.GetInventarioByPedido(id, from, to);

                if (inventario != null)
                {
                    return Ok(inventario);
                }
                else
                {
                    return BadRequest("No se encontraron coincidencias.");
                }
            }
            catch (Exception exc)
            {
                return StatusCode(500, "Error de servidor");
            }

        }
    }
}
