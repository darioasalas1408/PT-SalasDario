using PT_SalasDario.Services.Requests;
using PT_SalasDario.Services.Response;

namespace PT_SalasDario.Services
{
    public interface IUserService
    {
        Task CreateUsuario(CreateUserRequest createUsuarioRequest);
        Task<List<UserResponseDTO>> GetUsuarios(GetUserRequest getUsuarioRequest);
        Task<UserResponseDTO> GetUsuario(int Id);
        Task<bool> RemoveUsuario(int Id);
        Task UpdateUsuario(int id, PutUserRequest putUsuarioRequest);
    }
}
