using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netlectureAPI.Services
{
    public class LocalFileSaver : IFileSaver
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;
        public LocalFileSaver(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.env = env;

        }
        public Task DeleteFile(string path, string container)
        {
            if (!String.IsNullOrEmpty(path))
            {
                var fileName = Path.GetFileName(path);
                string filePath = Path.Combine(env.WebRootPath, container, fileName);
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }

            return Task.FromResult(0);
        }

        public async Task<string> EditFile(byte[] content, string extension, string container, string path, string contentType)
        {
            await DeleteFile(path, container);
            return await SaveFile(content, extension, container, contentType);
        }

        public async Task<string> SaveFile(byte[] content, string extension, string container, string contentType)
        {
            var fileName = $"{Guid.NewGuid()}{extension}";
            string folderPath = Path.Combine(env.WebRootPath, container);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, fileName);
            await File.WriteAllBytesAsync(filePath, content);
            var currentURL = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";

            return Path.Combine(currentURL, container, fileName);


        }
    }
}