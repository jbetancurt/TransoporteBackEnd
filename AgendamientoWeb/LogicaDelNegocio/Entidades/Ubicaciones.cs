using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class Ubicaciones
    {
        [Key]
        public int idUbicacion { get; set; }
        public string nombreUbicacion { get; set; }
        public string direccionUbicacion { get; set; }
        public string telefonoUbicacion { get; set; }
        public string observacionUbicacion { get; set; }
    }
}
