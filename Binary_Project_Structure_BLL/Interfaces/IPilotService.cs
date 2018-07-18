using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface IPilotService
    {
        Task<List<PilotDto>> GetAll();
        Task<PilotDto> GetById(int id);
        Task<PilotDto> Create(PilotDto entity);
        Task<PilotDto> Update(PilotDto entity);
        Task<bool> Delete(int id);
    }
}
