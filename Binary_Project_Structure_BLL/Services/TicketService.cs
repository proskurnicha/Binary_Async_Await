using AutoMapper;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structure_BLL.Services
{
    public class TicketService : Service, ITicketService
    {
        public TicketService(IUnitOfWork context) : base(context)
        {

        }

        public List<TicketDto> GetAll()
        {
            return GetAll<Ticket, TicketDto>();
        }

        public TicketDto GetById(int id)
        {
            return GetById<Ticket, TicketDto>(x => x.Id == id);
        }

        public TicketDto Create(TicketDto entity)
        {
            return Create<TicketDto, Ticket>(entity);
        }

        public TicketDto Update(TicketDto entity)
        {
            return Update<TicketDto, Ticket>(entity);
        }

        bool ITicketService.Delete(int id)
        {
            return Delete<Ticket>(x => x.Id == id);
        }
    }
}
