using Binary_Project_Structur.Tests.Fake;
using Binary_Project_Structure_BLL.Services;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Binary_Project_Structur.Tests.UnitTestsBLL
{
    [TestFixture]
    public class FlightServiceTests
    {
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Create_WhenFlightNull_ThenReturnExeption()
        {
            var Flights = new IFakeRepository<Flight>();
            var context = new IFakeUnitOfFactory();

            FlightDto FlightDto = null;

            FlightService service = new FlightService(context);
            FlightDto FlightDtoSaved = service.Create(FlightDto);
        }

        [Test]
        public void Create_WhenValidFlight_ThenReturnFlight()
        {
            var Flights = new IFakeRepository<Flight>();
            var context = new IFakeUnitOfFactory();

            FlightDto flightDto = new FlightDto()
            {
                Id = 154,
                ArrivalPoint = "Kiev"
            };

            FlightService service = new FlightService(context);
            FlightDto FlightDtoSaved = service.Create(flightDto);

            Assert.AreEqual(flightDto.ArrivalPoint, FlightDtoSaved.ArrivalPoint);
            Assert.AreEqual(flightDto.Id, FlightDtoSaved.Id);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Update_WhenFlightNull_ThenReturnExeption()
        {
            var Flights = new IFakeRepository<Flight>();
            var context = new IFakeUnitOfFactory();

            FlightDto FlightDto = null;

            FlightService service = new FlightService(context);
            FlightDto FlightDtoSaved = service.Update(FlightDto);
        }

        [Test]
        public void Update_WhenValidFlight_ThenReturnFlight()
        {
            var Flights = new IFakeRepository<Flight>();
            var context = new IFakeUnitOfFactory();

            FlightDto flightDto = new FlightDto()
            {
                Id = 154,
                ArrivalPoint = "TEST",
            };

            FlightService service = new FlightService(context);
            FlightDto FlightDtoSaved = service.Update(flightDto);

            Assert.AreEqual(flightDto.ArrivalPoint, FlightDtoSaved.ArrivalPoint);
            Assert.AreEqual(flightDto.Id, FlightDtoSaved.Id);
        }
    }
}
