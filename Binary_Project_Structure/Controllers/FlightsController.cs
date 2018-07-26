using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_BLL.Services;
using Binary_Project_Structure_Shared.DTOs;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_BLL.Helpers;
using Microsoft.AspNetCore.Cors;

namespace Binary_Project_Structure.Controllers
{
    [Produces("application/json")]
    [Route("api/Flights")]
    public class FlightsController : Controller
    {
        IFlightService service;
        Helper helper = new Helper();
        public FlightsController(IFlightService service)
        {
            this.service = service;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string result = await helper.DoWork();
            Console.WriteLine(result);
            return Ok(await service.GetAll());
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            FlightDto flight = await service.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        // POST: api/Flights
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FlightDto flight)
        {
            if (flight == null)
            {
                ModelState.AddModelError("", "Не указаны данные для полёта");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(flight);

            return Created("api/Flights", flight);
        }

        // PUT: api/Flights/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]FlightDto flight)
        {
            if (flight == null)
            {
                ModelState.AddModelError("", "Не указаны данные для полёта");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(flight);

            return Ok(flight);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await service.Delete(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
