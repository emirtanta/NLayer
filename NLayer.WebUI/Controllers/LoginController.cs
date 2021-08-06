using NLayer.BusinessLayer.Concrete;
using NLayer.DataAccessLayer.Concrete;
using NLayer.DataAccessLayer.EntityFramework;
using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security; //Session tanımlamalarında kullanılır

namespace NLayer.WebUI.Controllers
{
    [AllowAnonymous] //terimi ile sadece LoginController içersindeki sayfalara erişim açılır
    public class LoginController : Controller
    {
        WriterLoginManager wm = new WriterLoginManager(new EWriterDal());

        #region Admin Login bölümü

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x=>x.AdminUserName==p.AdminUserName && x.AdminPassword==p.AdminPassword);

            if (adminuserinfo!=null)
            {
                //false=> kalıcı olarak cookie oluşmasını engeller.
                //true=> kalıcı olarak cookie oluşturur
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName,false);

                Session["AdminUserName"] = adminuserinfo.AdminUserName;

                return RedirectToAction("Index", "Category");
            }

            else
            {
                return RedirectToAction("Index");
            }

        }

        #endregion

        #region Yazar login bölümü

        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer p)
        {
            //Context c = new Context();
            //var writeruserinfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);

            var writeruserinfo = wm.GetWriter(p.WriterMail, p.WriterPassword);

            if (writeruserinfo != null)
            {
                //false=> kalıcı olarak cookie oluşmasını engeller.
                //true=> kalıcı olarak cookie oluşturur
                FormsAuthentication.SetAuthCookie(writeruserinfo.WriterMail, false);

                Session["WriterMail"] = writeruserinfo.WriterMail;

                return RedirectToAction("MyContent","WriterPanelContent");
            }

            else
            {
                return RedirectToAction("Index");
            }
        }

        #endregion

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            Session.Abandon();

            return RedirectToAction("Headings", "Default");
        }
    }
}