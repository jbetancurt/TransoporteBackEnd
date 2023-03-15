using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class Paises
    {
        [Key]
        public int idPais { get; set; }
        public string nombrePais { get; set; }
        public string codigoPais { get; set; }
        public string iso2 { get; set; }
        public string iso3 { get; set; }

    }
}
