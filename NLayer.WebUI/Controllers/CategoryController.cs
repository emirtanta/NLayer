using NLayer.BusinessLayer.Concrete;
using NLayer.BusinessLayer.ValidationRules;
using NLayer.DataAccessLayer.EntityFramework;
using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidation.Results;

namespace NLayer.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        // kategori listesi
        [Authorize(Roles ="B")]
        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetList();

            return View(categoryvalues);
        }

        #region Kategori Ekleme Bölgesi

        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category p)
        {
            //cm.CategoryAddBL(p);

            //kategori için yazdığımız kısıtları eklerken görebilmek için tanımladık
            CategoryValidator categoryValidator = new CategoryValidator();

            ValidationResult results = categoryValidator.Validate(p);

            if (results.IsValid)
            {
                cm.CategoryAddBL(p);

                return RedirectToAction("GetCategoryList");
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




        #endregion

        #region Kategori Güncelleme Bölgesi

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);

            return View(categoryvalue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category p)
        {
            cm.CategoryUpdate(p);

            return RedirectToAction("GetCategoryList");
        }

        #endregion


        #region Kategori Silme Bölgesi

        public ActionResult DeleteCategory(int id)
        {
            var categoryvalue = cm.GetByID(id);

            cm.CategoryDelete(categoryvalue);

            return RedirectToAction("GetCategoryList");
        }

        #endregion

        public ActionResult Index()
        {
            return View();
        }
    }
}