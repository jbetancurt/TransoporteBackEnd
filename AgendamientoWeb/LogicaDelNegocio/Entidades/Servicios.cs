using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class Servicios
    {
        [Key]
        public int idServicio { get; set; } 
        public int idEmpresa { get; set; }
        public string nombreServicio { get; set; }
        public int duracionServicio { get; set; }
        public int cupoServicio { get; set; }
    }
}
