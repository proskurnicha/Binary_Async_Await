using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;

namespace Binary_Project_Structure_BLL.Services
{
    public class StewardessService : Service, IStewardessService
    {
        public StewardessService(IUnitOfWork context) : base(context)
        {

        }

        public List<StewardessDto> GetAll()
        {
            return GetAll<Stewardess, StewardessDto>();
        }

        public StewardessDto GetById(int id)
        {
            return GetById<Stewardess, StewardessDto>(x => x.Id == id);
        }

        public StewardessDto Create(StewardessDto entity)
        {
            return Create<StewardessDto, Stewardess>(entity);
        }

        public StewardessDto Update(StewardessDto entity)
        {
            return  Update<StewardessDto, Stewardess>(entity);
        }

        bool IStewardessService.Delete(int id)
        {
            return Delete<Stewardess>(x => x.Id == id);
        }
    }
}
