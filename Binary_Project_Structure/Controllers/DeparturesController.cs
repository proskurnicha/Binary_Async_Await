using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binary_Project_Structure.Controllers
{
    [Produces("application/json")]
    [Route("api/Departures")]
    public class DeparturesController : Controller
    {
        IDepartureService service;

        public DeparturesController(IDepartureService service)
        {
            this.service = service;
        }

        // GET: api/Departures
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetAll());
        }

        // GET: api/Departures/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DepartureDto Departure = service.GetById(id);
            if (Departure == null)
            {
                return NotFound();
            }
            return Ok(Departure);
        }

        // POST: api/Departures
        [HttpPost]
        public IActionResult Post([FromBody]DepartureDto Departure)
        {
            if (Departure == null)
            {
                ModelState.AddModelError("", "Не указаны данные для вылета");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Create(Departure);

            return Created("api/Departures", Departure);
        }

        // PUT: api/Departures/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]DepartureDto Departure)
        {
            if (Departure == null)
            {
                ModelState.AddModelError("", "Не указаны данные для вылета");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Update(Departure);

            return Ok(Departure);
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
