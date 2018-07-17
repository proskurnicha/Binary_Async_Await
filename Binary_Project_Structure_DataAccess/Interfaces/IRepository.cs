using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_DataAccess.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity GetById(Func<TEntity, bool> filter = null);

        TEntity Create(TEntity entity);

        TEntity Update(TEntity id);

        bool Delete(Func<TEntity, bool> prEntity = null);
    }
}
