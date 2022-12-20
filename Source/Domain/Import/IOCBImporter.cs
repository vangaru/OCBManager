using OCBManager.Domain.FileStorage;

namespace OCBManager.Domain.Import
{
    public interface IOCBImporter
    {
        public Task ImportAsync(FileData fileData);
    }
}
