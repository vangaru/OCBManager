using OCBManager.Domain.FileStorage;

namespace OCBManager.Domain.Import
{
    public interface IOCBImporter
    {
        public Task<int> ImportAsync(FileData fileData);
    }
}
