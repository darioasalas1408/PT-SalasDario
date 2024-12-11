using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PT_SalasDario.Data;
using PT_SalasDario.Repository;
using PT_SalasDario.Services.Requests;
using PT_SalasDario.Services.Response;

namespace PT_SalasDario.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _usuarioRepository;
        private readonly IDateProviderService _dateProviderService;
        private readonly IMapper _mapper;

        public UserService(IUserRepository usuarioRepository, IDateProviderService dateProviderService, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _dateProviderService = dateProviderService;
            _mapper = mapper;
        }

        public async Task CreateUsuario(CreateUserRequest request)
        {
            var usuario = _mapper.Map<Usuario>(request);

            //Por razones de simplicidad y tiempo, decidí NO ejecutar esto en el profiler de Automapper, pero se podría inyectar el IDateProviderService al mismo
            usuario.FechaCreacion = _dateProviderService.Now;
            usuario.Domicilio.FechaCreacion = _dateProviderService.Now;

            await _usuarioRepository.CreateUser(usuario);
        }

        public async Task<List<UserResponseDTO>> GetUsuarios(GetUserRequest request)
        {
            var listUsuariosQuery = _usuarioRepository.GetUsers(request.Nombre, request.Provincia, request.Ciudad);

            var listUsuariosRetorno = await listUsuariosQuery.Select(
                c => new UserResponseDTO()
                {
                    ID = c.ID,
                    Nombre = c.Nombre,
                    Calle = c.Domicilio.Calle,
                    Ciudad = c.Domicilio.Ciudad,
                    Numero = c.Domicilio.Numero,
                    Provincia = c.Domicilio.Provincia
                }).ToListAsync();

            return listUsuariosRetorno;
        }

        public async Task<UserResponseDTO> GetUsuario(int Id)
        {
            var usuario = await _usuarioRepository.GetUser(Id);

            var usuariosRetorno = _mapper.Map<UserResponseDTO>(usuario);

            return usuariosRetorno;
        }

        public async Task<bool> RemoveUsuario(int Id)
        {
            return await _usuarioRepository.DeleteUser(Id);
        }

        public async Task UpdateUsuario(int id, PutUserRequest request)
        {
            var usuario = await _usuarioRepository.GetUser(id);

            if (usuario == null)
                throw new KeyNotFoundException($"No se encontró un usuario con el Id {id}");
               

            if (usuario.Domicilio == null)
            {
                usuario.Domicilio = new Domicilio()
                {
                    Calle = request.Calle,
                    Numero = request.Numero,
                    Ciudad = request.Ciudad,
                    Provincia = request.Provincia,
                    FechaCreacion = _dateProviderService.Now
                };
            }
            else
            {
                usuario.Domicilio.Calle = request.Calle;
                usuario.Domicilio.Numero = request.Numero;
                usuario.Domicilio.Provincia = request.Provincia;
                usuario.Domicilio.Ciudad = request.Ciudad;
            }

            usuario.Nombre = request.Nombre;
            usuario.Email = request.Email;

            await _usuarioRepository.PutUser(usuario);
        }
    }
}
