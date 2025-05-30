using Microsoft.AspNetCore.Mvc;
using MiAPI.Models;

namespace MiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FigurasController : ControllerBase
    {
        [HttpPost("cubo")]
        public ActionResult<object> CalcularCubo([FromBody] Cubo cubo)
        {
            if (cubo.Lado <= 0)
                return BadRequest("El lado debe ser mayor que 0");

            return new
            {
                Tipo = cubo.Tipo,
                Lado = cubo.Lado,
                Area = cubo.CalcularArea(),
                Volumen = cubo.CalcularVolumen()
            };
        }

        [HttpPost("esfera")]
        public ActionResult<object> CalcularEsfera([FromBody] Esfera esfera)
        {
            if (esfera.Radio <= 0)
                return BadRequest("El radio debe ser mayor que 0");

            return new
            {
                Tipo = esfera.Tipo,
                Radio = esfera.Radio,
                Area = esfera.CalcularArea(),
                Volumen = esfera.CalcularVolumen()
            };
        }

        [HttpPost("cilindro")]
        public ActionResult<object> CalcularCilindro([FromBody] Cilindro cilindro)
        {
            if (cilindro.Radio <= 0 || cilindro.Altura <= 0)
                return BadRequest("El radio y la altura deben ser mayores que 0");

            return new
            {
                Tipo = cilindro.Tipo,
                Radio = cilindro.Radio,
                Altura = cilindro.Altura,
                Area = cilindro.CalcularArea(),
                Volumen = cilindro.CalcularVolumen()
            };
        }
    }
} 