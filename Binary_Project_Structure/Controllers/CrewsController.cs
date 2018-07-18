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
    [Route("api/Crews")]
    public class CrewsController : Controller
    {
        ICrewService service;

        public CrewsController(ICrewService service)
        {
            this.service = service;
        }

        // GET: api/Crews
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.GetAll());
        }

        // GET: api/Crews/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            CrewDto Crew =  await service.GetById(id);
            if (Crew == null)
            {
                return NotFound();
            }
            return Ok(Crew);
        }

        // POST: api/Crews
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CrewDto Crew)
        {
            if (Crew == null)
            {
                ModelState.AddModelError("", "Не указаны данные для экипажа");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(Crew);

            return Created("api/Crews", Crew);
        }

        // PUT: api/Crews/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]CrewDto Crew)
        {
            if (Crew == null)
            {
                ModelState.AddModelError("", "Не указаны данные для экипажа");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(Crew);

            return Ok(Crew);
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
