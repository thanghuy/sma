using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SMA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticController : ControllerBase
    {
        public readonly ILogger _log;
        public StaticController(ILogger<StaticController> log)
        {
            _log = log;
        }

        [HttpGet]
        [Route("/static/file/{id}")]
        public async Task<IActionResult> GetFileById(string id)
        {
            return Ok("a");
        }
    }
}
