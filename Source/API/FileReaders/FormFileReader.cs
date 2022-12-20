using Microsoft.Net.Http.Headers;
using OCBManager.Domain.FileStorage;

namespace OCBManager.API.FileReaders
{
    public class FormFileReader : IFormFileReader
    {
        public FileData Read(IFormFile file)
        {
            string? fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Value?.Trim('"');
            if (fileName == null)
            {
                throw new ApplicationException("FileName is null.");
            }

            return new FileData(file.OpenReadStream(), Path.GetExtension(fileName));
        }
    }
}
