using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PT_SalasDario.API.Infra;
using PT_SalasDario.API.Requests;
using PT_SalasDario.Services;
using PT_SalasDario.Services.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PT_SalasDario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserService _usuarioService;

        public UsuarioController(IMapper mapper, IUserService usuarioService)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserResponseDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResult))]
        public async Task<ActionResult> Get([FromQuery] GetUsuarioRequest request)
        {
            try
            {
                var usuarios = await _usuarioService.GetUsuarios(_mapper.Map<PT_SalasDario.Services.Requests.GetUserRequest>(request));

                if (usuarios == null)
                {
                    var errorResult = new ErrorResult
                    {
                        StatusCode = 400,
                        Message = "No se encontraron usuarios con estos parámetros."
                    };

                    return BadRequest(errorResult);
                }

                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResult { StatusCode = 500, Message = "Tuvimos un error en su solicitud", Errors = [ex.Message.ToString()] });
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponseDTO))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResult))]
        public async Task<ActionResult> Get(int id)
        {
            try
            {
                var usurio = await _usuarioService.GetUsuario(id);

                if (usurio == null)
                {
                    var errorResult = new ErrorResult
                    {
                        StatusCode = 400,
                        Message = $"No se encontró un usuario con el Id {id}"
                    };

                    return BadRequest(errorResult);
                }

                return Ok(usurio);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResult { StatusCode = 500, Message = "Tuvimos un error en su solicitud", Errors = [ex.Message.ToString()] });
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResult))]
        public async Task<ActionResult> Post([FromBody] CreateUsuarioRequest request)
        {
            try
            {
                await _usuarioService.CreateUsuario(_mapper.Map<Services.Requests.CreateUserRequest>(request));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResult { StatusCode = 500, Message = "Tuvimos un error en su solicitud", Errors = [ex.Message.ToString()] });
            }
        }


        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActionResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResult))]
        public async Task<ActionResult> Put(int id, [FromBody] PutUsuarioRequest request)
        {
            try
            {
                await _usuarioService.UpdateUsuario(id, _mapper.Map<Services.Requests.PutUserRequest>(request));

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResult { StatusCode = 500, Message = "Tuvimos un error en su solicitud", Errors = [ex.Message.ToString()] });
            }
        }

        
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorResult))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorResult))]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var result = await _usuarioService.RemoveUsuario(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new ErrorResult { StatusCode = 500, Message = "Tuvimos un error en su solicitud", Errors = [ex.Message.ToString()] });
            }

        }
    }
}
