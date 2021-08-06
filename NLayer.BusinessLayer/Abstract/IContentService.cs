using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BusinessLayer.Abstract
{
    public interface IContentService
    {
        //tüm yazarları listeleme
        //List<Content> GetList();

        //tüm yazarları listeleme aranacak kelimeye göre listeler
        List<Content> GetList(string p);

        //yazara gmre yazıları listeler
        List<Content> GetListByWriter(int id);

        //şarta göre listeleme
        List<Content> GetListByID(int id);

        List<Content> GetListByHeadingID(int id);

        //sadece kategori sınıfında çalışacak kategori ekleme metodu
        void ContentAdd(Content content);

        //kategori sınıfında id değerine göre kategoriyi bulur ve geririr 
        Category GetByID(int id);

        //kategori sınıfından seçilen kategoriyi günceller
        void ContentUpdate(Content content);

        //kategori sınıfından kategori siler
        void ContentDelete(Content content);
    }
}
