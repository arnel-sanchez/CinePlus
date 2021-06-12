using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CinePlus.Services
{
    public interface IImageWriter
    {
        Task<string> UploadImage(IFormFile file);
    }
}
