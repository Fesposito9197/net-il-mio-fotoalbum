using Microsoft.AspNetCore.Authorization;
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

        public IActionResult ContactUs()
        {
            return View();
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

        [Authorize(Roles ="Admin")]
        [HttpGet]
        public IActionResult Create()
        {
            var formModel = new FotoFormModel
            {
                Categories = _context.Categories.ToArray(),
            };

            //var model = new FotoFormModel();
            //List<SelectListItem> listCategorie = new List<SelectListItem>();
            
            //foreach (var categorie in _context.Categories)
            //{
            //    listCategorie.Add(new SelectListItem()
            //    { Text = categorie.Name, Value = categorie.Id.ToString() });
            //}
            //model.Foto = new Foto();
            //model.Categories = listCategorie;

            return View("Create",formModel);

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FotoFormModel form)
        {
            if (!ModelState.IsValid)
            {
                form.Categories = _context.Categories.ToArray();

                return View(form);
            }
            form.Foto.Categories = form.SelectedCategoriesIds.Select(sc => _context.Categories.First(c => c.Id == Convert.ToInt32(sc))).ToList();
            _context.Fotos.Add(form.Foto);
            _context.SaveChanges();
            return RedirectToAction("Index");
          

        }
        [Authorize(Roles = "Admin")]
        public IActionResult Edit(int id)
        {
            var foto = _context.Fotos.Include(f => f.Categories).FirstOrDefault(f => f.Id == id);

            if (foto == null)
            {
                return NotFound();
            }

            var formModel = new FotoFormModel
            {
                Foto = foto,
                Categories = _context.Categories.ToArray(),
                SelectedCategoriesIds = foto.Categories.Select(c => c.Id).ToList(),


            };
            return View(formModel);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit( int id , FotoFormModel form)
        {
            if (!ModelState.IsValid)
            {
                form.Categories = _context.Categories.ToArray();

                return View(form);
            }

            var SavedFoto = _context.Fotos.Include(f=> f.Categories).FirstOrDefault(c => c.Id == id);

            if (SavedFoto == null)
            {
                return NotFound();
            }

            SavedFoto.Title = form.Foto.Title;
            SavedFoto.Title = form.Foto.Description;
            SavedFoto.FotoUrl = form.Foto.FotoUrl;
            SavedFoto.IsVisible = form.Foto.IsVisible;
            SavedFoto.Categories = _context.Categories.Where(c => form.SelectedCategoriesIds.Contains(c.Id)).ToList();
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
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