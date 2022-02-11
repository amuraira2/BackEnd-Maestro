using Datos.ModelosBusqueda;
using Datos.ModelosBusqueda.Catalogos;
using Datos.ModelosTabla;
using Dominio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class CasetaRepositorio : ICasetaRepositorio
    {
        private CasetaContext _context;

        #region Generics Definition

        public CasetaRepositorio(CasetaContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveAllAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        #endregion Generics Definition

        #region Caseta

        public async Task<List<CasetaModeloTabla>> ObtenerCasetasTabla(CasetaModeloBusqueda mb)
        {
            return await _context.Caseta
                .Where(s => s.Nombre.ToUpper().Contains(mb.Nombre.ToUpper()) || string.IsNullOrEmpty(mb.Nombre))
                .Where(s => s.Rfc.ToUpper().Contains(mb.Rfc.ToUpper()) || string.IsNullOrEmpty(mb.Rfc))
                .Where(s => (s.FechaAlta.Date >= mb.FechaInicio.Date) || (mb.FechaInicio.Date == new DateTime()))
                .Where(s => (s.FechaAlta.Date <= mb.FechaFin.Date) || (mb.FechaFin.Date == new DateTime()))
                .Where(s => s.BActivo == true)
                .Select(x => new CasetaModeloTabla
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Rfc = x.Rfc

                })
                .ToListAsync();
        }

        public async Task<List<Caseta>> ObtenerCasetas(CasetaModeloBusqueda mb)
        {
            return await _context.Caseta
                .Where(s => s.Nombre.ToUpper().Contains(mb.Nombre.ToUpper()) || string.IsNullOrEmpty(mb.Nombre))
                .Where(s => s.Rfc.ToUpper().Contains(mb.Rfc.ToUpper()) || string.IsNullOrEmpty(mb.Rfc))
                .Where(s => (s.FechaAlta.Date >= mb.FechaInicio.Date) || (mb.FechaInicio.Date == new DateTime()))
                .Where(s => (s.FechaAlta.Date <= mb.FechaFin.Date) || (mb.FechaFin.Date == new DateTime()))
                .Where(s => s.BActivo == true)
                .ToListAsync();
        }

        public async Task<Caseta> ObtenerCasetaAsync(int Id)
        {
            return await _context.Caseta
                .Where(s => s.Id == Id)
                .FirstOrDefaultAsync();
        }

        #endregion
    }
}

