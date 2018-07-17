using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Binary_Project_Structure_Shared.DTOs;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Opera;
using Microsoft.AspNetCore;
namespace Binary_Project_Structur.Tests.TestsQA
{
    class AircraftTestsCases
    {
        IWebDriver driver;

        [SetUp]
        public void Initialize()
        {
            OperaDriverService service = OperaDriverService.CreateDefaultService(@"E:/C#/Binary/Binary_Testing/"); //path to OperaDriver
            OperaOptions options = new OperaOptions();
            options.BinaryLocation = @"C:/Program Files/Opera/launcher.exe"; //path to my Opera browser
            driver = new OperaDriver(service, options);
        }

        [Test]
        public void GetById_WhenId1_ThenFlightWithId1()
        {
            driver.Url = @"http://localhost:54956/api/Flights/1";
            string actual = driver.FindElement(By.TagName("pre")).Text;
            FlightDto flightDtoActual = JsonConvert.DeserializeObject<FlightDto>(actual);
            FlightDto flightDtoExpected = new FlightDto()
            {
                Id = 1,
                DeparturePoint = "Kiev",
            };

            Assert.AreEqual(flightDtoExpected.Id, flightDtoActual.Id);
            Assert.AreEqual(flightDtoExpected.DeparturePoint, flightDtoActual.DeparturePoint);
        }

        [TearDown]
        public void EndTest()
        {
            driver.Close();
        }
    }
}
