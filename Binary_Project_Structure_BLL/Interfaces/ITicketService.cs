using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Interfaces
{
    public interface ITicketService
    {
        Task<List<TicketDto>> GetAll();
        Task<TicketDto> GetById(int id);
        Task<TicketDto> Create(TicketDto entity);
        Task<TicketDto> Update(TicketDto entity);
        Task<bool> Delete(int id);
    }
}
