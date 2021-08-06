using NLayer.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        //sadece kategori sınıfına ait listeleme fonksiyonu
        List<ImageFile> GetList();
    }
}
