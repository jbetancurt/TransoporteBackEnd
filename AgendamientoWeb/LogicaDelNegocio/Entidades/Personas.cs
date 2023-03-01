using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class Personas
    {
        [Key]
        public int idPersona { get; set; }
        public int idTipoDocumento { get; set; }
        public int idCiudad { get; set; }
        public string nombrePersona { get; set; }
        public string apellidoPersona { get; set; }
        public string documentoPersona { get; set; }
        public string emailPersona { get; set; }
        public string telefonoPersona { get; set; }
        public string direccionPersona { get; set; }

    }
}
