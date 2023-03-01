using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class TiposNegocios
    {
        [Key]
        public int idTipoNegocio { get; set; }
        public string nombreTipoNegocio { get; set; }
    }
}
