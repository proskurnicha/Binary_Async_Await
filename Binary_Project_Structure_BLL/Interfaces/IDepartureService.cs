using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface IDepartureService
    {
        List<DepartureDto> GetAll();
        DepartureDto GetById(int id);
        DepartureDto Create(DepartureDto entity);
        DepartureDto Update(DepartureDto entity);
        bool Delete(int id);
    }
}
