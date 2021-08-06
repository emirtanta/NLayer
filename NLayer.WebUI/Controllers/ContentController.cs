using NLayer.BusinessLayer.Concrete;
using NLayer.DataAccessLayer.Concrete;
using NLayer.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayer.WebUI.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        // GET: Content
        public ActionResult Index()
        {
            return View();
        }


        //yazıları arama işlemi
        public ActionResult GetAllContent(string p)
        {
            var values = cm.GetList(p);



            return View(values);
        }

        //yazarlara ait içerikleri liste olarak getirir
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = cm.GetListByID(id);

            return View(contentvalues);
        }
    }
}