using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class ProgramacionesDeServicios
    {
        [Key]
        public int idProgramacionDeServicio { get; set; }
        public int idPersona { get; set; }
        public int idServicio { get; set; }
        public DateTime fecha { get; set; }
        public DateTime horaInicial { get; set; }
        public DateTime horaFinal { get; set; }
        public string cupo { get; set; }

    }
}
