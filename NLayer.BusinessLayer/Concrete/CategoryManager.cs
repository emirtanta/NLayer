using NLayer.BusinessLayer.Abstract;
using NLayer.DataAccessLayer.Abstract;
using NLayer.DataAccessLayer.Concrete.Repositories;
using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {



        //GenericRepository<Category> repo = new GenericRepository<Category>();

        //public List<Category> GetAllBL()
        //{
        //    return repo.List();
        //}

        //public void CategoryAddBL(Category p)
        //{
        //    if (p.CategoryName == "" || p.CategoryName.Length <= 3 || p.CategoryDescription == "" || p.CategoryName.Length >= 51)
        //    {
        //        //hata mesajı
        //    }

        //    else
        //    {
        //        _categoryDal.Insert(p);
        //    }
        //}

        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        //Kategori Ekleme
        public void CategoryAddBL(Category category)
        {
            _categoryDal.Insert(category);
        }

        //kategori silme
        public void CategoryDelete(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.List() ;
        }
    }
}
