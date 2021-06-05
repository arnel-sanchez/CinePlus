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
        public IActionResult ExportToPDF(List<Pay> content)
        {
            var document = new PdfDocument();
            foreach (var item in content)
            {
                var index = 0;
                var page = new PdfPage(document);

                var i = item.UserBoughtArmChair.Show.Movie.URL.IndexOf("/img/");
                var url = item.UserBoughtArmChair.Show.Movie.URL.Substring(i);
                url = "wwwroot" + url;
                var image = XImage.FromFile(url);
                var gfx = XGraphics.FromPdfPage(page);

                gfx.DrawImage(image, (page.Width-300)/2, 50, 300, 300);
                
                var font = new XFont("OpenSans", 20, XFontStyle.Bold);

                var font2 = new XFont("OpenSans", 10, XFontStyle.Underline);
                var len = 0;
                gfx.DrawString(item.UserBoughtArmChair.Show.Movie.Name, font, XBrushes.Black, new XRect(0, len, page.Width, page.Height), XStringFormats.Center);
                len += 40;
                if(item.PayCart.PayedPoints==0)
                {
                    gfx.DrawString("Precio: $" + item.UserBoughtArmChair.Show.Price, font, XBrushes.Black, new XRect(20, len, page.Width, page.Height), XStringFormats.CenterLeft);
                    len += 25;
                    if (item.DiscountId != "ninguno")
                    {
                        gfx.DrawString("Descuento: " + item.Discount.Name + " del " + item.Discount.Percent + "%", font, XBrushes.Black, new XRect(20, len, page.Width, page.Height), XStringFormats.CenterLeft);
                        len += 25;
                        gfx.DrawString("Pagado: $" + (item.UserBoughtArmChair.Show.Price - (item.UserBoughtArmChair.Show.Price) * item.Discount.Percent / 100), font, XBrushes.Black, new XRect(20, len, page.Width, page.Height), XStringFormats.CenterLeft);
                        len += 25;
                    }
                }
                else
                {
                    gfx.DrawString("Precio: " + item.UserBoughtArmChair.Show.PriceInPoints + " puntos.", font, XBrushes.Black, new XRect(20, len, page.Width, page.Height), XStringFormats.CenterLeft);
                    len += 25;
                    if (item.DiscountId != "ninguno")
                    {
                        gfx.DrawString("Descuento: " + item.Discount.Name + " del " + item.Discount.Percent + "%", font, XBrushes.Black, new XRect(20, len, page.Width, page.Height), XStringFormats.CenterLeft);
                        len += 25;
                        gfx.DrawString("Pagado: " + (item.UserBoughtArmChair.Show.PriceInPoints - (item.UserBoughtArmChair.Show.PriceInPoints) * item.Discount.Percent / 100) + " puntos.", font, XBrushes.Black, new XRect(20, len, page.Width, page.Height), XStringFormats.CenterLeft);
                        len += 25;
                    }
                }
                gfx.DrawString("Sala: " + item.UserBoughtArmChair.Show.Room.Name, font, XBrushes.Black, new XRect(20, len, page.Width, page.Height), XStringFormats.CenterLeft);
                len += 25;
                gfx.DrawString("Asiento: " + item.UserBoughtArmChair.ArmChairByRoom.ArmChair.No, font, XBrushes.Black, new XRect(20, len, page.Width, page.Height), XStringFormats.CenterLeft);
                len += 25;
                gfx.DrawString("Comprado por: " + item.UserBoughtArmChair.User.Name + " " + item.UserBoughtArmChair.User.Name, font, XBrushes.Black, new XRect(20, len, page.Width, page.Height), XStringFormats.CenterLeft);
                len += 25;
                gfx.DrawString("Fecha y Hora de la Función: " + item.UserBoughtArmChair.Show.DateTime, font, XBrushes.Black, new XRect(20, len, page.Width, page.Height), XStringFormats.CenterLeft);
                if (item.DiscountId != "ninguno")
                    len += 155;
                else
                    len += 205;
                gfx.DrawString("CinePlus", font, XBrushes.Black, new XRect(0, len, page.Width, page.Height), XStringFormats.Center);
                len += 20;
                gfx.DrawString("Sólo puede cancelar su entrada 2h antes del inicio de la función, pasado ese momento no se le devolverá su dinero.", font2, XBrushes.Black, new XRect(0, len, page.Width, page.Height), XStringFormats.Center);
                len += 20;
                gfx.DrawString("Debe verificar su entrada en taquilla 30 minutos antes del inicio de la función, pasado ese momento se venderá su asiento.", font2, XBrushes.Black, new XRect(0, len, page.Width, page.Height), XStringFormats.Center);
                document.InsertPage(index, page);
                index += 1;
            }
            var res = new MemoryStream();
            document.Save(res);
            return File(res.ToArray(), "application/pdf");
        }
    }
}
