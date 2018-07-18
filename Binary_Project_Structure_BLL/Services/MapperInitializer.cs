using AutoMapper;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
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
                cfg.CreateMap<CrewByApiDto, Crew>()
                .ForMember(x => x.Id,
                            m => m.MapFrom(a => a.Id))
                 .ForMember(x => x.Pilot, opt => opt.Ignore())
                 .ForMember(x => x.Stewardesses, opt => opt.Ignore())
                 .ForMember(x => x.PilotId,
                            m => m.MapFrom(a => a.Pilot[0].Id)).ReverseMap();

                cfg.CreateMap<CrewByApiDto, Pilot>()
               .ForMember(x => x.Id,
                           m => m.MapFrom(a => a.Pilot.FirstOrDefault().Id))
               .ForMember(x => x.DateBirth,
                           m => m.MapFrom(a => a.Pilot.FirstOrDefault().BirthDate))
                .ForMember(x => x.Experience,
                           m => m.MapFrom(a => a.Pilot.FirstOrDefault().Exp))
               .ForMember(x => x.Name,
                           m => m.MapFrom(a => a.Pilot.FirstOrDefault().FirstName))
                .ForMember(x => x.Surname,
                           m => m.MapFrom(a => a.Pilot.FirstOrDefault().LastName)).ReverseMap();


                cfg.CreateMap<StewardessByApiDto, Stewardess>()
                 .ForMember(x => x.CrewId,
                           m => m.MapFrom(a => a.CrewId))
               .ForMember(x => x.DateBirth,
                           m => m.MapFrom(a => a.BirthDate))
                .ForMember(x => x.Id,
                           m => m.MapFrom(a => a.Id))
               .ForMember(x => x.Name,
                           m => m.MapFrom(a => a.FirstName))
                .ForMember(x => x.Surname,
                           m => m.MapFrom(a => a.LastName)).ReverseMap();

            });
            iMapper = config.CreateMapper();
            return iMapper;
        }
    }
}
