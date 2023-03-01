using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class RolesUsuarios
    {
        [Key]
        public int idRolUsuario { get; set; }
        public int idRol { get; set; }
        public int idUsuario { get; set; }
    }
}
