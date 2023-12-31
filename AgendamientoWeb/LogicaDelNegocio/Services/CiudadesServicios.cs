﻿using AgendamientoWeb.LogicaDelNegocio.DbContexts;
using AgendamientoWeb.LogicaDelNegocio.Entidades;
using Microsoft.EntityFrameworkCore;
using static AgendamientoWeb.LogicaDelNegocio.Services.CiudadesServicios;

namespace AgendamientoWeb.LogicaDelNegocio.Services
{
    public class CiudadesServicios : ICiudadesServicios
    {
        protected readonly AgendamientoWebDbContext _dbcontext;

        public CiudadesServicios(AgendamientoWebDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<int> Agregar(Ciudades ciudades)
        {
            _dbcontext.Ciudades.Add(ciudades);
            await _dbcontext.SaveChangesAsync();
            return ciudades.idCiudad;
        }

        public async Task Borrar(int idCiudad)
        {
            var obj = await _dbcontext.Ciudades.FirstOrDefaultAsync(x => x.idCiudad == idCiudad);
            _dbcontext.Ciudades.Remove(obj);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<Ciudades> ConsultarPorId(int idCiudad)
        {
            var obj = await _dbcontext.Ciudades.FirstOrDefaultAsync(x => x.idCiudad == idCiudad);
            return obj == null ? new Ciudades() : obj;

        }

        public async Task<bool> Editar(int idCiudad, Ciudades ciudades)
        {
            _dbcontext.Ciudades.Add(ciudades);
            _dbcontext.Entry(ciudades).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Ciudades>> ListarCiudadesPorDepartamento(string codigoDepartamento)
        {
            var obj = await _dbcontext.Ciudades.Where(x => x.codigoDepartamento == codigoDepartamento).ToListAsync();
            return obj == null ? new List<Ciudades>() : obj;
        }

        public async Task<List<Departamentos>> ListarDepartamentosPorPais(int idPais)
        {
            var obj = await _dbcontext.Ciudades.Where(x=> x.idPais == idPais).Select(x => new Departamentos()
            {
                idPais = x.idPais,
                codigoDepartamento = x.codigoDepartamento,
                nombreDepartamento = x.nombreDepartamento
            }
            ).Distinct().ToListAsync();
            return obj == null ? new List<Departamentos>() : obj;
        }

        
    }
    public interface ICiudadesServicios
    {
        Task<int> Agregar(Ciudades ciudades);
        Task<bool> Editar(int idCiudad, Ciudades ciudades);
        Task<Ciudades> ConsultarPorId(int idCiudad);
        Task Borrar(int idCiudad);
        Task<List<Departamentos>> ListarDepartamentosPorPais(int idPais);
        Task<List<Ciudades>> ListarCiudadesPorDepartamento(string codigoDepartamento);
    } 

}
