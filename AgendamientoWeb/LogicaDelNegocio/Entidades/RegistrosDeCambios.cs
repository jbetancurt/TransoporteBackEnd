using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class RegistrosDeCambios
    {
        [Key]
        public int idRegistroDeCambio { get; set; }
        public int idEmpresa { get; set; }
        public int idUsuario { get; set; }
        public int idPersona { get; set; }
        public DateTime fechaAccion { get; set; }
        public string valorActual { get; set; }
        public string valorAnterior { get; set; }
        public string tipoAccion { get; set; }
    }
}
