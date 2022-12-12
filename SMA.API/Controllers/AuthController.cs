using Microsoft.AspNetCore.Mvc;
using SMA.Domain.Entities;
using SMA.Domain.Interfaces;

namespace SMA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISmaUserRepository smaUserRepository;
        private ILogger<AuthController> logger;
        public AuthController(
            ILogger<AuthController> logger,
            ISmaUserRepository smaUserRepository
        )
        {
            this.logger = logger;
            this.smaUserRepository = smaUserRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var user = new SmaUser
            {
                UserName = "huythang"
            };
            await smaUserRepository.Add(user);
            var result = await smaUserRepository.GetAll();
            return Ok(result);
        }
    }
}
