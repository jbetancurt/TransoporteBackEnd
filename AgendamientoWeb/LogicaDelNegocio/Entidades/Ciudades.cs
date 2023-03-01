using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class Ciudades
    {
        [Key]
        public int idCiudad { get; set; }
        public int idPais  { get; set; }
        public string nombreCiudad { get; set; }
    }
}
