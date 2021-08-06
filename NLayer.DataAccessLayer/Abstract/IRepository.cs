using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();

        //liste içerisinden gerekli şarta göre veriyi getirerek listeleme
        List<T> List(Expression<Func<T, bool>> filter);

        //id değerine göre tek değeri getirir
        T Get(Expression<Func<T, bool>> filter);

        void Insert(T p);
        void Update(T p);
        void Delete(T p);
    }
}
