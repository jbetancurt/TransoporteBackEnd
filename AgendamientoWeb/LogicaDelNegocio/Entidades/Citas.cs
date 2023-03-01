using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class Citas
    {
        [Key]
        public int idCita { get; set; }
        public int idPersona { get; set; }
        public DateTime fecha { get; set; }
        public DateTime horaInicial { get; set; }
        public DateTime horaFinal { get; set; }
        public string estadoCita { get; set; }
        public string descripcion { get; set; }
    }
}
