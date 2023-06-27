using Microsoft.AspNetCore.Mvc;

namespace KutuphaneApp.Controllers
{
    public class AdminCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}
