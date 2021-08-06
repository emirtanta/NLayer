using NLayer.BusinessLayer.Abstract;
using NLayer.DataAccessLayer.Abstract;
using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BusinessLayer.Concrete
{
    public class MessageManager:IMessageService
    {
        IMessageDal _messageDal;
        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        //mesajlara session üzerinden erişim sağlayabilmek için string p değeri oluşturduk
        public List<Message> GetListInbox(string p)
        {
            //geçerli bir yöntem değil
            return _messageDal.List(x => x.ReceiverMail == p);
        }

        //mesajlara session üzerinden erişim sağlayabilmek için string p değeri oluşturduk
        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdate(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
