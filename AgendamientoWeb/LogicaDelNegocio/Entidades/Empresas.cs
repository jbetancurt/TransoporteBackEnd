using System.ComponentModel.DataAnnotations;

namespace AgendamientoWeb.LogicaDelNegocio.Entidades
{
    public class Empresas
    {
        [Key]
        public int idEmpresa { get; set; } 
        public int idCiudad { get; set; } 
        public int idTipoNegocio { get; set; } 
        public int idPersonaResponsable { get; set; } 
        public int idTipoDocumento { get; set; } 
        public string razonSocialEmpresa { get; set; } 
        public string documentoEmpresa { get; set; } 
        public string emailEmpresa { get; set; } 
        public string telefonoEmpresa { get; set;} 
        public string direccionEmpresa { get;set; } 

        public string rutaEmpresa { get; set; }

    }
}
