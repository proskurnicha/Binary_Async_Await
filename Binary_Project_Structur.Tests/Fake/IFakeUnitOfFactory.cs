using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structur.Tests.Fake
{
    public class IFakeUnitOfFactory : IUnitOfWork
    {
        public IRepository<Aircraft> Aircrafts => throw new NotImplementedException();

        public IRepository<Crew> Crews => throw new NotImplementedException();

        public IRepository<Departure> Departures => throw new NotImplementedException();

        public IRepository<Flight> Flights => throw new NotImplementedException();

        public IRepository<Pilot> Pilots => throw new NotImplementedException();

        public IRepository<Stewardess> Stewardesses => throw new NotImplementedException();

        public IRepository<Ticket> Tickets => throw new NotImplementedException();

        public IRepository<TypeAircraft> TypesAircrafts => throw new NotImplementedException();

        public int SaveChages()
        {
            return 0;
        }


        TEntity IUnitOfWork.Set<TEntity>()
        {
            var repAircraft = new IFakeRepository<Aircraft>();
            if (repAircraft is TEntity)
                return new IFakeRepository<Aircraft>() as TEntity;


            var repCrew = new IFakeRepository<Crew>();
            if (repCrew is TEntity)
                return new IFakeRepository<Crew>() as TEntity;

            var repDeparture = new IFakeRepository<Departure>();
            if (repDeparture is TEntity)
                return new IFakeRepository<Departure>() as TEntity;

            var repFlight = new IFakeRepository<Flight>();
            if (repFlight is TEntity)
                return new IFakeRepository<Flight>() as TEntity;

            var repPilot = new IFakeRepository<Pilot>();
            if (repPilot is TEntity)
                return new IFakeRepository<Pilot>() as TEntity;

            var repStew = new IFakeRepository<Stewardess>();
            if (repStew is TEntity)
                return new IFakeRepository<Stewardess>() as TEntity;

            var repTicket = new IFakeRepository<Ticket>();
            if (repTicket is TEntity)
                return new IFakeRepository<Ticket>() as TEntity;

            var repTypeAircraft= new IFakeRepository<TypeAircraft>();
            if (repTypeAircraft is TEntity)
                return new IFakeRepository<TypeAircraft>() as TEntity;

            return null;
        }
    }
}
