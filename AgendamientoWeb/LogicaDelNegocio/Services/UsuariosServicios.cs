using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class UsuariosServicios : IUsuariosServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public UsuariosServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Agregar(Usuarios usuarios)
        {
            _dbcontext.Usuarios.Add(usuarios);
            await _dbcontext.SaveChangesAsync();
            return usuarios.idUsuario;
        }

        public async Task Borrar(int idUsuario)
        {
            var obj = await _dbcontext.Usuarios.FirstOrDefaultAsync(x => x.idUsuario == idUsuario);
            _dbcontext.Usuarios.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Usuarios> ConsultarPorId(int idUsuario)
        {
            var obj = await _dbcontext.Usuarios.FirstOrDefaultAsync(x => x.idUsuario == idUsuario);
            return obj == null ? new Usuarios() : obj;
        }

        public async Task<bool> Editar(int idUsuario, Usuarios usuarios)
        {
            _dbcontext.Usuarios.Add(usuarios);
            _dbcontext.Entry(usuarios).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IUsuariosServicios
    {
        Task<int> Agregar(Usuarios usuarios);
        Task<bool> Editar(int idUsuario, Usuarios usuarios);
        Task<Usuarios> ConsultarPorId(int idUsuario);
        Task Borrar(int idUsuario);
    }
}

