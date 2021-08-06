using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BusinessLayer.Abstract
{
    public interface IMessageService
    {
        //sadece mesaj sınıfına ait listeleme fonksiyonu
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);

        //sadece mesaj sınıfında çalışacak kategori ekleme metodu
        void MessageAdd(Message message);

        //kategori sınıfında id değerine göre kategoriyi bulur ve geririr 
        Message GetByID(int id);

        //mesaj sınıfından seçilen kategoriyi günceller
        void MessageUpdate(Message message);

        //mesaj sınıfından kategori siler
        void MessageDelete(Message message);
    }
}
