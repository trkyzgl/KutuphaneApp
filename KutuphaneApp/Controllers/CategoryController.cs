using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
//using System.ComponentModel.DataAnnotations;

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
            //_categoryDal.Insert(p);
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                //cm.CategoryAddBl(p); olması gereken 
                _categoryDal.Insert(p); // şimdilik yaptığım
                return RedirectToAction("CategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }

        public ActionResult DeleteCategory(Category p)
        {

            _categoryDal.Delete(p); 
            return RedirectToAction("CategoryList");
        }
    }
}
