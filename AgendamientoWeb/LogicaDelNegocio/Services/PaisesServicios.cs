using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class PaisesServicios : IPaisesServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public PaisesServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Agregar(Paises paises)
        {
            _dbcontext.Paises.Add(paises);
            await _dbcontext.SaveChangesAsync();
            return paises.idPais;
        }

        public async Task Borrar(int idPais)
        {
            var obj = await _dbcontext.Paises.FirstOrDefaultAsync(x => x.idPais == idPais);
            _dbcontext.Paises.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Paises> ConsultarPorId(int idPais)
        {
            var obj = await _dbcontext.Paises.FirstOrDefaultAsync(x => x.idPais == idPais);
            return obj == null ? new Paises() : obj;
        }

        public async Task<bool> Editar(int idPais, Paises paises)
        {
            _dbcontext.Paises.Add(paises);
            _dbcontext.Entry(paises).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Paises>> ListarTodos()
        {
            var obj = await _dbcontext.Paises.ToListAsync();
            return obj == null ? new List<Paises>() : obj;
            
        }
    }
    public interface IPaisesServicios
    {
        Task<int> Agregar(Paises paises);
        Task<bool> Editar(int idPais, Paises paises);
        Task<Paises> ConsultarPorId(int idPais);
        Task Borrar(int idPais);
        Task<List<Paises>> ListarTodos();
    }
    
}

