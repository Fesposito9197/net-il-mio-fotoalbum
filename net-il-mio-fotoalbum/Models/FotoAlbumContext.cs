using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace net_il_mio_fotoalbum.Models
{
    public class FotoAlbumContext : IdentityDbContext<IdentityUser>
    {
        public FotoAlbumContext(DbContextOptions<FotoAlbumContext> options) : base(options) { }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Category> Categories { get; set; }

        public void Seed()
        {
            var fotos = new Foto[]
            {
                new Foto
                {
                    Title = "Foto mare",
                    Description = "Foto che ritrae il mare",
                    FotoUrl = "https://www.touringclub.it/sites/default/files/styles/gallery_full/public/immagini_georiferite/gettyimages-649067370.jpg?itok=BgjbldQE",
                    IsVisible = true,
                },
                new Foto
                {
                    Title = "Foto cane",
                    Description = "Foto che ritrae un cane",
                    FotoUrl = "https://www.touringclub.it/sites/default/files/styles/gallery_full/public/immagini_georiferite/gettyimages-649067370.jpg?itok=BgjbldQE",
                    IsVisible = false,
                },
                new Foto
                {
                    Title = "Foto evento",
                    Description = "Foto che ritrae un evento",
                    FotoUrl = "https://www.touringclub.it/sites/default/files/styles/gallery_full/public/immagini_georiferite/gettyimages-649067370.jpg?itok=BgjbldQE",
                    IsVisible = true,
                },
                new Foto
                {
                    Title = "Foto persone",
                    Description = "Foto che ritrae delle persone",
                    FotoUrl = "https://www.touringclub.it/sites/default/files/styles/gallery_full/public/immagini_georiferite/gettyimages-649067370.jpg?itok=BgjbldQE",
                    IsVisible = true,
                },

            };
            if (!Fotos.Any())
            {
                Fotos.AddRange(fotos);
            }
            if (!Categories.Any())
            {
                var seed = new Category[]
                {
                    new()
                    {
                        Name = "Paesaggi",
                        Fotos = fotos
                    },
                    new()
                    {
                        Name = "Animali"
                    },
                    new()
                    {
                        Name = "Eventi"
                    },
                    new()
                    {
                        Name = "Persone"
                    }
                };
                Categories.AddRange(seed);
            }
            SaveChanges();
        }
    }
}
