using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _service;

        public PedidoController(IPedidoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPedidos()
        {
            try
            {
                var pedidos = await _service.GetAll();
                if (pedidos.Count > 0)
                {
                    return Ok(pedidos);
                }
                return StatusCode(500, "No hay pedidos disponibles");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor..." + e);
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetPedidoId([FromQuery] int id)
        {
            try
            {
                if(id <= 0)
                {
                    return StatusCode(500, "Debe introducir un numero de pedido mayor a 0");
                }
                else
                {
                    var pedido = await _service.GetById(id);   
                    if(pedido != null)
                    {
                        return Ok(pedido);
                    }
                    else
                    {
                        return StatusCode(500, "No existe ese numero de pedido");
                    }
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Error en el servidor:" + e);
            }
        }
    }
}
