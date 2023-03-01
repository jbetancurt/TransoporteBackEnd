using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class UbicacionesServicios : IUbicacionesServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public UbicacionesServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Agregar(Ubicaciones ubicaciones)
        {
            _dbcontext.Ubicaciones.Add(ubicaciones);
            await _dbcontext.SaveChangesAsync();
            return ubicaciones.idUbicacion;
        }

        public async Task Borrar(int idUbicacion)
        {
            var obj = await _dbcontext.Ubicaciones.FirstOrDefaultAsync(x => x.idUbicacion == idUbicacion);
            _dbcontext.Ubicaciones.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Ubicaciones> ConsultarPorId(int idUbicacion)
        {
            var obj = await _dbcontext.Ubicaciones.FirstOrDefaultAsync(x => x.idUbicacion == idUbicacion);
            return obj == null ? new Ubicaciones() : obj;
        }

        public async Task<bool> Editar(int idUbicacion, Ubicaciones ubicaciones)
        {
            _dbcontext.Ubicaciones.Add(ubicaciones);
            _dbcontext.Entry(ubicaciones).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IUbicacionesServicios
    {
        Task<int> Agregar(Ubicaciones ubicaciones);
        Task<bool> Editar(int idUbicacion, Ubicaciones ubicaciones);
        Task<Ubicaciones> ConsultarPorId(int idUbicacion);
        Task Borrar(int idUbicacion);
    }
}

