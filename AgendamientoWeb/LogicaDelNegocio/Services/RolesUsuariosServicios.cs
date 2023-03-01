using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class RolesUsuariosServicios : IRolesUsuariosServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public RolesUsuariosServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Agregar(RolesUsuarios rolesUsuarios)
        {
            _dbcontext.RolesUsuarios.Add(rolesUsuarios);
            await _dbcontext.SaveChangesAsync();
            return rolesUsuarios.idRolUsuario;

        }

        public async Task Borrar(int idRolUsuario)
        {
            var obj = await _dbcontext.RolesUsuarios.FirstOrDefaultAsync(x => x.idRolUsuario == idRolUsuario);
            _dbcontext.RolesUsuarios.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<RolesUsuarios> ConsultarPorId(int idRolUsuario)
        {
            var obj = await _dbcontext.RolesUsuarios.FirstOrDefaultAsync(x => x.idRolUsuario == idRolUsuario);
            return obj == null ? new RolesUsuarios() : obj;
        }

        public async Task<bool> Editar(int idRolUsuario, RolesUsuarios rolesUsuarios)
        {
            _dbcontext.RolesUsuarios.Add(rolesUsuarios);
            _dbcontext.Entry(rolesUsuarios).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IRolesUsuariosServicios
    {
        Task<int> Agregar(RolesUsuarios rolesUsuarios);
        Task<bool> Editar(int idRolUsuario, RolesUsuarios rolesUsuarios);
        Task<RolesUsuarios> ConsultarPorId(int idRolUsuario);
        Task Borrar(int idRolUsuario);
    }

}

