using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class EmpresasServicios : IEmpresasServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public EmpresasServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Agregar(Empresas empresas)
        {
            _dbcontext.Empresas.Add(empresas);
            await _dbcontext.SaveChangesAsync();
            return empresas.idEmpresa;
        }

        public async Task Borrar(int idEmpresa)
        {
            var obj = await _dbcontext.Empresas.FirstOrDefaultAsync(x => x.idEmpresa == idEmpresa);
            _dbcontext.Empresas.Remove(obj);
            await _dbcontext.SaveChangesAsync();

        }

        public async Task<Empresas> ConsultarPorId(int idEmpresa)
        {
            var obj = await _dbcontext.Empresas.FirstOrDefaultAsync(x => x.idEmpresa == idEmpresa);
            return obj == null ? new Empresas() : obj;
        }

        public async Task<Empresas> ConsultarPorRutaEmpresa(string rutaempresa)
        {
            var obj = await _dbcontext.Empresas.FirstOrDefaultAsync(x => x.rutaEmpresa == rutaempresa);
            return obj == null ? new Empresas() : obj;
        }

        public async Task<Empresas> ConsultarPorDocumentoEmpresa(int idTipoDocumentoEmpresa, string documentoEmpresa)
        {
            var obj = await _dbcontext.Empresas.FirstOrDefaultAsync(x => x.idTipoDocumento == idTipoDocumentoEmpresa && x.documentoEmpresa == documentoEmpresa);
            return obj == null ? new Empresas() : obj;
        }

        public async Task<bool> Editar(int idEmpresa, Empresas empresas)
        {
            _dbcontext.Empresas.Add(empresas);
            _dbcontext.Entry(empresas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }
    }
    public interface IEmpresasServicios
    {
        Task<int> Agregar(Empresas empresas);
        Task<bool> Editar(int idEmpresa, Empresas empresas);
        Task<Empresas> ConsultarPorId(int idEmpresa);
        Task<Empresas> ConsultarPorDocumentoEmpresa(int idTipoDocumentoEmpresa, string documentoEmpresa);

        Task<Empresas> ConsultarPorRutaEmpresa(string rutaempresa);
        
        Task Borrar(int idEmpresa);
    }

}
