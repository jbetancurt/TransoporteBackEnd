using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class ContactosEmpresasServicios : IContactosEmpresasServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public ContactosEmpresasServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Agregar(ContactosEmpresas contactosEmpresas)
        {
            _dbcontext.ContactosEmpresas.Add(contactosEmpresas);
            await _dbcontext.SaveChangesAsync();
            return contactosEmpresas.idContactoEmpresa;
        }

        public async Task Borrar(int idContactoEmpresa)
        {
            var obj = await _dbcontext.ContactosEmpresas.FirstOrDefaultAsync(x => x.idContactoEmpresa == idContactoEmpresa);
            _dbcontext.ContactosEmpresas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<ContactosEmpresas> ConsultarPorId(int idContactoEmpresa)
        {
            var obj = await _dbcontext.ContactosEmpresas.FirstOrDefaultAsync(x => x.idContactoEmpresa == idContactoEmpresa);
            return obj == null ? new ContactosEmpresas() : obj;
        }
        
        public async Task<bool> Editar(int idContactoEmpresa, ContactosEmpresas contactosEmpresas)
        {
            _dbcontext.ContactosEmpresas.Add(contactosEmpresas);
            _dbcontext.Entry(contactosEmpresas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IContactosEmpresasServicios
    {
        Task<int> Agregar(ContactosEmpresas contactosEmpresas);
        Task<bool> Editar(int idContactoEmpresa, ContactosEmpresas contactosEmpresas);
        Task<ContactosEmpresas> ConsultarPorId(int idContactoEmpresa);
        Task Borrar(int idContactoEmpresa);
    }

}

