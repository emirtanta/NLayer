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
    //yetki kontroller
    public class AuthorazitionController : Controller
    {
        AdminManager am = new AdminManager(new EfAdminDal());

        // adminlerin yetkisini getirir
        public ActionResult Index()
        {
            var adminvalues = am.GetList();

            return View(adminvalues);
        }

        //yeni admin ekleeme
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {

            am.AdminAdd(p);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminvalue = am.GetByID(id);

            return View(adminvalue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            am.AdminUpdate(p);

            return RedirectToAction("Index");
        }

    }
}