using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Repositories
{
   public  interface IRepositorieBase<T> : IDisposable
    {
        IQueryable<T> getAll();
        IQueryable<T> getAllBy(System.Linq.Expressions.Expression<Func<T, bool>> conditional);
        T getOne(System.Linq.Expressions.Expression<Func<T, bool>> conditional);
        bool remove(T objectEntity);
        int save(T objectEntity);
        int update(T objectEntity);
    }
}
