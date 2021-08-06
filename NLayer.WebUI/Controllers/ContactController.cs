using NLayer.BusinessLayer.Concrete;
using NLayer.BusinessLayer.ValidationRules;
using NLayer.DataAccessLayer.Abstract;
using NLayer.DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NLayer.WebUI.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());

        ContactValidator cv = new ContactValidator();

        

        // GET: Contact
        public ActionResult Index()
        {
            var contactvalues = contactManager.GetList();

            return View(contactvalues);
        }

        #region Mesajın Detayları Sayfası

        public ActionResult ContactDetails(int id)
        {
            var contactvalues = contactManager.GetByID(id);

            return View(contactvalues);
        }

        //gelen kutusu-gönderilmiş mesajlar gibi yerleri partial view içerisinde tanımladık
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        #endregion
    }
}