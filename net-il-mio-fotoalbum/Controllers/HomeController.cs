using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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


        [HttpGet]
        public IActionResult Create()
        {

            var model = new FotoFormModel();
            List<SelectListItem> listCategorie = new List<SelectListItem>();
            
            foreach (var categorie in _context.Categories)
            {
                listCategorie.Add(new SelectListItem()
                { Text = categorie.Name, Value = categorie.Id.ToString() });
            }
            model.Foto = new Foto();
            model.Categories = listCategorie;

            return View("Create",model);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FotoFormModel form)
        {
            if (!ModelState.IsValid)
            {
                form.Categories = _context.Categories.Select(c => new SelectListItem(c.Name, c.Id.ToString())).ToArray();

                return View(form);
            }
            form.Foto.Categories = form.SelectedCategories.Select(sc => _context.Categories.First(c => c.Id == Convert.ToInt32(sc))).ToList();
            _context.Fotos.Add(form.Foto);
            _context.SaveChanges();
            return RedirectToAction("Index");
          

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var fotoDelete = _context.Fotos.FirstOrDefault(f => f.Id == id);
            if (fotoDelete == null)
            {
                return NotFound();
            }
            _context.Fotos.Remove(fotoDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
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