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

namespace Binary_Project_Structure.Controllers
{
    [Produces("application/json")]
    [Route("api/Flights")]
    public class FlightsController : Controller
    {
        IFlightService service;

        public FlightsController(IFlightService service)
        {
            this.service = service;
        }

        // GET: api/Flights
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetAll());
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            FlightDto flight = service.GetById(id);
            if (flight == null)
            {
                return NotFound();
            }
            return Ok(flight);
        }

        // POST: api/Flights
        [HttpPost]
        public IActionResult Post([FromBody]FlightDto flight)
        {
            if (flight == null)
            {
                ModelState.AddModelError("", "Не указаны данные для полёта");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Create(flight);

            return Created("api/Flights", flight);
        }

        // PUT: api/Flights/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]FlightDto flight)
        {
            if (flight == null)
            {
                ModelState.AddModelError("", "Не указаны данные для полёта");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Update(flight);

            return Ok(flight);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool result = service.Delete(id);

            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
