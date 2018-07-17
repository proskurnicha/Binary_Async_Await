using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface IAircraftService
    {
        List<AircraftDto> GetAll();
        AircraftDto GetById(int id);
        AircraftDto Create(AircraftDto entity);
        AircraftDto Update(AircraftDto entity);
        bool Delete(int id);
    }
}
