using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SMA.Domain.Entities;
using SMA.Domain.Interfaces.Repositories;

namespace SMA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticController : ControllerBase
    {
        public readonly ILogger _log;
        public readonly ISmaStaticFileRepository _smaStaticFileRepository;
        private readonly IWebHostEnvironment _env;

        public StaticController(
            ILogger<StaticController> log,
            ISmaStaticFileRepository smaStaticFileRepository,
            IWebHostEnvironment env)
        {
            _log = log;
            _env = env;
            _smaStaticFileRepository = smaStaticFileRepository;
        }

        [HttpGet]
        [Route("/static/images/{id}")]
        public IActionResult GetFileById(string id)
        {
            return Redirect($"http://localhost:5091/uploads/{id}");
        }

        [HttpPost]
        [Route("/static/file/uploads")]
        public async Task<IActionResult> UploadFile(List<IFormFile> files)
        {
            var listFileName = new List<string>();
            var smaStaticFiles = new List<SmaStaticFile>();
            long size = files.Sum(x => x.Length);
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    if (!Directory.Exists(_env.WebRootPath + "\\uploads"))
                    {
                        Directory.CreateDirectory(_env.WebRootPath + "\\uploads\\");
                    }
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                    var filePath = Path.Combine(_env.WebRootPath, "uploads", fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(fileStream);
                        fileStream.Flush();
                    }

                    listFileName.Add(fileName);
                    smaStaticFiles.Add(new SmaStaticFile
                    {
                        Name = fileName,
                        UseCount = 0,
                    });
                }
            }

            await _smaStaticFileRepository.AddMany(smaStaticFiles);
            return Ok(listFileName);
        }
    }
}
