using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class TiposDocumentos
    {
        [Key]
        public int idTipoDocumento { get; set; }
        public string nombreDocumento { get; set; }
    }
}
