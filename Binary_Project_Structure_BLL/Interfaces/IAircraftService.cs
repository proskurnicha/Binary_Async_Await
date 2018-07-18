using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface IAircraftService
    {
        Task<List<AircraftDto>> GetAll();
        Task<AircraftDto> GetById(int id);
        Task<AircraftDto> Create(AircraftDto entity);
        Task<AircraftDto> Update(AircraftDto entity);
        Task<bool> Delete(int id);
    }
}
