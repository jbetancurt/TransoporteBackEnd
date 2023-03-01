using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using static AgendamientoWeb.LogicaDelNegocio.Services.CitasPorLocacionesServicios;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{

    public class CitasPorLocacionesServicios : ICitasPorLocacionesServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public CitasPorLocacionesServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Agregar(CitasPorLocaciones citasPorLocaciones)
        {
            _dbcontext.CitasPorLocaciones.Add(citasPorLocaciones);
            await _dbcontext.SaveChangesAsync();
            return citasPorLocaciones.idCitaPorLocacion;
        }

        public async Task Borrar(int idCitaPorLocacion)
        {
            var obj = await _dbcontext.CitasPorLocaciones.FirstOrDefaultAsync(x => x.idCitaPorLocacion == idCitaPorLocacion);
            _dbcontext.CitasPorLocaciones.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<CitasPorLocaciones> ConsultarPorId(int idCitaPorLocacion)
        {
            var obj = await _dbcontext.CitasPorLocaciones.FirstOrDefaultAsync(x => x.idCitaPorLocacion == idCitaPorLocacion);
            return obj == null ? new CitasPorLocaciones() : obj;

        }

        public async Task<bool> Editar(int idCitaPorLocacion, CitasPorLocaciones citasPorLocaciones)
        {
            _dbcontext.CitasPorLocaciones.Add(citasPorLocaciones);
            _dbcontext.Entry(citasPorLocaciones).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface ICitasPorLocacionesServicios
    {
         Task<int> Agregar(CitasPorLocaciones citasPorLocaciones);
         Task<bool> Editar(int idCitaPorLocacion, CitasPorLocaciones citasPorLocaciones);
         Task<CitasPorLocaciones> ConsultarPorId(int idCitaPorLocacion);
         Task Borrar(int idCitaPorLocacion);
    }
    
}
