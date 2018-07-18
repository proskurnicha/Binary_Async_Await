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
    public class StewardessService : Service, IStewardessService
    {
        public StewardessService(IUnitOfWork context) : base(context)
        {

        }

        public async Task<List<StewardessDto>> GetAll()
        {
            return await GetAll<Stewardess, StewardessDto>();
        }

        public async Task<StewardessDto> GetById(int id)
        {
            return await GetById<Stewardess, StewardessDto>(x => x.Id == id);
        }

        public async Task<StewardessDto> Create(StewardessDto entity)
        {
            return await Create<StewardessDto, Stewardess>(entity);
        }

        public async Task<StewardessDto> Update(StewardessDto entity)
        {
            return await Update<StewardessDto, Stewardess>(entity);
        }

        async Task<bool> IStewardessService.Delete(int id)
        {
            return await Delete<Stewardess>(x => x.Id == id);
        }
    }
}
