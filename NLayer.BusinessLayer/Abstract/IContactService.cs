using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BusinessLayer.Abstract
{
   public  interface IContactService
    {
        //sadece contact sınıfına ait listeleme fonksiyonu
        List<Contact> GetList();

        //sadece contact sınıfında çalışacak kategori ekleme metodu
        void ContactAdd(Contact contact);

        //contact sınıfında id değerine göre kategoriyi bulur ve geririr 
        Contact GetByID(int id);

        //contact sınıfından seçilen kategoriyi günceller
        void ContactUpdate(Contact contact);

        //contact sınıfından kategori siler
        void ContactDelete(Contact contact);
    }
}
