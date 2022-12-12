using Microsoft.AspNetCore.Mvc;

namespace SMA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public AuthController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> UserId()
        {
            return Ok("user di");
        }
    }
}
