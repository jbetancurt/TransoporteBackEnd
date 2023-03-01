using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class Usuarios
    {
        [Key]
        public int idUsuario { get; set; }
        public int idPersona { get; set; }
        public string loginUsuario { get; set; }
        public string paswordUsuario { get; set; }
        public bool estadoUsuario { get; set; }
        public bool expiracionUsuario { get; set; }
      
    }
}
