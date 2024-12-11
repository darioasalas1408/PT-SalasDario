using System.ComponentModel.DataAnnotations;
using static PT_SalasDario.Services.DTOs.ValidProvincias;

namespace PT_SalasDario.API.Requests
{
    public class CreateUsuarioRequest
    {
        [Required]
        public string Nombre { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        public string? Numero { get; set; }

        public string? Calle { get; set; }

        [Required]
        public string Ciudad { get; set; }

        [Required]
        [EnumDataType(typeof(Provincia))]
        public string Provincia { get; set; }
    }
}
