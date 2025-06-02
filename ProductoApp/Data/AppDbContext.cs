using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using ProductoApp.Models;

namespace ProductoApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
    }
}
