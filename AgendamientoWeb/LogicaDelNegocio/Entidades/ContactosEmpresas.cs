using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class ContactosEmpresas
    {
        [Key]
        public int idContactoEmpresa { get; set; }
        public string nombreContactoEmpresa { get; set; }
    }
}
