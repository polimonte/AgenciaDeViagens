using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGBViagens.Models
{
    [Table("ComprarDestinos")]
    public class ComprarDestinos
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Origem { get; set; }
        [ForeignKey("Destinos")]
        public int ID_Destinos { get; set; }
        public virtual Destinos Destinos { get; set; }
        [Required]
        public DateTime Ida { get; set; }
        public DateTime Volta { get; set; }
        [Required]
        public int N_Passageiros { get; set; }
        [Required]
        public string Classe { get; set; }
    }
}
