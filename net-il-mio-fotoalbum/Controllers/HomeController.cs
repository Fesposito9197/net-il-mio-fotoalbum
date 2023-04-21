using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;
using System.Diagnostics;

namespace net_il_mio_fotoalbum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly FotoAlbumContext _context;

        public HomeController(ILogger<HomeController> logger, FotoAlbumContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var fotos = _context.Fotos.ToArray();
            return View(fotos);
        }
        
        public IActionResult Detail(int id)
        {
            var foto = _context.Fotos.Include(f => f.Categories).SingleOrDefault(f => f.Id == id);

            if (foto == null) 
            {
                return NotFound();
            }

            return View(foto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}