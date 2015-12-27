using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AD_Repositories
{
    public abstract class Repositorie<TContext, T> : IRepositorieBase<T>
        where TContext : DbContext, new()
        where T: class
    {
        private TContext _DataContext;

        public Repositorie()
        {
            _DataContext = new TContext();
        }

        protected virtual TContext DataContext
        {
            get
            {
                if (_DataContext == null)
                {
                    _DataContext = new TContext();
                }
                return _DataContext;
            }
        }

        public IQueryable<T> getAll()
        {
            return DataContext.Set<T>();
        }

        public IQueryable<T> getAllBy(System.Linq.Expressions.Expression<Func<T, bool>> conditional)
        {
            if (conditional != null)
            {
                if (DataContext != null)
                {
                    return DataContext.Set<T>().Where(conditional).AsQueryable<T>();
                }
            }
            throw new ArgumentNullException("A condicional DEVE ser passada no parametro.");
        }

        public T getOne(System.Linq.Expressions.Expression<Func<T, bool>> conditional)
        {
            if (conditional != null)
            {
                if (DataContext != null)
                {
                    return DataContext.Set<T>().Where(conditional).SingleOrDefault();
                }
            }
            throw new ArgumentNullException("A condicional DEVE ser passada no parametro.");
        }

        public bool remove(T objectEntity)
        {
            if (objectEntity != null)
            {
                var oElemento = DataContext.Entry(objectEntity);
                DataContext.Set<T>().Remove(objectEntity);
                var result = DataContext.SaveChanges();
                return (result > 0) ? true : false;
            }
            throw new ArgumentNullException("A entidade DEVE ser passada no parametro.");
        }

        public int save(T objectEntity)
        {
            if (objectEntity != null)
            {
                if (DataContext.Entry<T>(objectEntity).State == EntityState.Detached)
                {
                    DataContext.Set<T>().Attach(objectEntity);
                }
                DataContext.Set<T>().Add(objectEntity);
                return DataContext.SaveChanges();
            }
            throw new ArgumentNullException("A entidade DEVE ser passada no parametro.");
        }

        public int update(T objectEntity)
        {
            if (objectEntity != null)
            {
                var oElemento = DataContext.Entry(objectEntity);
                DataContext.Entry(oElemento).CurrentValues.SetValues(objectEntity);
                return DataContext.SaveChanges();
            }
            throw new ArgumentNullException("A entidade DEVE ser passada no parametro.");
        }

        public void Dispose()
        {
            if (DataContext != null) DataContext.Dispose();
        }
    }
}
