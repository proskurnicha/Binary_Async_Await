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
    public class AircraftService : Service, IAircraftService
    {
        public AircraftService(IUnitOfWork context) : base(context)
        {

        }
        public async Task<List<AircraftDto>> GetAll()
        {
            return await GetAll<Aircraft, AircraftDto>();
        }

        public async Task<AircraftDto> GetById(int id)
        {
            return await GetById<Aircraft, AircraftDto>(x => x.Id == id);
        }

        public async Task<AircraftDto> Create(AircraftDto entity)
        {
            return await Create<AircraftDto, Aircraft>(entity);
        }

        public async Task<AircraftDto> Update(AircraftDto entity)
        {
            return await Update<AircraftDto, Aircraft>(entity);
        }

        async Task<bool> IAircraftService.Delete(int id)
        {
            return await Delete<Aircraft>(x => x.Id == id);
        }
    }
}
