using CinePlus.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinePlus.Services
{
    public class Export : ControllerBase
    {
        public IActionResult ExportToPDF(List<Cart> content)
        {
            var document = new PdfDocument();
            foreach (var item in content)
            {
                var index = 0;
                var page = new PdfPage(document);
                
                var image = XImage.FromFile(item.DiscountsByShow.Show.Movie.URL);
                var gfx = XGraphics.FromPdfPage(page);

                gfx.DrawImage(image, (page.Width-300)/2, 50, 300, 300);
                
                var font = new XFont("OpenSans", 20, XFontStyle.Bold);

                var font2 = new XFont("OpenSans", 10, XFontStyle.Underline);

                gfx.DrawString(item.DiscountsByShow.Show.Movie.Name, font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height), XStringFormats.Center);
                gfx.DrawString("Precio: $" + item.DiscountsByShow.Show.Price, font, XBrushes.Black, new XRect(20, 40, page.Width, page.Height), XStringFormats.CenterLeft);
                gfx.DrawString("Sala: " + item.DiscountsByShow.Show.Room.Name, font, XBrushes.Black, new XRect(20, 65, page.Width, page.Height), XStringFormats.CenterLeft);
                gfx.DrawString("Asiento: " + item.ArmChair.No, font, XBrushes.Black, new XRect(20, 95, page.Width, page.Height), XStringFormats.CenterLeft);
                gfx.DrawString("Descuento: " + item.DiscountsByShow.Discount.Name + " del "+ item.DiscountsByShow.Discount.Percent + "%", font, XBrushes.Black, new XRect(20, 115, page.Width, page.Height), XStringFormats.CenterLeft);
                gfx.DrawString("Comprado por: " + item.User.Name + " " + item.User.Name, font, XBrushes.Black, new XRect(20, 140, page.Width, page.Height), XStringFormats.CenterLeft);
                gfx.DrawString("Fecha y Hora de la Función: " + item.DiscountsByShow.Show.DateTime, font, XBrushes.Black, new XRect(20, 165, page.Width, page.Height), XStringFormats.CenterLeft);
                gfx.DrawString("CinePlus", font, XBrushes.Black, new XRect(0, 350, page.Width, page.Height), XStringFormats.Center);
                gfx.DrawString("Sólo puede cancelar su entrada 2h antes del inicio de la función, pasado ese momento no se le devolverá su dinero.", font2, XBrushes.Black, new XRect(0, 370, page.Width, page.Height), XStringFormats.Center);
                gfx.DrawString("Debe verificar su entrada en taquilla 30 minutos antes del inicio de la función, pasado ese momento se venderá su asiento.", font2, XBrushes.Black, new XRect(0, 390, page.Width, page.Height), XStringFormats.Center);
                document.InsertPage(index, page);
                index += 1;
            }
            var res = new MemoryStream();
            document.Save(res);
            return File(res.ToArray(), "application/pdf");
        }
    }
}
