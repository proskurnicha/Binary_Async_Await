using AutoMapper;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structure_BLL.Services
{
    class MapperInitializer
    {
        IMapper iMapper;
        
        public IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Aircraft, AircraftDto>();
                cfg.CreateMap<AircraftDto, Aircraft>();
                cfg.CreateMap<Crew, CrewDto>();
                cfg.CreateMap<CrewDto, Crew>();
                cfg.CreateMap<Departure, DepartureDto>();
                cfg.CreateMap<DepartureDto, Departure>();
                cfg.CreateMap<Flight, FlightDto>();
                cfg.CreateMap<FlightDto, Flight>();
                cfg.CreateMap<Pilot, PilotDto>();
                cfg.CreateMap<PilotDto, Pilot>();
                cfg.CreateMap<Stewardess, StewardessDto>();
                cfg.CreateMap<StewardessDto, Stewardess>();
                cfg.CreateMap<Ticket, TicketDto>();
                cfg.CreateMap<TicketDto, Ticket>();
                cfg.CreateMap<TypeAircraft, TypeAircraftDto>();
                cfg.CreateMap<TypeAircraftDto, TypeAircraft>();
            });
            iMapper = config.CreateMapper();
            return iMapper;
        }
    }
}
