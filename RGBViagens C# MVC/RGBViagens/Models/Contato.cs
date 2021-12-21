using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGBViagens.Models
{
    [Table("Contato")]
    public class Contato
    {
        [Key]
        public int ID_Contato { get; set; }
        [Required]
        public string NomeCompleto { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mensagem { get; set; }
    }
}
