using System.ComponentModel.DataAnnotations;

namespace ApiCs {
    public class VoluntariosPac {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string FDV { get; set; } = string.Empty;
        public int OngsId { get; set; }
    }
}