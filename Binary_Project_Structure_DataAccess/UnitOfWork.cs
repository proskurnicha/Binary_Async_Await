using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_DataAccess.Repositories;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;

namespace Binary_Project_Structure_DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        DatabaseContext databaseContext;

        public UnitOfWork()
        {
            databaseContext = new DatabaseContext();
        }
        private AircraftRepository aircraftRepository;

        private CrewRepository crewRepository;

        private DepartureRepositoty departureRepository;

        private FlightRepository flightRepository;

        private PilotRepository pilotRepository;

        private StewardessRepository stewardessRepository;

        private TicketRepository ticketRepository;

        private TypeAircraftRepository typeAircraftRepository;

        public IRepository<Aircraft> Aircrafts
        {
            get
            {
                if (aircraftRepository == null)
                    aircraftRepository = new AircraftRepository();
                return aircraftRepository;
            }
        }

        public IRepository<Crew> Crews
        {
            get
            {
                if (crewRepository == null)
                    crewRepository = new CrewRepository();
                return crewRepository;
            }
        }

        public IRepository<Departure> Departures
        {
            get
            {
                if (departureRepository == null)
                    departureRepository = new DepartureRepositoty();
                return departureRepository;
            }
        }

        public IRepository<Flight> Flights
        {
            get
            {
                if (flightRepository == null)
                    flightRepository = new FlightRepository();
                return flightRepository;
            }
        }

        public IRepository<Pilot> Pilots
        {
            get
            {
                if (pilotRepository == null)
                    pilotRepository = new PilotRepository();
                return pilotRepository;
            }
        }

        public IRepository<Stewardess> Stewardesses
        {
            get
            {
                if (stewardessRepository == null)
                    stewardessRepository = new StewardessRepository();
                return stewardessRepository;
            }
        }

        public IRepository<Ticket> Tickets
        {
            get
            {
                if (ticketRepository == null)
                    ticketRepository = new TicketRepository();
                return ticketRepository;
            }
        }

        public IRepository<TypeAircraft> TypesAircrafts
        {
            get
            {
                if (typeAircraftRepository == null)
                    typeAircraftRepository = new TypeAircraftRepository();
                return typeAircraftRepository;
            }
        }

        public int SaveChages()
        {
            return databaseContext.SaveChanges();
        }

        public TEntity Set<TEntity>() where TEntity : class
        {
            if (Tickets is TEntity)
                return Tickets as TEntity;

            if (Stewardesses is TEntity)
                return Stewardesses as TEntity;

            if (Pilots is TEntity)
                return Pilots as TEntity;

            if (Departures is TEntity)
                return Departures as TEntity;

            if (Crews is TEntity)
                return Crews as TEntity;

            if (TypesAircrafts is TEntity)
                return TypesAircrafts as TEntity;

            if (Aircrafts is TEntity)
                return Aircrafts as TEntity;

            if (Flights is TEntity)
                return Flights as TEntity;

            return null;
        }
    }
}
