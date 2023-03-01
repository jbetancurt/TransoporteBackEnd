using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class ServiciosServicios : IServiciosServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public ServiciosServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Agregar(Servicios servicios)
        {
            _dbcontext.Servicios.Add(servicios);
            await _dbcontext.SaveChangesAsync();
            return servicios.idServicio;
        }

        public async Task Borrar(int idServicio)
        {
            var obj = await _dbcontext.Servicios.FirstOrDefaultAsync(x => x.idServicio == idServicio);
            _dbcontext.Servicios.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Servicios> ConsultarPorId(int idServicio)
        {
            var obj = await _dbcontext.Servicios.FirstOrDefaultAsync(x => x.idServicio == idServicio);
            return obj == null ? new Servicios() : obj;
        }

        public async Task<bool> Editar(int idServicio, Servicios servicios)
        {
            _dbcontext.Servicios.Add(servicios);
            _dbcontext.Entry(servicios).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;

        }
    }
    public interface IServiciosServicios
    {
        Task<int> Agregar(Servicios servicios);
        Task<bool> Editar(int idServicio, Servicios servicios);
        Task<Servicios> ConsultarPorId(int idServicio);
        Task Borrar(int idServicio);
    }

}

