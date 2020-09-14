using Microsoft.AspNetCore.Mvc;

namespace WebStoreGusev.Controllers
{
    // Применили фильтр ко всем методам контроллера через атрибуты
    // [SimpleActionFilter]
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
       
        public IActionResult Blog() => View();
       
        public IActionResult BlogSingle() => View();
       
        public IActionResult Cart() => View();
        
        public IActionResult Checkout() => View();
       
        public IActionResult ContactUs() => View();
       
        public IActionResult NotFound() => View();
    }
}
