using Microsoft.AspNetCore.Mvc;

namespace AreaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AreaController : ControllerBase
{
    [HttpPost("calcular")]
    public IActionResult CalcularArea([FromBody] FiguraRequest figura)
    {
        double area;

        switch (figura.Tipo.ToLower())
        {
            case "rectangulo":
                area = figura.Base * figura.Altura;
                break;

            case "triangulo":
                area = (figura.Base * figura.Altura) / 2;
                break;

            case "circulo":
                if (figura.Radio <= 0)
                    return BadRequest("El radio debe ser mayor que 0");
                area = Math.PI * Math.Pow(figura.Radio, 2);
                break;

            default:
                return BadRequest("Tipo de figura no reconocido. Usa: rectangulo, triangulo o circulo.");
        }

        return Ok(new { figura = figura.Tipo, area });
    }
}

// Modelo para recibir los datos
public class FiguraRequest
{
    public string Tipo { get; set; } = string.Empty; // "rectangulo", "triangulo", "circulo"
    public double Base { get; set; }
    public double Altura { get; set; }
    public double Radio { get; set; }
}
