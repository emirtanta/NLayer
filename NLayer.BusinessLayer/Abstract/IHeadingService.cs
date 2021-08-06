using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        //sadece başlık sınıfına ait listeleme fonksiyonu
        List<Heading> GetList();

        //yazarın yazdığı başlıkları listeler
        List<Heading> GetListByWriter(int id);

        //sadece başlık sınıfında çalışacak kategori ekleme metodu
        void HeadingAdd(Heading heading);

        //başlık sınıfında id değerine göre kategoriyi bulur ve geririr 
        Heading GetByID(int id);

        //kategori sınıfından seçilen kategoriyi günceller
        void HeadingUpdate(Heading heading);

        //kategori sınıfından kategori siler
        void HeadingDelete(Heading heading);
    }
}
