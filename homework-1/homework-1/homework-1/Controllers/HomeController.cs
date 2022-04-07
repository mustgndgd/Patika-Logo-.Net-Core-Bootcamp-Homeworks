using homework_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace homework_1.Controllers
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
            ViewBag.message = null;
            return View();
        }

        [HttpPost]
        public IActionResult Index(SignInViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //Validasyon kurallarına uymadığı takdirde view'a geri dönüp uyarı mesajlarını göstericek
                return View();

                //respons nesnesini döndüren kısım
                //return View(new SignInViewModel{  ResponseModel = new SignInResponseViewModel{ Success = false, Data = null , Error = "Hatalı giriş" } });
            }
            //Validasyonları sağladığında view'a dönecek ve herhangi bir uyarı göstermeyecek
            return View();

            //respons nesnesini döndüren kısım
            //return View(new SignInViewModel { ResponseModel = new SignInResponseViewModel { Success = true, Data = "Giriş işlemi başarılı", Error = null } });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
