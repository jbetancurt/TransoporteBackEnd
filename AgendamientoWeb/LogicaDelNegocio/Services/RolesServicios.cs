using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class RolesServicios : IRolesServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public RolesServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Agregar(Roles roles)
        {
            _dbcontext.Roles.Add(roles);
            await _dbcontext.SaveChangesAsync();
            return roles.idRol;
        }

        public async Task Borrar(int idRol)
        {
            var obj = await _dbcontext.Roles.FirstOrDefaultAsync(x => x.idRol == idRol);
            _dbcontext.Roles.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Roles> ConsultarPorId(int idRol)
        {
            var obj = await _dbcontext.Roles.FirstOrDefaultAsync(x => x.idRol == idRol);
            return obj == null ? new Roles() : obj;
        }

        public async Task<bool> Editar(int idRol, Roles roles)
        {
            _dbcontext.Roles.Add(roles);
            _dbcontext.Entry(roles).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IRolesServicios
    {
        Task<int> Agregar(Roles roles);
        Task<bool> Editar(int idRol, Roles roles);
        Task<Roles> ConsultarPorId(int idRol);
        Task Borrar(int idRol);
    }
}

