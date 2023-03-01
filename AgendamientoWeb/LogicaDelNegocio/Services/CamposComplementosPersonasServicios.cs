using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class CamposComplementosPersonasServicios : ICamposComplementosPersonasServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;
        public CamposComplementosPersonasServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Agregar(CamposComplementosPersonas camposComplementosPersonas)
        {
            _dbcontext.CamposComplementosPersonas.Add(camposComplementosPersonas);
             await _dbcontext.SaveChangesAsync();
            return camposComplementosPersonas.idCampoComplementoPersona;
                       
        }

        public async Task Borrar(int idCampoComplementoPersona)
        {
            var obj= await _dbcontext.CamposComplementosPersonas.FirstOrDefaultAsync(x => x.idCampoComplementoPersona == idCampoComplementoPersona);
            _dbcontext.CamposComplementosPersonas.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<CamposComplementosPersonas> ConsultarPorId(int idCampoComplementoPersona)
        {
            var obj = await _dbcontext.CamposComplementosPersonas.FirstOrDefaultAsync(x => x.idCampoComplementoPersona == idCampoComplementoPersona);
            return obj == null ? new CamposComplementosPersonas() : obj;
        }
        public async Task<bool> Editar(int idCampoComplementoPersona, CamposComplementosPersonas camposComplementosPersonas)
        {

            _dbcontext.CamposComplementosPersonas.Add(camposComplementosPersonas);
            _dbcontext.Entry(camposComplementosPersonas).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;   
        }
    }
    public interface ICamposComplementosPersonasServicios
    {
        Task<int>  Agregar(CamposComplementosPersonas camposComplementosPersonas);
        Task<bool> Editar(int idCampoComplementoPersona, CamposComplementosPersonas camposComplementosPersonas);
        Task<CamposComplementosPersonas> ConsultarPorId(int idCampoComplementoPersona);
        Task Borrar(int idCampoComplementoPersona);
    }
}
