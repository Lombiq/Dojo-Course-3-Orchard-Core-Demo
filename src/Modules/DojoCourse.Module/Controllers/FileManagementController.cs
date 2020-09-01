using Microsoft.AspNetCore.Mvc;
using OrchardCore.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DojoCourse.Module.Controllers
{
    public class FileManagementController : Controller
    {
        private readonly IMediaFileStore _mediaFileStore;

        
        public FileManagementController(IMediaFileStore mediaFileStore)
        {
            _mediaFileStore = mediaFileStore;
        }


        public async Task<string> CreateFile()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes("Hello world!"));
            await _mediaFileStore.CreateFileFromStreamAsync("Demo.txt", stream);

            return "OK";
        }

        public async Task<string> ReadFile()
        {
            var fileInfo = await _mediaFileStore.GetFileInfoAsync("Demo.txt");

            if (fileInfo == null)
            {
                return "Not found :(";
            }

            using var stream = await _mediaFileStore.GetFileStreamAsync("Demo.txt");
            using var streamReader = new StreamReader(stream);
            var content = await streamReader.ReadToEndAsync();

            return $"File info: size: {fileInfo.Length}, last modification UTC: {fileInfo.LastModifiedUtc}. Content: {content}";
        }
    }
}
