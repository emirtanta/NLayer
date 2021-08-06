using NLayer.BusinessLayer.Concrete;
using NLayer.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayer.WebUI.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        HeadingManager hm = new HeadingManager(new EfHeadingDal());
        ContentManager cm = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var headinglist = hm.GetList();

            return View(headinglist);
        }

        //yazarın yazdığı yazıları vitrin sayfasında listeler
        public PartialViewResult Index(int id=0)
        {
            var contentlist = cm.GetListByHeadingID(id);

            return PartialView(contentlist);
        }
    }
}