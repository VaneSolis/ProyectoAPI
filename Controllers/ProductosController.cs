using Microsoft.AspNetCore.Mvc;
using MiAPI.Models;

namespace MiAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private static List<Producto> _productos = new List<Producto>();

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> Get()
        {
            return Ok(_productos);
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            return Ok(producto);
        }

        [HttpPost]
        public ActionResult<Producto> Post(Producto producto)
        {
            producto.Id = _productos.Count + 1;
            _productos.Add(producto);
            return CreatedAtAction(nameof(Get), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Producto producto)
        {
            var productoExistente = _productos.FirstOrDefault(p => p.Id == id);
            if (productoExistente == null)
                return NotFound();

            productoExistente.Nombre = producto.Nombre;
            productoExistente.Descripcion = producto.Descripcion;
            productoExistente.Precio = producto.Precio;
            productoExistente.Stock = producto.Stock;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = _productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
                return NotFound();

            _productos.Remove(producto);
            return NoContent();
        }
    }
} 