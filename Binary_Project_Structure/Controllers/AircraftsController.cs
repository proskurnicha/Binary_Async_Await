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
    [Route("api/Aircrafts")]
    public class AircraftsController : Controller
    {
        IAircraftService service;

        public AircraftsController(IAircraftService service)
        {
            this.service = service;
        }

        // GET: api/Aircrafts
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.GetAll());
        }

        // GET: api/Aircrafts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            AircraftDto Aircraft = await service.GetById(id);
            if (Aircraft == null)
            {
                return NotFound();
            }
            return Ok(Aircraft);
        }

        // POST: api/Aircrafts
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AircraftDto Aircraft)
        {
            if (Aircraft == null)
            {
                ModelState.AddModelError("", "Не указаны данные для cамолёта");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(Aircraft);

            return Created("api/Aircrafts", Aircraft);
        }

        // PUT: api/Aircrafts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]AircraftDto Aircraft)
        {
            if (Aircraft == null)
            {
                ModelState.AddModelError("", "Не указаны данные для cамолёта");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(Aircraft);

            return Ok(Aircraft);
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
