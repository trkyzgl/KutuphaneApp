using DataAccsessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneApp.Controllers
{
    public class AdminCategoryController : Controller
    {

        private readonly ICategoryDal _categoryDal;

        public AdminCategoryController(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        //CategoryManager cm = new CategoryManager(new EfCategoryDal()); Olması gereken
        public IActionResult Index()
        {
            var categoryValues = _categoryDal.List();
            return View(categoryValues);
        }

        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}
