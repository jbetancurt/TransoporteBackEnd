using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class PersonasPorEmpresasServicios : IPersonasPorEmpresasServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public PersonasPorEmpresasServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Agregar(PersonasPorEmpresas personasPorEmpresas)
        {
            object value = _dbcontext.PersonasPorEmpresas.Add(personasPorEmpresas);
            await _dbcontext.SaveChangesAsync();
            return personasPorEmpresas.idPersonaPorEmpresa;
        }

        public async Task Borrar(int idPersonaPorEmpresa)
        {
            var obj = await _dbcontext.PersonasPorEmpresas.FirstOrDefaultAsync(x => x.idPersonaPorEmpresa == idPersonaPorEmpresa);
            _dbcontext.PersonasPorEmpresas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<PersonasPorEmpresas> ConsultarPorId(int idPersonaPorEmpresa)
        {
            var obj = await _dbcontext.PersonasPorEmpresas.FirstOrDefaultAsync(x => x.idPersonaPorEmpresa == idPersonaPorEmpresa);
            return obj == null ? new PersonasPorEmpresas() : obj;

        }


        public async Task<PersonasPorEmpresas> ConsultarPorIdPersonayIdEmpresa(int idEmpresa, int idPersona)
        {
            var obj = await _dbcontext.PersonasPorEmpresas.FirstOrDefaultAsync(x => x.idEmpresa == idEmpresa && x.idPersona == idPersona);
            return obj == null ? new PersonasPorEmpresas() : obj;

        }
        public async Task<bool> Editar(int idPersonaPorEmpresa, PersonasPorEmpresas personasPorEmpresas)
        {
            _dbcontext.PersonasPorEmpresas.Add(personasPorEmpresas);
            _dbcontext.Entry(personasPorEmpresas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }

    public interface IPersonasPorEmpresasServicios
    {
        Task<int> Agregar(PersonasPorEmpresas personasPorEmpresas);
        Task<bool> Editar(int idPersonaPorEmpresa, PersonasPorEmpresas personasPorEmpresas);
        Task<PersonasPorEmpresas> ConsultarPorId(int idPersonaPorEmpresa);

        Task<PersonasPorEmpresas> ConsultarPorIdPersonayIdEmpresa(int idEmpresa, int idPersona);
        Task Borrar(int idPersonaPorEmpresa);
    }
}

