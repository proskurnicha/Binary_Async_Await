using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface ITicketService
    {
        List<TicketDto> GetAll();
        TicketDto GetById(int id);
        TicketDto Create(TicketDto entity);
        TicketDto Update(TicketDto entity);
        bool Delete(int id);
    }
}
