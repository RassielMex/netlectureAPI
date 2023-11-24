using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netlectureAPI.Services
{
    public interface IFileSaver
    {
        Task<String> SaveFile(byte[] content, string extension, string container, string contentType);
        Task<String> EditFile(byte[] content, string extension, string container, string route, string contentType);
        Task DeleteFile(string route, string container);

    }
}