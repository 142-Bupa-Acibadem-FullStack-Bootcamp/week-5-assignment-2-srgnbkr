using NorthwindProject.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.DataAccessLayer.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IEntityRepository<T> GetRepository<T>() where T : EntityBase;
        bool BeginTransaction();
        bool RollBackTransaction();
        int SaveChanges();
    }
}
