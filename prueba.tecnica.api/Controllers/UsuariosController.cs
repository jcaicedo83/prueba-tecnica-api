using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using prueba.tecnica.core.dto;
using prueba.tecnica.core.interfaces.services;

namespace prueba.tecnica.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _svc;

        public UsuariosController(IUsuariosService svc)
        {
            _svc = svc;
        }

        [HttpPost]
        [Route("consultar")]
        public IActionResult consultar([FromBody] requestItem item)
        {
            return Ok(_svc.Consultar(item));
        }

        [HttpPost]
        [Route("insertar")]
        public IActionResult Insertar([FromBody] requestItem item)
        {
            return Ok(_svc.Insertar(item));
        }

        [HttpPost]
        [Route("actualizar")]
        public IActionResult Actualizar([FromBody] requestItem item)
        {
            return Ok(_svc.Actualizar(item));
        }

        [HttpPost]
        [Route("eliminar")]
        public IActionResult Eliminar([FromBody] requestItem item)
        {
            return Ok(_svc.Eliminar(item));
        }
    }
}
