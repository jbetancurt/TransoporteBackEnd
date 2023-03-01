using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class Locaciones
    {
        [Key]
        public int idLocacion { get; set; }
        public int idUbicacion { get; set; }
        public string nombreLocacion { get; set; }
        public string observacionLocacion { get; set; }
    }
}
