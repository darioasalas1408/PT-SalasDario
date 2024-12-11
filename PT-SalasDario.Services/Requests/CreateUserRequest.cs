namespace PT_SalasDario.Services.Requests
{
    public class CreateUserRequest
    {
        public string Nombre { get; set; }

        public string Email { get; set; }

        public string Numero { get; set; }

        public string Calle { get; set; }

        public string Ciudad { get; set; }

        public string Provincia { get; set; }
    }
}
