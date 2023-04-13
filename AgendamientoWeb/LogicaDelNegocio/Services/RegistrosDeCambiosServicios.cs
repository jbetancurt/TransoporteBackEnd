using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class RegistrosDeCambiosServicios : IRegistrosDeCambiosServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public RegistrosDeCambiosServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Agregar(RegistrosDeCambios registrosDeCambios)
        {
            _dbcontext.RegistrosDeCambios.Add(registrosDeCambios);
            await _dbcontext.SaveChangesAsync();
            return registrosDeCambios.idRegistroDeCambio;
        }

        public async Task Borrar(int idRegistroDeCambio)
        {
            var obj = await _dbcontext.RegistrosDeCambios.FirstOrDefaultAsync(x => x.idRegistroDeCambio == idRegistroDeCambio);
            _dbcontext.RegistrosDeCambios.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<RegistrosDeCambios> ConsultarPorId(int idRegistroDeCambio)
        {
            var obj = await _dbcontext.RegistrosDeCambios.FirstOrDefaultAsync(x => x.idRegistroDeCambio == idRegistroDeCambio);
            return obj == null ? new RegistrosDeCambios() : obj;

        }

        public async Task<bool> Editar(int idRegistroDeCambio, RegistrosDeCambios registrosDeCambios)
        {
            _dbcontext.RegistrosDeCambios.Add(registrosDeCambios);
            _dbcontext.Entry(registrosDeCambios).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task AgregarRegistroCambio(int idEmpresa, int idUsuario, int idPersona, object valorActual, object valorAnterior, string tipoAccion)
        {
            _dbcontext.RegistrosDeCambios.Add(new RegistrosDeCambios()
            {
                fechaAccion = DateTime.Now,
                idEmpresa = idEmpresa,
                idUsuario = idUsuario,
                idPersona = idPersona,
                tipoAccion = tipoAccion,
                valorActual = JsonConvert.SerializeObject(valorActual),
                valorAnterior = JsonConvert.SerializeObject(valorAnterior)
            });
            await _dbcontext.SaveChangesAsync();
        }
    }
    public interface IRegistrosDeCambiosServicios
    {
        Task<int> Agregar(RegistrosDeCambios registrosDeCambios);
        Task<bool> Editar(int idRegistroDeCambio, RegistrosDeCambios registrosDeCambios);
        Task<RegistrosDeCambios> ConsultarPorId(int idRegistroDeCambio);
        Task Borrar(int idRegistroDeCambio);
        Task AgregarRegistroCambio(int idEmpresa, int idUsuario, int idPersona, object valorActual, object valorAnterior, string tipoAccion);
    }
}

