using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;

namespace Binary_Project_Structure_BLL.Services
{
    public class DepartureService : Service, IDepartureService
    {
        public DepartureService(IUnitOfWork context) : base(context)
        {

        }
        public List<DepartureDto> GetAll()
        {
            return GetAll<Departure, DepartureDto>();
        }

        public DepartureDto GetById(int id)
        {
            return GetById<Departure, DepartureDto>(x => x.Id == id);
        }

        public DepartureDto Create(DepartureDto entity)
        {
            return Create<DepartureDto, Departure>(entity);
        }

        public DepartureDto Update(DepartureDto entity)
        {
            return Update<DepartureDto, Departure>(entity);
        }

        bool IDepartureService.Delete(int id)
        {
            return Delete<Departure>(x => x.Id == id);
        }
    }
}
