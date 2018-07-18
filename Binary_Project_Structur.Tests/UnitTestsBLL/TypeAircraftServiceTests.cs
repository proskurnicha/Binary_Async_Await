using Binary_Project_Structur.Tests.Fake;
using Binary_Project_Structure_BLL.Services;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structur.Tests.UnitTestsBLL
{
    [TestFixture]
    public class TypeAircraftServiceTests
    {
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Create_WhenTypeAircraftNull_ThenReturnExeption()
        {
            var TypeAircrafts = new IFakeRepository<TypeAircraft>();
            var context = new IFakeUnitOfFactory();

            TypeAircraftDto TypeAircraftDto = null;

            TypeAircraftService service = new TypeAircraftService(context);
            TypeAircraftDto TypeAircraftDtoSaved = await service.Create(TypeAircraftDto);
        }

        [Test]
        public async Task Create_WhenValidTypeAircraft_ThenReturnTypeAircraft()
        {
            var TypeAircrafts = new IFakeRepository<TypeAircraft>();
            var context = new IFakeUnitOfFactory();

            TypeAircraftDto TypeAircraftDto = new TypeAircraftDto()
            {
                Id = 154,
                NumberPlaces = 100
            };

            TypeAircraftService service = new TypeAircraftService(context);
            TypeAircraftDto TypeAircraftDtoSaved = await service.Create(TypeAircraftDto);

            Assert.AreEqual(TypeAircraftDto.NumberPlaces, TypeAircraftDtoSaved.NumberPlaces);
            Assert.AreEqual(TypeAircraftDto.Id, TypeAircraftDtoSaved.Id);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Update_WhenTypeAircraftNull_ThenReturnExeption()
        {
            var TypeAircrafts = new IFakeRepository<TypeAircraft>();
            var context = new IFakeUnitOfFactory();

            TypeAircraftDto TypeAircraftDto = null;

            TypeAircraftService service = new TypeAircraftService(context);
            TypeAircraftDto TypeAircraftDtoSaved = await service.Update(TypeAircraftDto);
        }

        [Test]
        public async Task Update_WhenValidTypeAircraft_ThenReturnTypeAircraft()
        {
            var TypeAircrafts = new IFakeRepository<TypeAircraft>();
            var context = new IFakeUnitOfFactory();

            TypeAircraftDto TypeAircraftDto = new TypeAircraftDto()
            {
                Id = 154,
                NumberPlaces = 100
            };

            TypeAircraftService service = new TypeAircraftService(context);
            TypeAircraftDto TypeAircraftDtoSaved = await service.Update(TypeAircraftDto);

            Assert.AreEqual(TypeAircraftDto.NumberPlaces, TypeAircraftDtoSaved.NumberPlaces);
            Assert.AreEqual(TypeAircraftDto.Id, TypeAircraftDtoSaved.Id);
        }
    }
}


