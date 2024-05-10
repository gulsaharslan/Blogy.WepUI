using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Blogy.WepUI.Areas.Admin.Views.ViewComponents.DashboardViewComponent
{
    [Area("Admin")]
    public class WeatherComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            //string api = "c0aa9012f2ef4ace1b890177b2cfb22e";

            //string connection = "http://api.openweathermap.org/data/2.5/weather?q=Istanbul,TR&units=metric&mode=xml&lang=tr&appid=" + api;
            //XDocument document = XDocument.Load(connection);
            //ViewBag.temperature = document.Descendants("temperature").ElementAt(0).Attribute("value").Value;
            //ViewBag.humidity = document.Descendants("humidity").ElementAt(0).Attribute("value").Value;
            //ViewBag.wind = document.Descendants("speed").ElementAt(0).Attribute("value").Value;
            //ViewBag.clouds = document.Descendants("clouds").ElementAt(0).Attribute("value").Value;
            //ViewBag.city = document.Descendants("city").ElementAt(0).Attribute("name").Value;
            //ViewBag.time=DateTime.Now.ToString("HH.mm");
            //ViewBag.date = DateTime.Now.ToString("dd.MM.yyyy");
            //ViewBag.status = document.Descendants("clouds").ElementAt(0).Attribute("name").Value;


            ViewBag.temperature = "18";
            ViewBag.humidity = "%10";
            ViewBag.wind = "5";
            ViewBag.clouds = "Açık";
            ViewBag.city = "İstanbul";
            ViewBag.time = DateTime.Now.ToString("HH.mm");
            ViewBag.date = DateTime.Now.ToString("dd.MM.yyyy");
            ViewBag.status = "Açık";
            return View();
        }
    }
}
