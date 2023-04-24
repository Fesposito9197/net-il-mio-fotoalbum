using Microsoft.AspNetCore.Mvc.Rendering;

namespace net_il_mio_fotoalbum.Models
{
    public class FotoFormModel
    {
        public Foto Foto { get; set; }
        public IEnumerable<Category>? Categories { get; set; }
        public List<int>? SelectedCategoriesIds { get; set; }
    }
}
