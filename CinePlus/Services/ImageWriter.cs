using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace CinePlus.Services
{
    public class ImageWriter : IImageWriter
    {
        public async Task<string> UploadImage(IFormFile file)
        {
            if (CheckIfImageFile(file))
            {
                return await WriteFile(file);
            }

            return "Invalid image file";
        }

        private bool CheckIfImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return WriterHelper.GetImageFormat(fileBytes) != WriterHelper.ImageFormat.unknown;
        }

        public async Task<string> WriteFile(IFormFile file)
        {
            string fileName;
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                fileName = Guid.NewGuid().ToString() + extension; //Create a new Name for the file due to security reasons.
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", fileName);

                using (var bits = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(bits);
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "https://localhost:44304/img/" + fileName;
        }
    }
}
