using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.Repositories.Infrastructure
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IList<TEntity> GetAll();
        TEntity Find(int id);
        TEntity FindByCondition(Func<TEntity, bool> condition);
        IList<TEntity> GetByCondition(Func<TEntity, bool> condition);
        IList<TEntity> GetPagedItems(int page, int pageSize);
        void Insert(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        void DeleteById(int id);
        int CountAll();
    }
}
