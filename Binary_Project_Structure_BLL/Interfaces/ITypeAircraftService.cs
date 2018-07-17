using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface ITypeAircraftService
    {
        List<TypeAircraftDto> GetAll();
        TypeAircraftDto GetById(int id);
        TypeAircraftDto Create(TypeAircraftDto entity);
        TypeAircraftDto Update(TypeAircraftDto entity);
        bool Delete(int id);
    }
}
