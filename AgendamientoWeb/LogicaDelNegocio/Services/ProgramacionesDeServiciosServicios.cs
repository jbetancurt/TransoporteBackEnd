using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class ProgramacionesDeServiciosServicios : IProgramacionesDeServiciosServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public ProgramacionesDeServiciosServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Agregar(ProgramacionesDeServicios programacionesDeServicios)
        {
            _dbcontext.ProgramacionesDeServicios.Add(programacionesDeServicios);
            await _dbcontext.SaveChangesAsync();
            return programacionesDeServicios.idProgramacionDeServicio;
        }

        public async Task Borrar(int idProgramacionDeServicio)
        {
            var obj = await _dbcontext.ProgramacionesDeServicios.FirstOrDefaultAsync(x => x.idProgramacionDeServicio == idProgramacionDeServicio);
            _dbcontext.ProgramacionesDeServicios.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<ProgramacionesDeServicios> ConsultarPorId(int idProgramacionDeServicio)
        {
            var obj = await _dbcontext.ProgramacionesDeServicios.FirstOrDefaultAsync(x => x.idProgramacionDeServicio == idProgramacionDeServicio);
            return obj == null ? new ProgramacionesDeServicios() : obj;
        }

        public async Task<bool> Editar(int idProgramacionDeServicio, ProgramacionesDeServicios programacionesDeServicios)
        {
            _dbcontext.ProgramacionesDeServicios.Add(programacionesDeServicios);
            _dbcontext.Entry(programacionesDeServicios).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IProgramacionesDeServiciosServicios
    {
        Task<int> Agregar(ProgramacionesDeServicios programacionesDeServicios);
        Task<bool> Editar(int idProgramacionDeServicio, ProgramacionesDeServicios programacionesDeServicios);
        Task<ProgramacionesDeServicios> ConsultarPorId(int idProgramacionDeServicio);
        Task Borrar(int idProgramacionDeServicio);
    }
}

