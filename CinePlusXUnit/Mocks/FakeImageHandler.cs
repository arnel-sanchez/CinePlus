using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CinePlus.Models;
using CinePlus.Services;
using Microsoft.AspNetCore.Http;
using Moq;

namespace CinePlusXUnit.Mocks
{
    class FakeImageHandler:IImageHandler
    {
        public async Task<string> UploadImage(IFormFile file)
        {
            var a = new ValueTask<string>("uploadTask");
            return await a.AsTask();
        }
    }
}
