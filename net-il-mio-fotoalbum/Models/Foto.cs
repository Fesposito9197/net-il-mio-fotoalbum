using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models
{
    public class Foto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obbligatorio")]
        [StringLength(30,ErrorMessage = "il titolo non puo avere piu di 30 caratteri")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obbligatorio")]
        [Column(TypeName = "text")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Campo obbligatorio")]
        public string FotoUrl { get; set; } = string.Empty;

        public bool IsVisible { get; set; }

        public List<Category>? Categories { get; set; }   

        

    }
}
