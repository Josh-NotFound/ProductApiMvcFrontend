namespace ProductoApp.Models
{
    public class Producto
    {
        public int Id { get; set; } // identificador unico
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }
}
