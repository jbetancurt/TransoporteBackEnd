using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class IntegrantesPorCitas
    {
        [Key]
        public int idIntegrantePorCita { get; set; }
        public int idCita { get; set; }
        public int idLocacion { get; set; }
    }

}



