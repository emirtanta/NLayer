using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        //sadece kategori sınıfına ait listeleme fonksiyonu
        List<Category> GetList();

        //sadece kategori sınıfında çalışacak kategori ekleme metodu
        void CategoryAddBL(Category category);

        //kategori sınıfında id değerine göre kategoriyi bulur ve geririr 
        Category GetByID(int id);

        //kategori sınıfından seçilen kategoriyi günceller
        void CategoryUpdate(Category category);

        //kategori sınıfından kategori siler
        void CategoryDelete(Category category);
    }
}
