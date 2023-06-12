using Microsoft.AspNetCore.Mvc;

namespace KutuphaneApp.Controllers
{
    public class KitapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
