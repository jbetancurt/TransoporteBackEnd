using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;


namespace AgendamientoWeb.LogicaDelNegocio.Services
{

    public class CitasServicios : ICitasServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public CitasServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Agregar(Citas citas)
        {
            _dbcontext.Citas.Add(citas);
            await _dbcontext.SaveChangesAsync();
            return citas.idCita;
        }

        public async Task Borrar(int idCita)
        {
            var obj = await _dbcontext.Citas.FirstOrDefaultAsync(x => x.idCita == idCita);
            _dbcontext.Citas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Citas> ConsultarPorId(int idCita)
        {
            var obj = await _dbcontext.Citas.FirstOrDefaultAsync(x => x.idCita == idCita);
            return obj == null ? new Citas() : obj;

        }

        public async Task<bool> Editar(int idCita, Citas citas)
        {
            _dbcontext.Citas.Add(citas);
            _dbcontext.Entry(citas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface ICitasServicios
    {
         Task<int> Agregar(Citas citas);
         Task<bool> Editar(int idCita, Citas citas);
         Task<Citas> ConsultarPorId(int idCita);
         Task Borrar(int idCita);
    }
    
}
