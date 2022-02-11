using Datos.ModelosBusqueda;
using Datos.ModelosBusqueda.Catalogos;
using Datos.ModelosTabla;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
     public interface ICasetaRepositorio
     {
        #region Generic Functions

        void Add<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveAllAsync();

        #endregion Generic Functions

        #region Caseta
        Task<List<Caseta>> ObtenerCasetas(CasetaModeloBusqueda mb);
        Task<List<CasetaModeloTabla>> ObtenerCasetasTabla(CasetaModeloBusqueda mb);
        Task<Caseta> ObtenerCasetaAsync(int Id);
        #endregion

    }
}
