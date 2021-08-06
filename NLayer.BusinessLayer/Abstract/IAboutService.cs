using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BusinessLayer.Abstract
{
    public interface IAboutService
    {
        //sadece kategori sınıfına ait listeleme fonksiyonu
        List<About> GetList();

        //sadece kategori sınıfında çalışacak kategori ekleme metodu
        void AboutAdd(About about);

        //kategori sınıfında id değerine göre kategoriyi bulur ve geririr 
        About GetByID(int id);

        //kategori sınıfından seçilen kategoriyi günceller
        void AboutUpdate(About about);

        //kategori sınıfından kategori siler
        void AboutDelete(About about);
    }
}
