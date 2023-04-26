using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using net_il_mio_fotoalbum.Models;

namespace net_il_mio_fotoalbum.Controllers.ApiControllers
{
    [Route("api/userinfo")]
    [ApiController]
    public class UserInfoController : ControllerBase
    {
        private readonly FotoAlbumContext _context;

        public UserInfoController(FotoAlbumContext context)
        {
            _context = context;
        }


        [HttpPost]
        public IActionResult CreateUserInfo(UserForm userform)
        {
            
            _context.UserForms.Add(userform);
            _context.SaveChanges();
            return Ok(userform);
        }
    }
}
