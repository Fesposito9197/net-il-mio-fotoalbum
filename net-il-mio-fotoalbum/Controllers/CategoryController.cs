﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly FotoAlbumContext _context;

        public CategoryController(FotoAlbumContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var categories = _context.Categories.ToArray();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var formModel = new CategoryFormModel();

            return View(formModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _context.Categories.Add(model.category);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            var categoryDelete = _context.Categories.FirstOrDefault(c => c.Id == id);
            if (categoryDelete == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(categoryDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
