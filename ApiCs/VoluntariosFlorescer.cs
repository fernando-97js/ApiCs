using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCs {
    [Table("voluntariosflorescer")]
    public class VoluntariosFlorescer {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string FDV { get; set; } = string.Empty;
        public int OngsId { get; set; }
    }
}