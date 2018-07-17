using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface IPilotService
    {
        List<PilotDto> GetAll();
        PilotDto GetById(int id);
        PilotDto Create(PilotDto entity);
        PilotDto Update(PilotDto entity);
        bool Delete(int id);
    }
}
