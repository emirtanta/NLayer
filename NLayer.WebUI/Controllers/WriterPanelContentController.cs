using NLayer.BusinessLayer.Concrete;
using NLayer.DataAccessLayer.Concrete;
using NLayer.DataAccessLayer.EntityFramework;
using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayer.WebUI.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal());

        Context c = new Context();

        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            

            p = (string)Session["WriterMail"];

            //sisteme girin yazarın email adresine göre Sessina veri aktarabilmek için tanımlandı
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();

            var contentvalues = cm.GetListByWriter(writeridinfo);

            return View(contentvalues);
        }

        //başlığın içindeki içeriklere yazı yazma sayfası
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;

            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail= (string)Session["WriterMail"];

            //sisteme girin yazarın email adresine göre Sessina veri aktarabilmek için tanımlandı
            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();

            p.ContentDate =DateTime.Parse(DateTime.Now.ToShortDateString());

            p.WriterID = writeridinfo;
            p.ContentStatus = true;

            cm.ContentAdd(p);

            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}