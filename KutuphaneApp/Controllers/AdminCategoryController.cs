using BusinessLayer.ValidationRules;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation.Results;
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


        [HttpGet]
        public IActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            CategoryValidator  categoryValidator = new CategoryValidator(); 
            ValidationResult results = categoryValidator.Validate(p);
            if (results.IsValid)
            {
                _categoryDal.Insert(p);
                return RedirectToAction("Index");
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

        public IActionResult _AdminLayout()
        {
            return View();
        }
    }
}
