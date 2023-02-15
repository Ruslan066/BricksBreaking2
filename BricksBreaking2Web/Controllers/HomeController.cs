using BricksBreaking2Core;
using BricksBreaking2Core.Entity;
using BricksBreaking2Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Xml.Serialization;

namespace BricksBreaking2Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            var field = new Field(5, 5, 0, 0);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DataBase>));

            using (FileStream fs = new FileStream("db.xml", FileMode.OpenOrCreate))
            {
                field.dataBases = xmlSerializer.Deserialize(fs) as List<DataBase>;

            }


            //HttpContext.Session.SetObject(FieldSessionKey, field);
            return View("Privacy", field);

            //return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}