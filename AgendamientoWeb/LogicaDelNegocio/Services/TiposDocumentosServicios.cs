using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class TiposDocumentosServicios : ITiposDocumentosServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public TiposDocumentosServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Agregar(TiposDocumentos tiposDocumentos)
        {
            _dbcontext.TiposDocumentos.Add(tiposDocumentos);
            await _dbcontext.SaveChangesAsync();
            return tiposDocumentos.idTipoDocumento;
        }

        public async Task Borrar(int idTipoDocumento)
        {
            var obj = await _dbcontext.TiposDocumentos.FirstOrDefaultAsync(x => x.idTipoDocumento == idTipoDocumento);
            _dbcontext.TiposDocumentos.Remove(obj);
            await _dbcontext.SaveChangesAsync();

        }

        public async Task<TiposDocumentos> ConsultarPorId(int idTipoDocumento)
        {
            var obj = await _dbcontext.TiposDocumentos.FirstOrDefaultAsync(x => x.idTipoDocumento == idTipoDocumento);
            return obj == null ? new TiposDocumentos() : obj;
        }

        public async Task<bool> Editar(int idTipoDocumento, TiposDocumentos tiposDocumentos)
        {
            _dbcontext.TiposDocumentos.Add(tiposDocumentos);
            _dbcontext.Entry(tiposDocumentos).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TiposDocumentos>> ListarTiposDocumentos()
        {
            var obj = await _dbcontext.TiposDocumentos.ToListAsync();
            return obj == null ? new List<TiposDocumentos>() : obj;
        }
       
    }
    public interface ITiposDocumentosServicios
{
        Task<int> Agregar(TiposDocumentos tiposDocumentos);
        Task<bool> Editar(int idTipoDocumento, TiposDocumentos tiposDocumentos);
        Task<TiposDocumentos> ConsultarPorId(int idTipoDocumento);
        Task Borrar(int idTipoDocumento);
        Task<List<TiposDocumentos>> ListarTiposDocumentos();
    }
    
}
