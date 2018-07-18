﻿using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure.Controllers;
using Binary_Project_Structure_BLL.Interfaces;
using FakeItEasy;
using NUnit;
using NUnit.Framework;
using Binary_Project_Structure_Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Binary_Project_Structur.Tests.ControllerTests
{
    [TestFixture]
    class AircraftControllerTests
    {
        AircraftsController aircraftsController;
        IAircraftService service;
        public AircraftControllerTests()
        {
            service = A.Fake<IAircraftService>();
            aircraftsController = new AircraftsController(service);
            A.CallTo(() => service.GetAll()).Returns(new List<AircraftDto>());
        }
        [Test]
        public async Task Get_WhenGetAll_ReturnOk()
        {
            IActionResult result = await aircraftsController.Get();
            Assert.True(result is OkObjectResult);
        }

        [Test]
        public async Task Get_WhenGetByValidId_ReturnOk()
        {
            int id = 1;
            A.CallTo(() => service.GetById(1)).Returns(new AircraftDto());
            IActionResult result = await aircraftsController.Get();
            Assert.True(result is OkObjectResult);
        }

        //[Test]
        //public async Task Get_WhenGetByInValid_ReturnNoTFound()
        //{
        //    int id = 2;
        //    A.CallTo(() => await service.GetById(2)).Returns(null);
        //    IActionResult result = await aircraftsController.Get(2);
        //    Assert.True(result is NotFoundResult);
        //}

        [Test]
        public async Task Post_WhenNull_ReturnBadRequest()
        {
            IActionResult result = await aircraftsController.Post(null);
            Assert.True(result is BadRequestObjectResult);
        }

        [Test]
        public async Task Post_WhenInvalidAircraft_ReturnCreatedResult()
        {
            AircraftDto aircraft = new AircraftDto()
            {
                AircraftName = "Test",
                TypeAircraftId = 10
            };
            A.CallTo(() => service.Create(aircraft)).Returns(aircraft);
            IActionResult result = await aircraftsController.Post(aircraft);
            Assert.True(result is CreatedResult);
        }

        [Test]
        public async Task Put_WhenNull_ReturnBadRequest()
        {
            IActionResult result = await aircraftsController.Put(0, null);
            Assert.True(result is BadRequestObjectResult);
        }

        [Test]
        public async Task Delete_WhenNull_ReturNoFound()
        {
            AircraftDto aircraft = new AircraftDto();
            A.CallTo(() => service.Delete(aircraft.Id)).Returns(false);
            IActionResult result = await aircraftsController.Delete(aircraft.Id);
            Assert.True(result is NotFoundResult);
        }

        [Test]
        public async Task Delete_WhenNull_ReturnNoContent()
        {
            AircraftDto aircraft = new AircraftDto();
            A.CallTo(() => service.Delete(aircraft.Id)).Returns(true);
            IActionResult result = await aircraftsController.Delete(aircraft.Id);
            Assert.True(result is NoContentResult);
        }
    }
}
