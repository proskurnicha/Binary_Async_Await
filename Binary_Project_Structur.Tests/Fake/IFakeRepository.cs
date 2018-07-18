using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structur.Tests.Fake
{
    public class IFakeRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Task<int> AddRange(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }
                          
       
        Task<List<TEntity>> IRepository<TEntity>.GetAll()
        {
            throw new NotImplementedException();

        }

        public Task<TEntity> GetById(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Expression<Func<TEntity, bool>> prEntity)
        {
            throw new NotImplementedException();
        }

        async Task<TEntity> IRepository<TEntity>.Create(TEntity entity)
        {
            return entity;
        }

        async Task<TEntity> IRepository<TEntity>.Update(TEntity entity)
        {
            return entity;
        }
    }
}
