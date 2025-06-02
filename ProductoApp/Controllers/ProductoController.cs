using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductoApp.Data;
using ProductoApp.Models;

namespace ProductoApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }
        //private static List<Producto> productos = new List<Producto>
        //{
        //    new Producto{Id = 1, Nombre = "Laptop", Precio = 7500, Stock = 10 },
        //    new Producto{Id = 2, Nombre = "Mouse", Precio = 150, Stock = 50 }
        //};

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetAll()
        {
            return await _context.Productos.ToListAsync();
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetById(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> Create(Producto nuevoProducto) {
            _context.Productos.Add(nuevoProducto); // Asignar un nuevo ID
            await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos
            return CreatedAtAction(nameof(GetById), new { id = nuevoProducto.Id }, nuevoProducto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Producto productoActualizado) {

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null) return NotFound();
            
            producto.Nombre = productoActualizado.Nombre;
            producto.Precio = productoActualizado.Precio;
            producto.Stock = productoActualizado.Stock;

            await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos
            return NoContent(); // 204 No Content

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) {
            var producto = await _context.Productos.FindAsync(id);

            if (producto == null) return NotFound();

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync(); // Guardar los cambios en la base de datos
            return NoContent(); // 204 No Content


        }

    }
}
