using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class PersonasPorEmpresas
    {
        [Key]
        public int idPersonaPorEmpresa { get; set; }
        public int idPersona { get; set; }
        public int idEmpresa { get; set; }
        public string tipoUsuario { get; set; }
                
    }
}


