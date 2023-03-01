using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class PersonasServicios : IPersonasServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public PersonasServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Agregar(Personas personas)
        {
            _dbcontext.Personas.Add(personas);
            await _dbcontext.SaveChangesAsync();
            return personas.idPersona;

        }

        public async Task Borrar(int idPersona)
        {
            var obj = await _dbcontext.Personas.FirstOrDefaultAsync(x => x.idPersona == idPersona);
            _dbcontext.Personas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Personas> ConsultarPorId(int idPersona)
        {
            var obj = await _dbcontext.Personas.FirstOrDefaultAsync(x => x.idPersona == idPersona);
            return obj == null ? new Personas() : obj;
        }

        public async Task<bool> Editar(int idPersona, Personas personas)
        {
            _dbcontext.Personas.Add(personas);
            _dbcontext.Entry(personas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IPersonasServicios
    {
        Task<int> Agregar(Personas personas);
        Task<bool> Editar(int idPersona, Personas personas);
        Task<Personas> ConsultarPorId(int idPersona);
        Task Borrar(int idPersona);
    }
}

