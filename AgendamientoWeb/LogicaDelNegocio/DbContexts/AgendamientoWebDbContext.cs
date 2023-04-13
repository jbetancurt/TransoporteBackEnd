using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.DbContexts
{
    public class AgendamientoWebDbContext : DbContext
    {
        public DbSet<CamposComplementosPersonas> CamposComplementosPersonas { get; set; }
        public DbSet<Citas> Citas { get; set; }
        public DbSet<CitasPorLocaciones> CitasPorLocaciones { get; set; }
        public DbSet<CitasPorProgramacionesDeServicios> CitasPorProgramacionesDeServicios { get; set; }
        public DbSet<Ciudades> Ciudades { get; set; }
        public DbSet<ComplementosPersonas> ComplementosPersonas { get; set; }
        public DbSet<ContactosEmpresas> ContactosEmpresas { get; set; }
        public DbSet<Empresas> Empresas { get; set; }
        public DbSet<IntegrantesPorCitas> IntegrantesPorCitas { get; set; }
        public DbSet<Inventarios> Inventarios { get; set; }
        public DbSet<Locaciones> Locaciones { get; set; }
        public DbSet<Paises> Paises { get; set; }
        public DbSet<Personas> Personas { get; set; }
        public DbSet<PersonasPorEmpresas> PersonasPorEmpresas { get; set; }
        public DbSet<RegistrosDeCambios> RegistrosDeCambios { get; set; }

        public DbSet<ProgramacionesDeServicios> ProgramacionesDeServicios { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<RolesUsuarios> RolesUsuarios { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<TiposDocumentos> TiposDocumentos { get; set; }
        public DbSet<TiposNegocios> TiposNegocios { get; set; }
        public DbSet<Ubicaciones> Ubicaciones { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        
        //OracleDBContext
        public AgendamientoWebDbContext(DbContextOptions<AgendamientoWebDbContext> options) : base(options)
        {
        }
    }
}
