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

        public async virtual Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async virtual Task<TEntity> GetById(Expression<Func<TEntity, bool>> filter)
        {
            TEntity query = await context.Set<TEntity>().FirstOrDefaultAsync((filter));

            if (query == null)
                return null;

            return query;
        }

        public async virtual Task<TEntity> Create(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            int result = context.SaveChanges();
            return await context.Set<TEntity>().LastOrDefaultAsync(); ;
        }

        public async virtual Task<TEntity> Update(TEntity entity)
        {
            return null;
        }

        public async virtual Task<bool> Delete(Expression<Func<TEntity, bool>> prEntity)
        {
            TEntity entity = await context.Set<TEntity>().FirstOrDefaultAsync(prEntity);

            if (entity == null)
                return false;

            List<TEntity> entities = await context.Set<TEntity>().ToListAsync();
            entities.Remove(entity);
            context.SaveChanges();
            return true;
        }
    }
}
