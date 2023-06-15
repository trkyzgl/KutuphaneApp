using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneApp.Controllers
{
    public class CategoryController : Controller
    {



        CategoryManager cm = new CategoryManager(); 


        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetCatogeryList()
        {
            var categoryvalues = cm.GetAllBL();

            return View(categoryvalues);  
        }
    }
}
