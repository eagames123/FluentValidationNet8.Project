using FluentValidationNet8.Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FluentValidationNet8.Project.Controllers
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

        [HttpPost]
        public IActionResult Index(Personel personel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Privacy");
            }
            return View(personel);
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

//Controller tarafında ilgili kodlarımızı hazırlıyoruz.
//[HttpPost]
//public IActionResult Index(Personel personel)
//{
//if (ModelState.IsValid)
//{
//return RedirectToAction("Privacy");
//}
//return View(personel);
//}
//ModelState.IsValid, ASP.NET MVC veya ASP.NET Core MVC uygulamalarında, bir HTTP isteği ile gelen modelin doğrulama (validation) durumunu kontrol etmek için kullanılan bir özelliktir.
//ASP.NET MVC'de, bir HTTP isteği ile gelen veriler, bir model sınıfına bağlanır (model binding).
//Bu işlem sırasında, gelen verilerin model sınıfındaki özelliklerle eşleşip eşleşmediği kontrol edilir. 
//Ayrıca, gelen verilerin belirli doğrulama kurallarına uyup uymadığı da kontrol edilir.
//ModelState.IsValid, bu doğrulama işleminin sonucunu verir.
//Eğer gelen veriler, model sınıfındaki özelliklerle eşleşiyor ve tüm doğrulama kurallarına uyuyorsa, ModelState.IsValid true (doğru) değerini döndürür. 
//Bu durumda, model geçerli (valid) kabul edilir ve işlem devam eder.
//Ancak, eğer gelen verilerden biri veya birkaçı model sınıfındaki özelliklerle eşleşmiyorsa veya belirtilen doğrulama kurallarına uymuyorsa, ModelState.IsValid false (yanlış) değerini döndürür. 
//Bu durumda, model geçersiz (invalid) kabul edilir ve genellikle hata mesajlarıyla birlikte kullanıcıya geri döndürülür.
//Bu özellik, sunucu tarafında doğrulama durumunu kontrol etmek ve buna göre işlem yapmak için kullanılır.
//Örneğin, bir formun gönderilmesi durumunda, ModelState.IsValid kullanılarak gelen verilerin doğruluğu kontrol edilir ve eğer geçersiz ise uygun hata mesajlarıyla birlikte tekrar formun gösterilmesi sağlanabilir.
