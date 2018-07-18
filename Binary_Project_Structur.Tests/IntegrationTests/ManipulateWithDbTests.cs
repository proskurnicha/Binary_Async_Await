using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_BLL.Services;
using Binary_Project_Structure_DataAccess;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structur.Tests.IntegrationTests
{
    [TestFixture]
    public class ManipulateWithDbTests
    {
        FlightService serviceFlight;
        AircraftService service;
        UnitOfWork uow;
        public ManipulateWithDbTests()
        {
            uow = new UnitOfWork();
            service = new AircraftService(uow);
            serviceFlight = new FlightService(uow);
        }
        [Test]
        public async Task CreateAircraft_WhenAircraftValid_ReturnNewAircraft()
        {
            AircraftDto aircraft = new AircraftDto()
            {
                AircraftName = "TEST",
                TypeAircraftId = 1
            };
            AircraftDto aircraftDtoSaved = await service.Create(aircraft);

            Assert.AreEqual(aircraft.AircraftName, aircraftDtoSaved.AircraftName);
            Assert.AreEqual(aircraft.TypeAircraftId, aircraftDtoSaved.TypeAircraftId);

            bool result = await service.Delete<Aircraft>(aircr => aircr.Id == aircraftDtoSaved.Id);

            Assert.IsTrue(result);
        }

        [Test]
        [ExpectedException(typeof(DbUpdateException))]
        public async Task CreateAircraft_WhenIdSend_ThenReturnExeption()
        {
            AircraftDto aircraft = new AircraftDto()
            {
                Id = 5,
                AircraftName = "TEST",
                TypeAircraftId = 1
            };
            AircraftDto aircraftDtoSaved = await service.Create(aircraft);
        }

        [Test]
        [ExpectedException(typeof(DbUpdateException))]
        public async Task CreateAircraft_WhenTypeAircraftIdInvalid_ThenReturnExeption()
        {
            AircraftDto aircraft = new AircraftDto()
            {
                AircraftName = "TEST",
                TypeAircraftId = 1000
            };
            AircraftDto aircraftDtoSaved = await service.Create(aircraft);
        }

        [Test]
        public async Task CreateFlight_WhenFlightValid_ReturnNewFlight()
        {
            FlightDto flight = new FlightDto()
            {
                ArrivalPoint = "Test",
                DeparturePoint = "Test",
                ArrivalTime = new TimeSpan(),
                DepartureTime = new TimeSpan(),
                Tickets = new List<TicketDto>()
            };
            FlightDto flightDtoSaved = await serviceFlight.Create(flight);

            Assert.AreEqual(flight.ArrivalPoint, flight.ArrivalPoint);
            Assert.AreEqual(flight.DeparturePoint, flight.DeparturePoint);

            bool result = await serviceFlight.Delete<Aircraft>(aircr => aircr.Id == flightDtoSaved.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task DeleteAircraft_WhenIdInvalid_ThenReturnExeption()
        {
            bool result = await service.Delete<Aircraft>(aircr => aircr.Id == 999);
            Assert.IsFalse(result);
        }

        [Test]
        public async Task GetByIdAircraft_WhenAircraftWithId1Valid_ReturnAircraftWithId1()
        {
            int id = 1;
            AircraftDto aircraftDto = await service.GetById<Aircraft, AircraftDto>(x => x.Id == id);
            Assert.AreEqual(id, aircraftDto.Id);
        }

        [Test]
        public async Task GetByIdAircraft_WhenAircraftIdInvalid_ReturnNull()
        {
            AircraftDto aircraftDto = await service.GetById<Aircraft, AircraftDto>(x => x.Id == 999);
            Assert.IsNull(aircraftDto);
        }

        [Test]
        public async Task UpdateAircraft_WhenAircraftWithId_ReturnUpdatedAircraftWithId()
        {
            AircraftDto aircraft = new AircraftDto()
            {
                AircraftName = "TEST",
                TypeAircraftId = 1
            };
            AircraftDto aircraftDtoSaved = await service.Create(aircraft);

            aircraftDtoSaved.AircraftName = "TEST2";
            aircraftDtoSaved.TypeAircraftId = 2;

            AircraftDto aircraftDtoUpdated = await service.Update<AircraftDto, Aircraft>(aircraftDtoSaved);

            Assert.AreEqual(aircraftDtoSaved.AircraftName, aircraftDtoUpdated.AircraftName);
            Assert.AreEqual(aircraftDtoSaved.TypeAircraftId, aircraftDtoUpdated.TypeAircraftId);

            bool result = await service.Delete<Aircraft>(aircr => aircr.Id == aircraftDtoUpdated.Id);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task UpdateAircraft_WhenAircraftIdInvalid_ReturnNull()
        {
            AircraftDto aircraft = new AircraftDto()
            {
                Id = 999,
                AircraftName = "TEST",
                TypeAircraftId = 1
            };

            AircraftDto aircraftDtoUpdated = await service.Update<AircraftDto, Aircraft>(aircraft);
            Assert.IsNull(aircraftDtoUpdated);
        }

        [Test]
        public async Task UpdateAircraft_WhenAircraftIdInvalid_ReturnExeption()
        {
            FlightDto flight = new FlightDto()
            {
                Id = 999,
                DeparturePoint = "TEST",
                ArrivalPoint = "Test"
            };

            FlightDto flightDtoUpdated = await service.Update<FlightDto, Flight>(flight);
            Assert.IsNull(flightDtoUpdated);
        }
    }
}
