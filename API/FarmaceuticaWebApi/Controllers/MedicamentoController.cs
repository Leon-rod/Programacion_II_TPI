using Microsoft.AspNetCore.Mvc;

namespace FarmaceuticaWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MedicamentoController : Controller
    {
        [HttpGet]
        
        public IActionResult GetMedicamentos() {
        return View();
        
        }
    }
}
