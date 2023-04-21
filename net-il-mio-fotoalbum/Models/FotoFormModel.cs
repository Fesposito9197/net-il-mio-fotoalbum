using Microsoft.AspNetCore.Mvc.Rendering;

namespace net_il_mio_fotoalbum.Models
{
    public class FotoFormModel
    {
        public Foto Foto { get; set; }
        public IEnumerable<SelectListItem>? Categories { get; set; }
        public List<string>? SelectedCategories { get; set; }
    }
}
