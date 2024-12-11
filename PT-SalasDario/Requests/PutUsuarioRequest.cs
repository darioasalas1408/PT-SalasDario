using static PT_SalasDario.Services.DTOs.ValidProvincias;
using System.ComponentModel.DataAnnotations;

namespace PT_SalasDario.API.Requests
{
    public class PutUsuarioRequest
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
