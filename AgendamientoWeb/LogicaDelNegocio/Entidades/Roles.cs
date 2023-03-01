using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class Roles
    {
        [Key]
        public int idRol { get; set; }
        public string nombreRol { get; set; }
    }
}
