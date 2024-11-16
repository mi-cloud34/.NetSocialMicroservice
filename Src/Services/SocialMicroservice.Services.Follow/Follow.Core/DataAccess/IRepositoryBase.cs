

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Follow.Core.DataAccess
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        T Get(Expression<Func<T, bool>> filter);
        IList<T> GetList();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
