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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;
        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        //galerideki resimleri listeler
        public List<ImageFile> GetList()
        {
            return _imageFileDal.List();
        }
    }
}
