using NLayer.BusinessLayer.Concrete;
using NLayer.DataAccessLayer.Concrete;
using NLayer.DataAccessLayer.EntityFramework;
using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList; //sayfalama için kullanıldı
using PagedList.Mvc; //sayfalama için kullanıldı
using FluentValidation.Results;
using NLayer.BusinessLayer.ValidationRules;

namespace NLayer.WebUI.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal());

        CategoryManager cm = new CategoryManager(new EfCategoryDal());

        WriterManager wm = new WriterManager(new EWriterDal());
        WriterValidator writerValidator = new WriterValidator();

        Context c = new Context();

        #region yazar profil bölümü

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var writerValue = wm.GetByID(id);

            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer p)
        {
            ValidationResult results = writerValidator.Validate(p);

            if (results.IsValid)
            {
                wm.WriterUpdate(p);

                return RedirectToAction("AllHeading", "WriterPanel");
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



        //yazarın yazdığı başlıklar bölümü
        public ActionResult MyHeading(string p)
        {
            
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();


            var values = hm.GetListByWriter(writeridinfo);

            return View(values);
        }

        #region yazıya başlık ekleme bölümü

        public ActionResult NewHeading()
        {

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string writermailinfo = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == writermailinfo).Select(y => y.WriterID).FirstOrDefault();

            

            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            p.WriterID = writeridinfo;
            p.HeadingStatus = true;

            hm.HeadingAdd(p);

            return RedirectToAction("MyHeading");
        }

        #endregion

        #region Başlık Düzenleme Bölümü

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            var headingvalue = hm.GetByID(id);

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            ViewBag.vlc = valuecategory;

            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);

            return RedirectToAction("MyHeading");
        }

        #endregion

        #region Başlık Silme Bölümü


        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = hm.GetByID(id);

            headingvalue.HeadingStatus = false;

            hm.HeadingDelete(headingvalue);

            return RedirectToAction("MyHeading");
        }

        #endregion

        //p=> sayfa değerini temsil eder.sayfanın 1'den başlayacağını gösterir
        public ActionResult AllHeading(int p=1)
        {
            var headings = hm.GetList().ToPagedList(p,4);

            return View(headings);
        }
    }
}