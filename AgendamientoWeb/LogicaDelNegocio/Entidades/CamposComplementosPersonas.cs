using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class CamposComplementosPersonas
    {
        [Key]
        public int idCampoComplementoPersona { get; set; }
        public int idEmpresa { get; set; }
        public string nombreCampoComplementoPersona { get; set; }
        public string tipoCampoComplementoPersona { get; set; }

    }
}
