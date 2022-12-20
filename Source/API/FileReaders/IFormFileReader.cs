using OCBManager.Domain.FileStorage;

namespace OCBManager.API.FileReaders
{
    public interface IFormFileReader
    {
        public FileData Read(IFormFile file);
    }
}
