using AutoMapper;
using ProyectoMaestro.ModelosVista;
using Dominio;

namespace ProyectoMaestro.Ayudantes
{
    public class CasetaPerfilMapeo : Profile
    {
        public CasetaPerfilMapeo()
        {
            #region Caseta

            CreateMap<Caseta, CasetaModeloVista>()
           .ReverseMap();

            #endregion
        }

    }
}
