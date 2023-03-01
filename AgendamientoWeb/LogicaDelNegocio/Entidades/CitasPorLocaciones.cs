using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class CitasPorLocaciones
    {
        [Key]
        public int idCitaPorLocacion { get; set; }
        public int idCita { get; set; }
        public int idLocacion { get; set; }
    }
}
