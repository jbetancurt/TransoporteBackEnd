using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class IntegrantesPorCitasServicios : IIntegrantesPorCitasServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public IntegrantesPorCitasServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Agregar(IntegrantesPorCitas integrantesPorCitas)
        {
            _dbcontext.IntegrantesPorCitas.Add(integrantesPorCitas);
            await _dbcontext.SaveChangesAsync();
            return integrantesPorCitas.idIntegrantePorCita;
        }

        public async Task Borrar(int idIntegrantePorCita)
        {
            var obj = await _dbcontext.IntegrantesPorCitas.FirstOrDefaultAsync(x => x.idIntegrantePorCita == idIntegrantePorCita);
            _dbcontext.IntegrantesPorCitas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<IntegrantesPorCitas> ConsultarPorId(int idIntegrantePorCita)
        {
            var obj = await _dbcontext.IntegrantesPorCitas.FirstOrDefaultAsync(x => x.idIntegrantePorCita == idIntegrantePorCita);
            return obj == null ? new IntegrantesPorCitas() : obj;

        }

        public async Task<bool> Editar(int idIntegrantePorCita, IntegrantesPorCitas integrantesPorCitas)
        {
            _dbcontext.IntegrantesPorCitas.Add(integrantesPorCitas);
            _dbcontext.Entry(integrantesPorCitas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IIntegrantesPorCitasServicios
    {
        Task<int> Agregar(IntegrantesPorCitas integrantesPorCitas);
        Task<bool> Editar(int idIntegrantePorCita, IntegrantesPorCitas integrantesPorCitas);
        Task<IntegrantesPorCitas> ConsultarPorId(int idIntegrantePorCita);
        Task Borrar(int idIntegrantePorCita);
    }

}

