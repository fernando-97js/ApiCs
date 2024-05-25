using System.ComponentModel.DataAnnotations;

namespace ApiCs {
    public class Ong {
        [Key]
        public int OngsId { get; set; } 
        public string OngNome { get; set; } = string.Empty;
        public string OngEmail { get; set; } = string.Empty;
        public string OngTelefone { get; set; } = string.Empty;
        public string OngInfo { get; set; } = string.Empty;
    }

}
