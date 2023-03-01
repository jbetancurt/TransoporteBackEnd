using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class Inventarios
    {
        [Key]
        public int idInventario { get; set; }
        public int idUbicacion { get; set; }
        public string codigoProducto { get; set; }
        public string nombreProducto { get; set; }
        public int cantidadProducto { get; set; }
    }
}
