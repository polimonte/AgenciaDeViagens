using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RGBViagens.Models
{
    [Table("Destinos")]
    public class Destinos
    {
        [Key]
        public int ID_Destinos { get; set; }
        public string Nome_lugar { get; set; }
        public string Preco { get; set; }
        public string Preco_Promoção { get; set; }
        public virtual List<ComprarDestinos> ComprarDestinos { get; set; }
    }
}
