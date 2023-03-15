using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class Ciudades
    {
        [Key]
        public int idCiudad { get; set; }
        public int idPais { get; set; }
        public string nombreCiudad { get; set; }
        public string codigoDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
        public string codigoCiudad { get; set; }
        
    }
    public class Departamentos
    {
        public int idPais { get; set; }
        public string codigoDepartamento { get; set; }
        public string nombreDepartamento { get; set; }
    }
}
