using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PT_SalasDario.Data
{
    [Table("usuario")]
    public class Usuario  : EntidadAuditable
    {
        [Key]
        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Email { get; set; }

        public Domicilio Domicilio { get; set; }
    }
}
