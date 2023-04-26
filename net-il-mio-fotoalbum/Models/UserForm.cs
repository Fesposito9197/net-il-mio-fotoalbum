using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models
{
    public class UserForm
    {
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;

        [Column(TypeName = "text")]
        public string UserMessage { get; set; } = string.Empty;
    }
}
