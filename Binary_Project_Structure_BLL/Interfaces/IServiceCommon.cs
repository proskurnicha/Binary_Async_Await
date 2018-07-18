using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface IServiceCommon
    {
        Task<List<TEntityDto>> GetAll<TEntity, TEntityDto>() where TEntity : class;

        Task<TEntityDto> GetById<TEntity, TEntityDto>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;

        Task<TEntityDto> Update<TEntityDto, TEntity>(TEntityDto entityDto) where TEntity : class;

        Task<TEntityDto> Create<TEntityDto, TEntity>(TEntityDto entityDto) where TEntity : class;

        Task<bool> Delete<TEntity>(Expression<Func<TEntity, bool>> prEntity) where TEntity : class;

        //Task<int> AddRange<TEntityByIdDto, TEntity>(List<TEntityByIdDto> entitiesDto) where TEntity : class;

    }
}
