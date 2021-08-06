using FluentValidation.Results;
using NLayer.BusinessLayer.Concrete;
using NLayer.BusinessLayer.ValidationRules;
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
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageManager = new MessageManager(new EfMessageDal());

        MessageValidator messageValidator = new MessageValidator();


        // GET: WriterPanelMessage
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterMail"];

            var messagelist = messageManager.GetListInbox(p);

            return View(messagelist);
        }

        //gelen kutusu
        public ActionResult SendBox()
        {
            string p = (string)Session["WriterMail"];

            var messagelist = messageManager.GetListSendbox(p);

            return View(messagelist);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        //gelen kutusu mesaj detaylar
        public ActionResult SendboxMessageDetails(int id)
        {
            var values = messageManager.GetByID(id);

            return View(values);
        }

        //gelen kutusu mesaj detaylar
        public ActionResult InboxMessageDetails(int id)
        {
            var values = messageManager.GetByID(id);

            return View(values);
        }

        //yeni mesaj sayfası
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message p)
        {
            string sender = (string)Session["WriterMail"];

            ValidationResult results = messageValidator.Validate(p);

            if (results.IsValid)
            {
                p.SenderMail = sender;
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(p);

                return RedirectToAction("SendBox");
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
    }
}