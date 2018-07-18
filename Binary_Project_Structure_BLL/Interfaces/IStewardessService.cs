using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface IStewardessService
    {
        Task<List<StewardessDto>> GetAll();
        Task<StewardessDto> GetById(int id);
        Task<StewardessDto> Create(StewardessDto entity);
        Task<StewardessDto> Update(StewardessDto entity);
        Task<bool> Delete(int id);
    }
}
