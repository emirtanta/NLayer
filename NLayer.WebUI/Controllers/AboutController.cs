using NLayer.BusinessLayer.Concrete;
using NLayer.DataAccessLayer.EntityFramework;
using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayer.WebUI.Controllers
{
    public class AboutController : Controller
    {
        //Popup Kullanarak CRUD işlemleri yapıldı

        AboutManager am = new AboutManager(new EfAboutDal());

        // GET: About
        public ActionResult Index()
        {
            var aboutvalues = am.GetList();

            return View(aboutvalues);
        }

        #region about ekleme bölümü

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            am.AboutAdd(p);

            return RedirectToAction("Index");
        }

        #endregion

        #region About ekleme Partial(Solid'e göre)


        #endregion
        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}