using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{

    public class CitasPorProgramacionesDeServiciosServicios : ICitasPorProgramacionesDeServiciosServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public CitasPorProgramacionesDeServiciosServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        
        public async Task<int> Agregar(CitasPorProgramacionesDeServicios citasPorProgramacionesDeServicios)
        {
            _dbcontext.CitasPorProgramacionesDeServicios.Add(citasPorProgramacionesDeServicios);
            await _dbcontext.SaveChangesAsync();
            return citasPorProgramacionesDeServicios.idCitaPorProgramacionDeServicio;
        }

        public async Task Borrar(int idCitaPorProgramacionDeServicio)
        {
            var obj = await _dbcontext.CitasPorProgramacionesDeServicios.FirstOrDefaultAsync(x => x.idCitaPorProgramacionDeServicio == idCitaPorProgramacionDeServicio);
            _dbcontext.CitasPorProgramacionesDeServicios.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<CitasPorProgramacionesDeServicios> ConsultarPorId(int idCitaPorProgramacionDeServicio)
        {
            var obj = await _dbcontext.CitasPorProgramacionesDeServicios.FirstOrDefaultAsync(x => x.idCitaPorProgramacionDeServicio == idCitaPorProgramacionDeServicio);
            return obj == null ? new CitasPorProgramacionesDeServicios() : obj;

        }

        public async Task<bool> Editar(int idCitaPorProgramacionDeServicio, CitasPorProgramacionesDeServicios citasPorProgramacionesDeServicios)
        {
            _dbcontext.CitasPorProgramacionesDeServicios.Add(citasPorProgramacionesDeServicios);
            _dbcontext.Entry(citasPorProgramacionesDeServicios).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface ICitasPorProgramacionesDeServiciosServicios
    {
       Task<int> Agregar(CitasPorProgramacionesDeServicios citasPorProgramacionesDeServicios);
       Task<bool> Editar(int idCitaPorProgramacionDeServicio, CitasPorProgramacionesDeServicios citasPorProgramacionesDeServicios);
       Task<CitasPorProgramacionesDeServicios> ConsultarPorId(int idCitaPorProgramacionDeServicio);
       Task Borrar(int idCitaPorProgramacionDeServicio);
    }

    
}
