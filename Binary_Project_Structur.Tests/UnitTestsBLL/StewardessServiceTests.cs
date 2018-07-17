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
    public class StewardessServiceTests
    {
        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Create_WhenStewardessNull_ThenReturnExeption()
        {
            var Stewardesss = new IFakeRepository<Stewardess>();
            var context = new IFakeUnitOfFactory();

            StewardessDto StewardessDto = null;

            StewardessService service = new StewardessService(context);
            StewardessDto StewardessDtoSaved = service.Create(StewardessDto);
        }

        [Test]
        public void Create_WhenValidStewardess_ThenReturnStewardess()
        {
            var Stewardesss = new IFakeRepository<Stewardess>();
            var context = new IFakeUnitOfFactory();

            StewardessDto StewardessDto = new StewardessDto()
            {
                Id = 154,
                Name = "Nataly"
            };

            StewardessService service = new StewardessService(context);
            StewardessDto StewardessDtoSaved = service.Create(StewardessDto);

            Assert.AreEqual(StewardessDto.Name, StewardessDtoSaved.Name);
            Assert.AreEqual(StewardessDto.Id, StewardessDtoSaved.Id);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void Update_WhenStewardessNull_ThenReturnExeption()
        {
            var Stewardesss = new IFakeRepository<Stewardess>();
            var context = new IFakeUnitOfFactory();

            StewardessDto StewardessDto = null;

            StewardessService service = new StewardessService(context);
            StewardessDto StewardessDtoSaved = service.Update(StewardessDto);
        }

        [Test]
        public void Update_WhenValidStewardess_ThenReturnStewardess()
        {
            var Stewardesss = new IFakeRepository<Stewardess>();
            var context = new IFakeUnitOfFactory();

            StewardessDto StewardessDto = new StewardessDto()
            {
                Id = 154,
                Name = "Nataly"
            };

            StewardessService service = new StewardessService(context);
            StewardessDto StewardessDtoSaved = service.Update(StewardessDto);

            Assert.AreEqual(StewardessDto.Name, StewardessDtoSaved.Name);
            Assert.AreEqual(StewardessDto.Id, StewardessDtoSaved.Id);
        }
    }
}

