using AutoMapper;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Services
{
    public class TicketService : Service, ITicketService
    {
        public TicketService(IUnitOfWork context) : base(context)
        {

        }

        public async Task<List<TicketDto>> GetAll()
        {
            return await GetAll<Ticket, TicketDto>();
        }

        public async Task<TicketDto> GetById(int id)
        {
            return await GetById<Ticket, TicketDto>(x => x.Id == id);
        }

        public async Task<TicketDto> Create(TicketDto entity)
        {
            return await Create<TicketDto, Ticket>(entity);
        }

        public async Task<TicketDto> Update(TicketDto entity)
        {
            return await Update<TicketDto, Ticket>(entity);
        }

        async Task<bool> ITicketService.Delete(int id)
        {
            return await Delete<Ticket>(x => x.Id == id);
        }
    }
}
