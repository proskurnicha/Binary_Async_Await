using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<List<PilotDto>> GetAll()
        {
            return await GetAll<Pilot, PilotDto>();
        }

        public async Task<PilotDto> GetById(int id)
        {
            return await GetById<Pilot, PilotDto>(x => x.Id == id);
        }

        public async Task<PilotDto> Create(PilotDto entity)
        {
            return await Create<PilotDto, Pilot>(entity);
        }

        public async Task<PilotDto> Update(PilotDto entity)
        {
            return await Update<PilotDto, Pilot>(entity);
        }

        async Task<bool> IPilotService.Delete(int id)
        {
            return await Delete<Pilot>(x => x.Id == id);
        }
    }
}
