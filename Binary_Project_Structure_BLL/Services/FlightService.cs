using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_Shared.DTOs;
using Binary_Project_Structure_DataAccess.Models;
using AutoMapper;
using Ninject;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Services
{
    public class FlightService : Service, IFlightService 
    {
        public FlightService(IUnitOfWork context) : base(context)
        {

        }
        public async  Task<List<FlightDto>> GetAll()
        {
            return await GetAll<Flight, FlightDto>();
        }

        public async Task<FlightDto> GetById(int id)
        {
            return await GetById<Flight, FlightDto>(x => x.Id == id);
        }

        public async Task<FlightDto> Create(FlightDto entity)
        {
            return await Create<FlightDto, Flight>(entity);
        }

        public async Task<FlightDto> Update(FlightDto entity)
        {
            return await Update<FlightDto, Flight>(entity);
        }

        async Task<bool> IFlightService.Delete(int id)
        {
            return await Delete<Flight>(x => x.Id == id);
        }
    }
}
