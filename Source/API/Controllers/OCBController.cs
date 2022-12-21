using Microsoft.AspNetCore.Mvc;
using OCBManager.API.DTO;
using OCBManager.API.FileReaders;
using OCBManager.Domain.FileStorage;
using OCBManager.Domain.Import;
using OCBManager.Domain.Models;
using OCBManager.Domain.Stores;

namespace OCBManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OCBController : ControllerBase
    {
        private readonly IFormFileReader _formFileReader;
        private readonly IOCBImporter _ocbImporter;
        private readonly ITurnoverSheetStore _turnoverSheetStore;

        public OCBController(
            IOCBImporter ocbImporter, 
            IFormFileReader formFileReader,
            ITurnoverSheetStore turnoverSheetStore)
        {
            _ocbImporter = ocbImporter;
            _formFileReader = formFileReader;
            _turnoverSheetStore = turnoverSheetStore;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TurnoverSheetSummaryDTO>>> GetTurnoverSheetAsync()
        {
            List<TurnoverSheet> turnoverSheet = await _turnoverSheetStore.GetTurnoverSheetAsync();
            return Ok(DTOMapper.GetTurnoverSheetSummary(turnoverSheet));
        }

        [HttpGet]
        public async Task<ActionResult<TurnoverSheetDetailsDTO>> GetTurnoverSheetAsync(int id)
        {

            return Ok();
        }
    }
}