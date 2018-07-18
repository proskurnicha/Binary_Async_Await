using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface ITypeAircraftService
    {
        Task<List<TypeAircraftDto>> GetAll();
        Task<TypeAircraftDto>  GetById(int id);
        Task<TypeAircraftDto> Create(TypeAircraftDto entity);
        Task<TypeAircraftDto> Update(TypeAircraftDto entity);
        Task<bool> Delete(int id);
    }
}
