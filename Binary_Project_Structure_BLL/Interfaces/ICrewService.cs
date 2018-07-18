using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface ICrewService
    {
        Task<List<CrewDto>> GetAll();
        Task<CrewDto> GetById(int id);
        Task<CrewDto> Create(CrewDto entity);
        Task<CrewDto> Update(CrewDto entity);
        Task<bool> Delete(int id);
        Task AddRange(List<CrewByApiDto> entity);
    }
}
