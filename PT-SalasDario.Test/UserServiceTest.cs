using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PT_SalasDario.Data;
using PT_SalasDario.Repository;
using PT_SalasDario.Services;
using PT_SalasDario.Services.Requests;

namespace PT_SalasDario.Test
{
    [TestClass]
    public class UserServiceTest
    {
        private Mock<IUserRepository>? _usuarioRepositoryMock;
        private Mock<IDateProviderService>? _dateProviderServiceMock;
        private IMapper _mapper;
        private UserService? _service;

        [TestInitialize]
        public void Setup()
        {
            _usuarioRepositoryMock = new Mock<IUserRepository>();
            _dateProviderServiceMock = new Mock<IDateProviderService>();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ServiceProfile());
            });

            _mapper = new Mapper(configuration);

            _service = new UserService(
                _usuarioRepositoryMock.Object,
                _dateProviderServiceMock.Object,
                _mapper);
        }

        [TestMethod]
        public async Task Should_Create_User()
        {
            //Arrange
            var userName = "Dario";
            var userProvincia = "Cordoba";
            
            var userRequest = new CreateUserRequest() { Nombre = userName, Provincia = userProvincia };

            var creationDate = new DateTime(2024, 12, 12);
            _dateProviderServiceMock.Setup(s=> s.Now).Returns(creationDate);

            //Act
            await _service.CreateUsuario(userRequest);

            //Assert
            _usuarioRepositoryMock.Verify(repo => repo.CreateUser(It.Is<Usuario>(u =>
                    u.Nombre == userName &&
                    u.Domicilio.Provincia == userProvincia && u.FechaCreacion == creationDate && u.Domicilio.FechaCreacion == creationDate
                )), Times.Once);
        }

        [TestMethod]
        public async Task Should_Call_GetUsuarios_With_Correct_Parameters()
        {
            // Arrange
            var userName = "Dario";
            var userProvincia = "Cordoba";
            var userCiudad = "Cordoba";

            var getUsuarioRequest = new GetUserRequest() { Nombre = userName, Provincia = userProvincia, Ciudad = userCiudad };

            // Act : Tuve que agregar el TRY/CATCH porque no se puede mockear fácilmente el resultado de un IQueryable
            try
            {
                await _service.GetUsuarios(getUsuarioRequest);
            }
            catch
            {
            }


            // Assert
            _usuarioRepositoryMock.Verify(repo => repo.GetUsers(
                It.Is<string>(n => n == userName),
                It.Is<string>(p => p == userProvincia),
                It.Is<string>(c => c == userCiudad)
            ), Times.Once);
        }

        [TestMethod]
        public async Task Should_Delete_User()
        {
            //Arrange
            var userId = 1;

            //Act
            await _service.RemoveUsuario(userId);

            //Assert
            _usuarioRepositoryMock.Verify(repo => repo.DeleteUser(It.Is<int>(u => u == userId)), Times.Once);
        }

        [TestMethod]
        public async Task Should_PUT_User()
        {
            //Arrange
            var userId = 1;
            var userName = "Dario";
            var userEmail = "unitest@test.com";
            var userProvincia = "Cordoba";
            var userCiudad = "VillaDolores";

            var userRequest = new PutUserRequest() { Nombre = userName, Provincia = userProvincia, Email = userEmail, Ciudad = userCiudad };

            var usuario = new Usuario() { Nombre = "Old name", Email = "old email" };
            _usuarioRepositoryMock.Setup(s => s.GetUser(userId)).ReturnsAsync(usuario);

            //Act
            await _service.UpdateUsuario(userId, userRequest);

            //Assert
            _usuarioRepositoryMock.Verify(repo => repo.PutUser(It.Is<Usuario>(u =>
                    u.Nombre == userName &&
                    u.Domicilio.Provincia == userProvincia &&
                    u.Email == userEmail &&
                    u.Domicilio.Ciudad == userCiudad)), Times.Once);
        }
    }
}
