using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FotoController : ControllerBase
    {

        private readonly FotoAlbumContext _context;

        public FotoController(FotoAlbumContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetFotos([FromQuery] string? name ) 
        {
            var fotos = _context.Fotos
                .Include(f => f.Categories)
                .Where(f => name == null || f.Title.ToLower().Contains(name.ToLower()))
                .ToList();

            return Ok(fotos);
        }

        [HttpGet("{id}")]
        public IActionResult GetFotos(int id)
        {
            var foto = _context.Fotos.FirstOrDefault(f => f.Id == id);

            if (foto == null)
            {
                return NotFound();
            }

            return Ok(foto);
        }
    }
}
