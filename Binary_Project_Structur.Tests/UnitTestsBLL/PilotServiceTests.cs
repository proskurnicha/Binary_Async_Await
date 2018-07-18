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
    public class PilotServiceTests
    {
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Create_WhenPilotNull_ThenReturnExeption()
        {
            var Pilots = new IFakeRepository<Pilot>();
            var context = new IFakeUnitOfFactory();

            PilotDto PilotDto = null;

            PilotService service = new PilotService(context);
            PilotDto PilotDtoSaved = await service.Create(PilotDto);
        }

        [Test]
        public async Task Create_WhenValidPilot_ThenReturnPilot()
        {
            var Pilots = new IFakeRepository<Pilot>();
            var context = new IFakeUnitOfFactory();

            PilotDto pilotDto = new PilotDto()
            {
                Id = 154,
                Name = "Nataly"
            };

            PilotService service = new PilotService(context);
            PilotDto PilotDtoSaved = await service.Create(pilotDto);

            Assert.AreEqual(pilotDto.Name, PilotDtoSaved.Name);
            Assert.AreEqual(pilotDto.Id, PilotDtoSaved.Id);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Update_WhenPilotNull_ThenReturnExeption()
        {
            var Pilots = new IFakeRepository<Pilot>();
            var context = new IFakeUnitOfFactory();

            PilotDto PilotDto = null;

            PilotService service = new PilotService(context);
            PilotDto PilotDtoSaved = await service.Update(PilotDto);
        }

        [Test]
        public async Task Update_WhenValidPilot_ThenReturnPilot()
        {
            var Pilots = new IFakeRepository<Pilot>();
            var context = new IFakeUnitOfFactory();

            PilotDto PilotDto = new PilotDto()
            {
                Id = 154,
                Name = "Nataly"
            };

            PilotService service = new PilotService(context);
            PilotDto PilotDtoSaved = await service.Update(PilotDto);

            Assert.AreEqual(PilotDto.Name, PilotDtoSaved.Name);
            Assert.AreEqual(PilotDto.Id, PilotDtoSaved.Id);
        }
    }
}
