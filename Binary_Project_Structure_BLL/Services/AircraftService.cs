using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;

namespace Binary_Project_Structure_BLL.Services
{
    public class AircraftService : Service, IAircraftService
    {
        public AircraftService(IUnitOfWork context) : base(context)
        {

        }
        public List<AircraftDto> GetAll()
        {
            return GetAll<Aircraft, AircraftDto>();
        }

        public AircraftDto GetById(int id)
        {
            return GetById<Aircraft, AircraftDto>(x => x.Id == id);
        }

        public AircraftDto Create(AircraftDto entity)
        {
            return Create<AircraftDto, Aircraft>(entity);
        }

        public AircraftDto Update(AircraftDto entity)
        {
            return Update<AircraftDto, Aircraft>(entity);
        }

        bool IAircraftService.Delete(int id)
        {
            return Delete<Aircraft>(x => x.Id == id);
        }
    }
}
