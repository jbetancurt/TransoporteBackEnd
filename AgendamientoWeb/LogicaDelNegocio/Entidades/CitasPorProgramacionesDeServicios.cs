using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class CitasPorProgramacionesDeServicios
    {
        [Key]
        public int idCitaPorProgramacionDeServicio { get; set; }
        public int idCita { get; set; }
        public int idProgramacionDeServicio { get; set; }


    }
}
