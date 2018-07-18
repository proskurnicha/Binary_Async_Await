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
    public class TypeAircraftService : Service, ITypeAircraftService
    {
        public TypeAircraftService(IUnitOfWork context) : base(context)
        {

        }

        public async Task<List<TypeAircraftDto>> GetAll()
        {
            return await GetAll<TypeAircraft, TypeAircraftDto>();
        }

        public async Task<TypeAircraftDto> GetById(int id)
        {
            return await GetById<TypeAircraft, TypeAircraftDto>(x => x.Id == id);
        }

        public async Task<TypeAircraftDto> Create(TypeAircraftDto entity)
        {
            return await Create<TypeAircraftDto, TypeAircraft>(entity);
        }

        public async Task<TypeAircraftDto> Update(TypeAircraftDto entity)
        {
            return await Update<TypeAircraftDto, TypeAircraft>(entity);
        }

        async Task<bool> ITypeAircraftService.Delete(int id)
        {
            return await Delete<TypeAircraft>(x => x.Id == id);
        }
    }
}
