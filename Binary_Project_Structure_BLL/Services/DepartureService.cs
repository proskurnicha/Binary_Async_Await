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
    public class DepartureService : Service, IDepartureService
    {
        public DepartureService(IUnitOfWork context) : base(context)
        {

        }
        public async Task<List<DepartureDto>> GetAll()
        {
            return await GetAll<Departure, DepartureDto>();
        }

        public async Task<DepartureDto> GetById(int id)
        {
            return await GetById<Departure, DepartureDto>(x => x.Id == id);
        }

        public async Task<DepartureDto> Create(DepartureDto entity)
        {
            return await Create<DepartureDto, Departure>(entity);
        }

        public async Task<DepartureDto> Update(DepartureDto entity)
        {
            return await Update<DepartureDto, Departure>(entity);
        }

        async Task<bool> IDepartureService.Delete(int id)
        {
            return await Delete<Departure>(x => x.Id == id);
        }
    }
}
