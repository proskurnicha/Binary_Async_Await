using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface ICrewService
    {
        List<CrewDto> GetAll();
        CrewDto GetById(int id);
        CrewDto Create(CrewDto entity);
        CrewDto Update(CrewDto entity);
        bool Delete(int id);
    }
}
