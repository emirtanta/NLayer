using FluentValidation.Results;
using NLayer.BusinessLayer.Concrete;
using NLayer.BusinessLayer.ValidationRules;
using NLayer.DataAccessLayer.EntityFramework;
using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayer.WebUI.Controllers
{
    public class WriterController : Controller
    {

        WriterManager wm = new WriterManager(new EWriterDal());
        WriterValidator writerValidator = new WriterValidator();

        public ActionResult Index()
        {
            var writerValues = wm.GetList();

            return View(writerValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
            

            ValidationResult results = writerValidator.Validate(p);

            if (results.IsValid)
            {
                wm.WriterAdd(p);

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

        [HttpGet]
        public ActionResult EditWriter(int id)
        {



            var writervalue = wm.GetByID(id);

            return View(writervalue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);

            if (results.IsValid)
            {
                wm.WriterUpdate(p);

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

        public ActionResult DeleteWriter(int id)
        {
            var writervalue = wm.GetByID(id);

            wm.WriterDelete(writervalue);

            return RedirectToAction("Index");
        }
    }
}