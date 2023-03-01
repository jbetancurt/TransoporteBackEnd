using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{

    public class ComplementosPersonasServicios : IComplementosPersonasServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public ComplementosPersonasServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Agregar(ComplementosPersonas complementosPersonas)
        {
            _dbcontext.ComplementosPersonas.Add(complementosPersonas);
            await _dbcontext.SaveChangesAsync();
            return complementosPersonas.idComplementoPersona;
        }

        public async Task Borrar(int idComplementoPersona)
        {
            var obj = await _dbcontext.ComplementosPersonas.FirstOrDefaultAsync(x => x.idComplementoPersona == idComplementoPersona);
            _dbcontext.ComplementosPersonas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<ComplementosPersonas> ConsultarPorId(int idComplementoPersona)
        {
            var obj = await _dbcontext.ComplementosPersonas.FirstOrDefaultAsync(x => x.idComplementoPersona == idComplementoPersona);
            return obj == null ? new ComplementosPersonas() : obj;
        }

        public async Task<bool> Editar(int idComplementoPersona, ComplementosPersonas complementosPersonas)
        {
            _dbcontext.ComplementosPersonas.Add(complementosPersonas);
            _dbcontext.Entry(complementosPersonas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IComplementosPersonasServicios
        {
            Task<int> Agregar(ComplementosPersonas complementosPersonas);
            Task<bool> Editar(int idComplementoPersona, ComplementosPersonas complementosPersonas);
            Task<ComplementosPersonas> ConsultarPorId(int idComplementoPersona);
            Task Borrar(int idComplementoPersona);
        }

    
}
