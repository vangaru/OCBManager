using Microsoft.AspNetCore.Mvc;
using OCBManager.API.FileReaders;
using OCBManager.Domain.FileStorage;
using OCBManager.Domain.Import;

namespace OCBManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OCBController : ControllerBase
    {
        private readonly IFormFileReader _formFileReader;
        private readonly IOCBImporter _ocbImporter;

        public OCBController(IOCBImporter ocbImporter, IFormFileReader formFileReader)
        {
            _ocbImporter = ocbImporter;
            _formFileReader = formFileReader;
        }

        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> UploadAsync()
        {
            IFormCollection? formCollection = await Request.ReadFormAsync();
            IFormFile? file = formCollection?.Files.FirstOrDefault();
            if (file == null)
            {
                return BadRequest(new { message = "Import file is missing" });
            }

            FileData fileData = _formFileReader.Read(file);
            await _ocbImporter.ImportAsync(fileData);

            return Ok();
        }
    }
}