using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;

namespace Binary_Project_Structure_BLL.Services
{
    public class PilotService : Service, IPilotService
    {
        public PilotService(IUnitOfWork context) : base(context)
        {

        }

        public List<PilotDto> GetAll()
        {
            return GetAll<Pilot, PilotDto>();
        }

        public PilotDto GetById(int id)
        {
            return GetById<Pilot, PilotDto>(x => x.Id == id);
        }

        public PilotDto Create(PilotDto entity)
        {
            return Create<PilotDto, Pilot>(entity);
        }

        public PilotDto Update(PilotDto entity)
        {
            return Update<PilotDto, Pilot>(entity);
        }

        bool IPilotService.Delete(int id)
        {
            return Delete<Pilot>(x => x.Id == id);
        }
    }
}
