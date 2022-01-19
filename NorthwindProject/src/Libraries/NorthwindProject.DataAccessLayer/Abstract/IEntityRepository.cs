using NorthwindProject.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.DataAccessLayer.Abstract
{
    public interface IEntityRepository<T> where T : EntityBase
    {
        T Add(T entity);
        T Update(T entity);
        T Find(int id);
        
        List<T> GetAll();
        
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression); //expression filtre vermemizi sağlayan yapı.
        bool Delete(int id);
        bool Delete(T entity);
    }
}
