using AutoMapper;
using PT_SalasDario.Services.Requests;

namespace PT_SalasDario.API.Profiles
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<Requests.CreateUsuarioRequest, CreateUserRequest>();
            CreateMap<Requests.GetUsuarioRequest, GetUserRequest>();
            CreateMap<Requests.PutUsuarioRequest, PutUserRequest>();
        }
    }
}
