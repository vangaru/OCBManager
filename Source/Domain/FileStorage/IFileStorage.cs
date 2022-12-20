namespace OCBManager.Domain.FileStorage
{
    public interface IFileStorage
    {
        public Task<string> SaveAsync(FileData fileData);
    }
}