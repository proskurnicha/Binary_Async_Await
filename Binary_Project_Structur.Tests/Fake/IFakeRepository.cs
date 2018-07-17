using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structur.Tests.Fake
{
    public class IFakeRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public TEntity Create(TEntity entity)
        {
            return entity;
        }

        public bool Delete(Func<TEntity, bool> prEntity = null)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public TEntity GetById(Func<TEntity, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            return entity;
        }
    }
}
