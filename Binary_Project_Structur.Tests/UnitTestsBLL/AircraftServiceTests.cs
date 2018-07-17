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
    public class AircraftServiceTests
    {
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Create_WhenAircraftNull_ThenReturnExeption()
        {
            var aircrafts = new IFakeRepository<Aircraft>();
            var context = new IFakeUnitOfFactory();

            AircraftDto aircraftDto = null;

            AircraftService service = new AircraftService(context);
            AircraftDto aircraftDtoSaved = service.Create(aircraftDto);
        }

        [Test]
        public void Create_WhenValidAircraft_ThenReturnAircraft()
        {
            var aircrafts = new IFakeRepository<Aircraft>();
            var context = new IFakeUnitOfFactory();

            AircraftDto aircraftDto = new AircraftDto()
            {
                Id = 154,
                AircraftName = "Test",
                TypeAircraftId = 165
            };

            AircraftService service = new AircraftService(context);
            AircraftDto aircraftDtoSaved = service.Create(aircraftDto);

            Assert.AreEqual(aircraftDto.AircraftName, aircraftDtoSaved.AircraftName);
            Assert.AreEqual(aircraftDto.Id, aircraftDtoSaved.Id);
            Assert.AreEqual(aircraftDto.TypeAircraftId, aircraftDtoSaved.TypeAircraftId);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Update_WhenAircraftNull_ThenReturnExeption()
        {
            var aircrafts = new IFakeRepository<Aircraft>();
            var context = new IFakeUnitOfFactory();

            AircraftDto aircraftDto = null;

            AircraftService service = new AircraftService(context);
            AircraftDto aircraftDtoSaved = service.Update(aircraftDto);
        }

        [Test]
        public void Update_WhenValidAircraft_ThenReturnAircraft()
        {
            var aircrafts = new IFakeRepository<Aircraft>();
            var context = new IFakeUnitOfFactory();

            AircraftDto aircraftDto = new AircraftDto()
            {
                Id = 154,
                AircraftName = "Test",
                TypeAircraftId = 165
            };

            AircraftService service = new AircraftService(context);
            AircraftDto aircraftDtoSaved = service.Update(aircraftDto);

            Assert.AreEqual(aircraftDto.AircraftName, aircraftDtoSaved.AircraftName);
            Assert.AreEqual(aircraftDto.Id, aircraftDtoSaved.Id);
            Assert.AreEqual(aircraftDto.TypeAircraftId, aircraftDtoSaved.TypeAircraftId);
        }
    }
}
