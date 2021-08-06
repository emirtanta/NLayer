using NLayer.BusinessLayer.Concrete;
using NLayer.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayer.WebUI.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ifm = new ImageFileManager(new EfImageFileDal());

        // GET: Gallery listesi
        public ActionResult Index()
        {
            var files = ifm.GetList();
            return View(files);
        }
    }
}