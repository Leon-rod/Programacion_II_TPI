using FarmaceuticaBack.Models;
using FarmaceuticaBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePedidoController : ControllerBase
    {
        private readonly IDetallePedidoService _service;

        public DetallePedidoController(IDetallePedidoService service)
        {
            _service = service;
        }
        //Task<List<DetallesPedido>> GetByPedido(int id);
        //Task<DetallesPedido> GetByDetallePedido(int idPedido, int idDetalleP);
        //Task<bool> Delete(int idPedido, int idDetalleP);
        //Task<bool> Save(DetallesPedido dp);

        [HttpGet]
        public async Task<IActionResult> GetByPedido(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return StatusCode(500, "Debe introducir un numero de pedido mayor a 0");
                }
                else
                {
                    var pedido = await _service.GetByPedido(id);
                    if (pedido.Count > 0)
                    {
                        return Ok(pedido);
                    }
                    else
                    {
                        return StatusCode(500, "No existen detalles para ese numero de pedido");
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
