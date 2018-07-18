using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface IFlightService
    {
        Task<List<FlightDto>> GetAll();
        Task<FlightDto> GetById(int id);
        Task<FlightDto> Create(FlightDto entity);
        Task<FlightDto> Update(FlightDto entity);
        Task<bool> Delete(int id);
    }
}
