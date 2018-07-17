using Binary_Project_Structure_DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Aircraft> Aircraft { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<Departure> Departure { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Pilot> Pilot { get; set; }
        public DbSet<Stewardess> Stewardess { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<TypeAircraft> TypeAircraft { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=AirportModelDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            AirportDBInitializer initializer = new AirportDBInitializer(modelBuilder);
            initializer.Initialize();
        }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            if (Ticket is DbSet<TEntity>)
                return Ticket as DbSet<TEntity>;

            if (Stewardess is DbSet<TEntity>)
                return  (Stewardess as DbSet<TEntity>);

            if (Pilot is DbSet<TEntity>)
                return  (Pilot as DbSet<TEntity>);

            if (Departure is DbSet<TEntity>)
                return  (Departure as DbSet<TEntity>);

            if (Crew is DbSet<TEntity>)
                return  (Crew as DbSet<TEntity>);

            if (TypeAircraft is DbSet<TEntity>)
                return  (TypeAircraft as DbSet<TEntity>);
            
            if (Aircraft is DbSet<TEntity>)
                return  (Aircraft as DbSet<TEntity>);

            if (Flight is DbSet<TEntity>)
                return  (Flight as DbSet<TEntity>);

            return null;
        }
    }
}
