using BusinessLayer.Concrete;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
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
        public ActionResult CategoryList()
        {
            var categoryvalues = _categoryDal.List();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }


        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            _categoryDal.Insert(p);
            return RedirectToAction("CategoryList");

        }

        public ActionResult DeleteCategory(Category p)
        {
            return RedirectToAction("CategoryList");
        }
    }
}
