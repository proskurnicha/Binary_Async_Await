using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;

namespace Binary_Project_Structure_BLL.Services
{
    public class TypeAircraftService : Service, ITypeAircraftService
    {
        public TypeAircraftService(IUnitOfWork context) : base(context)
        {

        }

        public List<TypeAircraftDto> GetAll()
        {
            return GetAll<TypeAircraft, TypeAircraftDto>();
        }

        public TypeAircraftDto GetById(int id)
        {
            return GetById<TypeAircraft, TypeAircraftDto>(x => x.Id == id);
        }

        public TypeAircraftDto Create(TypeAircraftDto entity)
        {
            return Create<TypeAircraftDto, TypeAircraft>(entity);
        }

        public TypeAircraftDto Update(TypeAircraftDto entity)
        {
            return Update<TypeAircraftDto, TypeAircraft>(entity);
        }

        bool ITypeAircraftService.Delete(int id)
        {
            return Delete<TypeAircraft>(x => x.Id == id);
        }
    }
}
