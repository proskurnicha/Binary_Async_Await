using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Binary_Project_Structure_DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DatabaseContext context;

        public DatabaseContext Context
        {
            get
            {
                return context;
            }
            private set
            {
                context = value;
            }
        }

        public Repository()
        {
            context = new DatabaseContext();
        }

        public virtual List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(Func<TEntity, bool> filter = null)
        {
            var query = context.Set<TEntity>().Where(filter);
            if (query.Count() == 0)
                return null;

            return query.Where(filter).First();
        }

        public virtual TEntity Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            int result = context.SaveChanges();
            return context.Set<TEntity>().LastOrDefault(); ;
        }

        public virtual TEntity Update(TEntity entity)
        {
            return null;
        }

        public virtual bool Delete(Func<TEntity, bool> prEntity = null)
        {
            TEntity entity = context.Set<TEntity>().FirstOrDefault(prEntity);

            if (entity == null)
                return false;

            List<TEntity> entities = context.Set<TEntity>().ToList();
            entities.Remove(entity);
            context.SaveChanges();
            return true;
        }
    }
}
