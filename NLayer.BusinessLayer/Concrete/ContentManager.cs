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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        //şarta göre tek değer getirir
        public Category GetByID(int id)
        {
            throw new NotImplementedException();
        }

        //tüm listeyi aranacak kelimeye göre getirir
        public List<Content> GetList(string p)
        {
            return _contentDal.List(x=>x.ContentValue.Contains(p));
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }

        //şarta göre listeleme yapar
        public List<Content> GetListByID(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        //yazara göre yazıları listeler
        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x=>x.WriterID==id);
        }

        #region Açıklama Düzenleme Bölümü



        #endregion
    }
}
