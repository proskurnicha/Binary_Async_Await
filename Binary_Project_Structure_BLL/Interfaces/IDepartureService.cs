using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface IDepartureService
    {
        Task<List<DepartureDto>> GetAll();
        Task<DepartureDto> GetById(int id);
        Task<DepartureDto> Create(DepartureDto entity);
        Task<DepartureDto> Update(DepartureDto entity);
        Task<bool> Delete(int id);
    }
}
