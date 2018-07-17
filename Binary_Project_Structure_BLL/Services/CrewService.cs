using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;

namespace Binary_Project_Structure_BLL.Services
{
    public class CrewService : Service, ICrewService
    {
        public CrewService(IUnitOfWork context) : base(context)
        {

        }
        public List<CrewDto> GetAll()
        {
            return GetAll<Crew, CrewDto>();
        }

        public CrewDto GetById(int id)
        {
            return GetById<Crew, CrewDto>(x => x.Id == id);
        }

        public CrewDto Create(CrewDto entity)
        {
            return Create<CrewDto, Crew>(entity);
        }

        public CrewDto Update(CrewDto entity)
        {
            return Update<CrewDto, Crew>(entity);
        }

        bool ICrewService.Delete(int id)
        {
            return Delete<Crew>(x => x.Id == id);
        }
    }
}
