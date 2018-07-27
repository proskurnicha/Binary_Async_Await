using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_Shared.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binary_Project_Structure.Controllers
{
    [Produces("application/json")]
    [Route("api/Pilots")]
    [EnableCors("MyPolicy")]
    public class PilotsController : Controller
    {
        IPilotService service;

        public PilotsController(IPilotService service)
        {
            this.service = service;
        }

        // GET: api/Pilots
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.GetAll());
        }

        // GET: api/Pilots/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            PilotDto Pilot = await service.GetById(id);
            if (Pilot == null)
            {
                return NotFound();
            }
            return Ok(Pilot);
        }

        // POST: api/Pilots
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PilotDto Pilot)
        {
            if (Pilot == null)
            {
                ModelState.AddModelError("", "Не указаны данные для пилота");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(Pilot);

            return Created("api/Pilots", Pilot);
        }

        // PUT: api/Pilots/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]PilotDto Pilot)
        {
            if (Pilot == null)
            {
                ModelState.AddModelError("", "Не указаны данные для пилота");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(Pilot);

            return Ok(Pilot);
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