using Binary_Project_Structure_DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Binary_Project_Structure_DataAccess
{
    public class AirportDBInitializer
    {
        ModelBuilder modelBuilder;
        public AirportDBInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Initialize()
        {
            #region Stewardesses
            modelBuilder.Entity<Stewardess>().HasData(
                  new Stewardess()
                  {
                      Id = 1,
                      Name = "Natali",
                      Surname = "Sidorova",
                      DateBirth = new DateTime(1990, 12, 4)
                  },
                 new Stewardess()
                 {
                     Id = 2,
                     Name = "Kate",
                     Surname = "Petrova",
                     DateBirth = new DateTime(1995, 5, 15)
                 },
                 new Stewardess()
                 {
                     Id = 3,
                     Name = "Tanya",
                     Surname = "Durova",
                     DateBirth = new DateTime(1993, 7, 26)
                 }
                );
            #endregion

            #region TypesAircraft
            modelBuilder.Entity<TypeAircraft>().HasData(
                new TypeAircraft()
                {
                    Id = 1,
                    AircraftModel = AircraftModel.IL_96_300,
                    NumberPlaces = 797,
                    CarryingCapacity = 240000

                },
                new TypeAircraft()
                {
                    Id = 2,
                    AircraftModel = AircraftModel.Airbus_A310,
                    NumberPlaces = 183,
                    CarryingCapacity = 164000
                }
                );
            #endregion

            #region Pilots
            modelBuilder.Entity<Pilot>().HasData(
                new Pilot()
                {
                    Id = 1,
                    Name = "Ivan",
                    Surname = "Ivanov",
                    DateBirth = new DateTime(1990, 12, 4),
                    Experience = 5
                },
                 new Pilot()
                 {
                     Id = 2,
                     Name = "Petr",
                     Surname = "Petrov",
                     DateBirth = new DateTime(1995, 5, 15),
                     Experience = 10
                 },
                 new Pilot()
                 {
                     Id = 3,
                     Name = "Sidr",
                     Surname = "Sidorov",
                     DateBirth = new DateTime(1993, 7, 26),
                     Experience = 7
                 });
            #endregion

            #region Flights
            modelBuilder.Entity<Flight>().HasData(
               new Flight()
               {
                   Id = 1,
                   DeparturePoint = "Kiev",
                   ArrivalPoint = "Berlin",
                   DepartureTime = new TimeSpan(4, 46, 0),
                   ArrivalTime = new TimeSpan(10, 29, 0),
               },
            new Flight()
            {
                Id = 2,
                DeparturePoint = "Kiev",
                ArrivalPoint = "Riga",
                DepartureTime = new TimeSpan(11, 30, 0),
                ArrivalTime = new TimeSpan(8, 05, 0),
            },
            new Flight()
            {
                Id = 3,
                DeparturePoint = "Kiev",
                ArrivalPoint = "Brussels",
                DepartureTime = new TimeSpan(05, 48, 0),
                ArrivalTime = new TimeSpan(3, 15, 0),
            }
              );
            #endregion

            #region Aircrafts
            modelBuilder.Entity<Aircraft>().HasData(
                new Aircraft()
                {
                    Id = 1,
                    TypeAircraftId = 1,
                    AircraftName = "Star",
                },
               new Aircraft()
               {
                   Id = 2,
                   TypeAircraftId = 2,
                   AircraftName = "Cometa",
               });
            #endregion

            #region Tickets
            modelBuilder.Entity<Ticket>().HasData(
                   new Ticket()
                   {
                       Id = 1,
                       Price = 200,
                       FlightId = 1,
                   },
                new Ticket()
                {
                    Id = 2,
                    Price = 300,
                    FlightId = 2,
                },
                new Ticket()
                {
                    Id = 3,
                    Price = 400,
                    FlightId = 3,
                }
                );
            #endregion

            #region Departures
            modelBuilder.Entity<Departure>().HasData(
               new Departure()
               {
                   Id = 1,
                   AircraftId = 1,
                   CrewId = 1,
                   FlightId = 1,
                   DepartureTime = new DateTime(2018, 07, 13)
               },
                new Departure()
                {
                    Id = 2,
                    AircraftId = 2,
                    CrewId = 2,
                    FlightId = 2,
                    DepartureTime = new DateTime(2018, 07, 15)
                },
                new Departure()
                {
                    Id = 3,
                    AircraftId = 1,
                    CrewId = 3,
                    FlightId = 3,
                    DepartureTime = new DateTime(2018, 07, 14)
                }
              );
            #endregion


            #region Crews
            modelBuilder.Entity<Crew>().HasData(
               new Crew()
               {
                   Id = 1,
                   PilotId = 1,
               },
               new Crew()
               {
                   Id = 2,
                   PilotId = 1
               },
               new Crew()
               {
                   Id = 3,
                   PilotId = 1
               }
              );
            #endregion
        }
    }
}
