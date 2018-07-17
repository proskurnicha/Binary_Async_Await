using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_DataAccess.Models;

namespace Binary_Project_Structure_DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Aircraft> Aircrafts { get; }

        IRepository<Crew> Crews { get; }

        IRepository<Departure> Departures { get; }

        IRepository<Flight> Flights { get; }

        IRepository<Pilot> Pilots { get; }

        IRepository<Stewardess> Stewardesses { get; }

        IRepository<Ticket> Tickets { get; }

        IRepository<TypeAircraft> TypesAircrafts { get; }

        TEntity Set<TEntity>() where TEntity : class;

        int SaveChages();

        //Task<int> SaveChangesAsync();
    }
}
