using OCBManager.Domain.FileStorage;
using OCBManager.Domain.Models;
using OCBManager.Domain.Parsing;
using OCBManager.Domain.Stores;

namespace OCBManager.Domain.Import
{
    public class OCBImporter : IOCBImporter
    {
        private readonly IFileStorage _fileStorage;
        private readonly ISheetParser _sheetParser;
        private readonly ITurnoverSheetStore _turnoverSheetStore;

        public OCBImporter(IFileStorage fileStorage, ISheetParser sheetParser, ITurnoverSheetStore turnoverSheetStore)
        {
            _fileStorage = fileStorage;
            _sheetParser = sheetParser;
            _turnoverSheetStore = turnoverSheetStore;
        }

        public async Task ImportAsync(FileData fileData)
        {
            string path = await _fileStorage.SaveAsync(fileData);
            TurnoverSheet turnoverSheet = _sheetParser.Parse(path);
            turnoverSheet.FilePath = path;
            await _turnoverSheetStore.AddAsync(turnoverSheet);
        }
    }
}