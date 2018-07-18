using AutoMapper;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Services
{
    public class Service : IServiceCommon
    {
        IMapper iMapper;
        public IUnitOfWork context { get; private set; }

        public Service(IUnitOfWork context)
        {
            this.context = context;
            //IKernel ninjectKernel = new StandardKernel();
            //ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            //context = ninjectKernel.Get<IUnitOfWork>();
            MapperInitializer initializer = new MapperInitializer();
            iMapper = initializer.Initialize();
        }

        public async Task<List<TEntityDto>> GetAll<TEntity, TEntityDto>() where TEntity : class
        {
            return iMapper.Map<List<TEntity>, List<TEntityDto>>(await context.Set<IRepository<TEntity>>().GetAll());
        }

        public async Task<TEntityDto> GetById<TEntity, TEntityDto>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
        {
            return iMapper.Map<TEntity, TEntityDto>(await context.Set<IRepository<TEntity>>().GetById(filter));
        }

        public async Task<TEntityDto> Update<TEntityDto, TEntity>(TEntityDto entityDto) where TEntity : class
        {
            TEntity entity = iMapper.Map<TEntityDto, TEntity>(entityDto);
            
            if (entity == null)
                throw new NullReferenceException();

            TEntityDto entitySaved = iMapper.Map<TEntity, TEntityDto> (await context.Set<IRepository<TEntity>>().Update(entity));
            return entitySaved;
        }

        public async Task<TEntityDto> Create<TEntityDto, TEntity>(TEntityDto entityDto) where TEntity : class
        {
            TEntity entity = iMapper.Map<TEntityDto, TEntity>(entityDto);

            if (entity == null)
                throw new NullReferenceException();

            TEntity entityAdded = await context.Set<IRepository<TEntity>>().Create(entity);

            TEntityDto entityCreatedDto = iMapper.Map<TEntity, TEntityDto>(entityAdded);
            context.SaveChages();
            return entityCreatedDto;
        }

        public async Task<bool> Delete<TEntity>(Expression<Func<TEntity, bool>> prEntity) where TEntity : class
        {
            bool result = await context.Set<IRepository<TEntity>>().Delete(prEntity);
            return result;
        }
    }
}
