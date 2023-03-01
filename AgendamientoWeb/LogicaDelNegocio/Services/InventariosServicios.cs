using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class InventariosServicios : IInventariosServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public InventariosServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Agregar(Inventarios inventarios)
        {
            _dbcontext.Inventarios.Add(inventarios);
            await _dbcontext.SaveChangesAsync();
            return inventarios.idInventario;
        }

        public async Task Borrar(int idInventario)
        {
            var obj = await _dbcontext.Inventarios.FirstOrDefaultAsync(x => x.idInventario == idInventario);
            _dbcontext.Inventarios.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Inventarios> ConsultarPorId(int idInventario)
        {
            var obj = await _dbcontext.Inventarios.FirstOrDefaultAsync(x => x.idInventario == idInventario);
            return obj == null ? new Inventarios() : obj;
        }

        public async Task<bool> Editar(int idInventario, Inventarios inventarios)
        {
            _dbcontext.Inventarios.Add(inventarios);
            _dbcontext.Entry(inventarios).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IInventariosServicios
    {
        Task<int> Agregar(Inventarios inventarios);
        Task<bool> Editar(int idInventario, Inventarios inventarios);
        Task <Inventarios> ConsultarPorId(int idInventario);
        Task Borrar(int idInventario);
    }
}

