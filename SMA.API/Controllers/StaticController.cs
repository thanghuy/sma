using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SMA.API.Models.Config;
using SMA.Domain.Entities;
using SMA.Domain.Interfaces.Repositories;

namespace SMA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticController : ControllerBase
    {
        private readonly ILogger _log;
        private readonly ISmaStaticFileRepository _smaStaticFileRepository;
        private readonly IWebHostEnvironment _env;
        private readonly StaticFile _staticFile;

        public StaticController(
            ILogger<StaticController> log,
            ISmaStaticFileRepository smaStaticFileRepository,
            IWebHostEnvironment env,
            IOptions<StaticFile> config)
        {
            _log = log;
            _env = env;
            _smaStaticFileRepository = smaStaticFileRepository;
            _staticFile = config.Value;
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
                    if (!Directory.Exists(_env.WebRootPath + $"\\{_staticFile.Folder}"))
                    {
                        Directory.CreateDirectory(_env.WebRootPath + $"\\{_staticFile.Folder}\\");
                    }
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName);
                    var filePath = Path.Combine(_env.WebRootPath, _staticFile.Folder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(fileStream);
                        fileStream.Flush();
                    }

                    listFileName.Add($"{_staticFile.Domain}/{_staticFile.Folder}/{fileName}");
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
