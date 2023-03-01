using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class ComplementosPersonas
    {
        [Key]
        public int idComplementoPersona { get; set; }
        public int idPersona { get; set; }
        public int idCampoComplementoPersona { get; set; }
        public string valor { get; set; }
    }
}
