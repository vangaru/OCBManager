using Microsoft.Extensions.Configuration;

namespace OCBManager.Domain.FileStorage
{
    public class FileStorage : IFileStorage
    {
        private const string TurnoverSheetDirectoryPathKey = "TurnoverSheetDirectoryPath";

        private readonly string? _turnoverSheetDirectoryPath;

        public FileStorage(IConfiguration configuration)
        {
            _turnoverSheetDirectoryPath = configuration[TurnoverSheetDirectoryPathKey];
        }

        public async Task<string> SaveAsync(FileData fileData)
        {
            string path = GetSavePath(fileData.Extension);
            var buffer = new byte[fileData.Contents.Length];
            await fileData.Contents.ReadAsync(buffer, 0, buffer.Length);
            await File.WriteAllBytesAsync(path, buffer);
            return path;
        }

        private string GetSavePath(string extension) 
        {
            string fileName = $"{Guid.NewGuid()}{extension}";
            return Path.Combine(TurnoverSheetDirectoryPath, fileName);
        }


        private string TurnoverSheetDirectoryPath
        {
            get
            {
                if (_turnoverSheetDirectoryPath is null)
                {
                    throw new ApplicationException("TurnoverSheetDirectoryPath is not defined.");
                }

                if (!Directory.Exists(_turnoverSheetDirectoryPath))
                {
                    throw new DirectoryNotFoundException($"{_turnoverSheetDirectoryPath} does not exist");
                }

                return _turnoverSheetDirectoryPath;
            }
        }
    }
}
