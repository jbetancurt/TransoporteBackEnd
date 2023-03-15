using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{

    public class TiposNegociosServicios : ITiposNegociosServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public TiposNegociosServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<int> Agregar(TiposNegocios tiposNegocios)
        {
            _dbcontext.TiposNegocios.Add(tiposNegocios);
            await _dbcontext.SaveChangesAsync();
            return tiposNegocios.idTipoNegocio;
        }

        public async Task Borrar(int idTipoNegocio)
        {
            var obj = await _dbcontext.TiposNegocios.FirstOrDefaultAsync(x => x.idTipoNegocio == idTipoNegocio);
            _dbcontext.TiposNegocios.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<TiposNegocios> ConsultarPorId(int idTipoNegocio)
        {
            var obj = await _dbcontext.TiposNegocios.FirstOrDefaultAsync(x => x.idTipoNegocio == idTipoNegocio);
            return obj == null ? new TiposNegocios() : obj;
        }

        public async Task<bool> Editar(int idTipoNegocio, TiposNegocios tiposNegocios)
        {
            _dbcontext.TiposNegocios.Add(tiposNegocios);
            _dbcontext.Entry(tiposNegocios).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<TiposNegocios>> ListarTiposNegocios()
        {
            var obj = await _dbcontext.TiposNegocios.ToListAsync();
            return obj == null ? new List<TiposNegocios>() : obj;
        }

        
    }
    public interface ITiposNegociosServicios
        {
            Task<int> Agregar(TiposNegocios tiposNegocios);
            Task<bool> Editar(int idTipoNegocio, TiposNegocios tiposNegocios);
            Task<TiposNegocios> ConsultarPorId(int idTipoNegocio);
            Task Borrar(int idTipoNegocio);
            Task<List<TiposNegocios>> ListarTiposNegocios();
    }
    
}
