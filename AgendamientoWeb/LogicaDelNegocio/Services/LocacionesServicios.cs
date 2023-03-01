using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class LocacionesServicios : ILocacionesServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public LocacionesServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Agregar(Locaciones locaciones)
        {
            _dbcontext.Locaciones.Add(locaciones);
            await _dbcontext.SaveChangesAsync();
            return locaciones.idLocacion;
        }

        public async Task Borrar(int idLocacion)
        {
            var obj = await _dbcontext.Locaciones.FirstOrDefaultAsync(x => x.idLocacion == idLocacion);
            _dbcontext.Locaciones.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Locaciones> ConsultarPorId(int idLocacion)
        {
            var obj = await _dbcontext.Locaciones.FirstOrDefaultAsync(x => x.idLocacion == idLocacion);
            return obj == null ? new Locaciones() : obj;
        }

        public async Task<bool> Editar(int idLocacion, Locaciones locaciones)
        {
            _dbcontext.Locaciones.Add(locaciones);
            _dbcontext.Entry(locaciones).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface ILocacionesServicios
    {
        Task<int> Agregar(Locaciones locaciones);
        Task<bool> Editar(int idLocacion, Locaciones locaciones);
        Task<Locaciones> ConsultarPorId(int idLocacion);
        Task Borrar(int idLocacion);
    }

}

