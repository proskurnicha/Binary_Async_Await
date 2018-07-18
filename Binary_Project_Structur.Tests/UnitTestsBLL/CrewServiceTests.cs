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
    public class CrewServiceTests
    {
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Create_WhenCrewNull_ThenReturnExeption()
        {
            var Crews = new IFakeRepository<Crew>();
            var context = new IFakeUnitOfFactory();

            CrewDto CrewDto = null;

            CrewService service = new CrewService(context);
            CrewDto CrewDtoSaved = await service.Create(CrewDto);
        }

        [Test]
        public async Task Create_WhenValidCrew_ThenReturnCrew()
        {
            var Crews = new IFakeRepository<Crew>();
            var context = new IFakeUnitOfFactory();

            CrewDto CrewDto = new CrewDto()
            {
                Id = 154,
                PilotId = 5
            };

            CrewService service = new CrewService(context);
            CrewDto CrewDtoSaved = await service.Create(CrewDto);

            Assert.AreEqual(CrewDto.PilotId, CrewDtoSaved.PilotId);
            Assert.AreEqual(CrewDto.Id, CrewDtoSaved.Id);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public async Task Update_WhenCrewNull_ThenReturnExeption()
        {
            var Crews = new IFakeRepository<Crew>();
            var context = new IFakeUnitOfFactory();

            CrewDto CrewDto = null;

            CrewService service = new CrewService(context);
            CrewDto CrewDtoSaved = await service.Update(CrewDto);
        }

        [Test]
        public async Task Update_WhenValidCrew_ThenReturnCrew()
        {
            var Crews = new IFakeRepository<Crew>();
            var context = new IFakeUnitOfFactory();

            CrewDto CrewDto = new CrewDto()
            {
                Id = 154,
                PilotId = 5,
            };

            CrewService service = new CrewService(context);
            CrewDto CrewDtoSaved = await service.Update(CrewDto);

            Assert.AreEqual(CrewDto.PilotId, CrewDtoSaved.PilotId);
            Assert.AreEqual(CrewDto.Id, CrewDtoSaved.Id);
        }
    }
}
