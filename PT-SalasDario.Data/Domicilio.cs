using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PT_SalasDario.Data
{
    [Table("domicilio")]
    public class Domicilio : EntidadAuditable
    {
        [Key]
        public int ID { get; set; }

        public string Calle { get; set; }

        public string Numero { get; set; }

        public string Provincia { get; set; }

        public string Ciudad { get; set; }
    }
}
