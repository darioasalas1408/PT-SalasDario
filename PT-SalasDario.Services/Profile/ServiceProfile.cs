using AutoMapper;
using PT_SalasDario.Data;
using PT_SalasDario.Services.Requests;
using PT_SalasDario.Services.Response;

namespace PT_SalasDario.Services
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Usuario, UserResponseDTO>()
                 .ForMember(dest => dest.Calle, opt => opt.MapFrom(src => src.Domicilio.Calle))
                 .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Domicilio.Numero))
                 .ForMember(dest => dest.Provincia, opt => opt.MapFrom(src => src.Domicilio.Provincia))
                 .ForMember(dest => dest.Ciudad, opt => opt.MapFrom(src => src.Domicilio.Ciudad));

            CreateMap<CreateUserRequest, Domicilio>()
                 .ForMember(dest => dest.Calle, opt => opt.MapFrom(src => src.Calle))
                 .ForMember(dest => dest.Ciudad, opt => opt.MapFrom(src => src.Ciudad))
                 .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
                 .ForMember(dest => dest.Provincia, opt => opt.MapFrom(src => src.Provincia));

            CreateMap<CreateUserRequest, Usuario>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Domicilio, opt => opt.MapFrom(src => src));
        }
    }
}
