using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.Repositories;
using DataAccsessLayer.UnitOfWorks;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager:ICategoryDal
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Category> List()
        {
            var categories = _unitOfWork.GetRepository<Category>().List().ToList();
            return categories;
        }

        public void Insert(Category p)
        {
            if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length > 51)
            {
                //Hata Mesajı alıncak yer
            }
            else
            {
                _unitOfWork.GetRepository<Category>().Insert(p);
                _unitOfWork.Save();
            }
        }

        public void Delete(Category p)
        {
            _unitOfWork.GetRepository<Category>().Delete(p);
            _unitOfWork.Save();
        }

        public void Update(Category p)
        {
            _unitOfWork.GetRepository<Category>().Update(p);
            _unitOfWork.Save();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            return _unitOfWork.GetRepository<Category>().List(filter).ToList();
        }
    }
}
