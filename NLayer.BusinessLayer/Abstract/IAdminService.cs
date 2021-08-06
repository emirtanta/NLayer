using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BusinessLayer.Abstract
{
    public interface IAdminService
    {
        //sadece admin sınıfına ait listeleme fonksiyonu
        List<Admin> GetList();

        //sadece admin sınıfında çalışacak kategori ekleme metodu
        void AdminAdd(Admin admin);

        //admin sınıfında id değerine göre kategoriyi bulur ve geririr 
        Admin GetByID(int id);

        //admin sınıfından seçilen kategoriyi günceller
        void AdminUpdate(Admin admin);

        //admin sınıfından kategori siler
        void AdminDelete(Admin admin);
    }
}
