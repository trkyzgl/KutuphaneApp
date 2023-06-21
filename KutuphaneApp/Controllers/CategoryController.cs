using BusinessLayer.Concrete;
using DataAccsessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace KutuphaneApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryController(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryList()
            var categoryvalues = _categoryDal.GetList();
        {
            var categoryvalues = _categoryDal.List();

            return View(categoryvalues);  
        }
    }
}
