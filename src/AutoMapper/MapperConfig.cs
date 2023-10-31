using AutoMapper;
using RedeSocialAPI.Models.Data;
using RedeSocialAPI.Models.ViewObjects;

namespace RedeSocialAPI.src.AutoMapper
{
    public class MapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(cfg =>
            {
                //Usuario
                cfg.CreateMap<Usuario, UsuarioVO>()
                .ForMember(x => x.Id, b => b.MapFrom(x => x.Id))
                .ForMember(x => x.Nome, b => b.MapFrom(x => x.FirstName))
                .ForMember(x => x.Sobrenome, b => b.MapFrom(x => x.LastName))
                .ForMember(x => x.Email, b => b.MapFrom(x => x.Email))
                .ForMember(x => x.Password, b => b.MapFrom(x => x.Password))
                .ReverseMap();
            });

            return mappingConfig;
        }
    }
}
