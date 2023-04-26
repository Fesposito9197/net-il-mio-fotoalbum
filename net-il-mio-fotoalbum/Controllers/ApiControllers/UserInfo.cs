using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfo : ControllerBase
    {
        private readonly FotoAlbumContext _context;

        public UserInfo(FotoAlbumContext context)
        {
            _context = context;
        }

       
        //[HttpPost]
        //public IActionResult CreateUserInfo() 
        //{
            
        //}
    }
}
