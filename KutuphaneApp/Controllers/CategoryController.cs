using Microsoft.AspNetCore.Mvc;

namespace KutuphaneApp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
