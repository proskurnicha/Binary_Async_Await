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
    public class CrewService : Service, ICrewService
    {
        public CrewService(IUnitOfWork context) : base(context)
        {

        }
        public async Task<List<CrewDto>> GetAll()
        {
            return await GetAll<Crew, CrewDto>();
        }          
                   
        public async Task<CrewDto> GetById(int id)
        {          
            return await GetById<Crew, CrewDto>(x => x.Id == id);
        }          
                   
        public async Task<CrewDto> Create(CrewDto entity)
        {          
            return await Create<CrewDto, Crew>(entity);
        }          
                   
        public async Task<CrewDto> Update(CrewDto entity)
        {          
            return await Update<CrewDto, Crew>(entity);
        }

        async Task<bool> ICrewService.Delete(int id)
        {
            return await Delete<Crew>(x => x.Id == id);
        }
    }
}
