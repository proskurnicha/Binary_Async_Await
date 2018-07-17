using AutoMapper;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

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

        public  List<TEntityDto> GetAll<TEntity, TEntityDto>() where TEntity : class
        {
            return iMapper.Map<List<TEntity>, List<TEntityDto>>(context.Set<IRepository<TEntity>>().GetAll());
        }

        public TEntityDto GetById<TEntity, TEntityDto>(Func<TEntity, bool> filter = null) where TEntity : class
        {
            return iMapper.Map<TEntity, TEntityDto>(context.Set<IRepository<TEntity>>().GetById(filter));
        }

        public TEntityDto Update<TEntityDto, TEntity>(TEntityDto entityDto) where TEntity : class
        {
            TEntity entity = iMapper.Map<TEntityDto, TEntity>(entityDto);
            
            if (entity == null)
                throw new NullReferenceException();

            TEntityDto entitySaved = iMapper.Map<TEntity, TEntityDto> (context.Set<IRepository<TEntity>>().Update(entity));
            return entitySaved;
        }

        public TEntityDto Create<TEntityDto, TEntity>(TEntityDto entityDto) where TEntity : class
        {
            TEntity entity = iMapper.Map<TEntityDto, TEntity>(entityDto);

            if (entity == null)
                throw new NullReferenceException();

            TEntity entityAdded = context.Set<IRepository<TEntity>>().Create(entity);

            TEntityDto entityCreatedDto = iMapper.Map<TEntity, TEntityDto>(entityAdded);
            context.SaveChages();
            return entityCreatedDto;
        }

        public bool Delete<TEntity>(Func<TEntity, bool> prEntity) where TEntity : class
        {
            bool result = context.Set<IRepository<TEntity>>().Delete(prEntity);
            return result;
        }
    }
}
