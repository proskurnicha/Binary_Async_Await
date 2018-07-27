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
    [Route("api/TypesAircraft")]
    [EnableCors("MyPolicy")]
    public class TypesAircraftController : Controller
    {
        ITypeAircraftService service;

        public TypesAircraftController(ITypeAircraftService service)
        {
            this.service = service;
        }

        // GET: api/TypesAircraft
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await service.GetAll());
        }

        // GET: api/TypesAircraft/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            TypeAircraftDto TypeAircraft = await service.GetById(id);
            if (TypeAircraft == null)
            {
                return NotFound();
            }
            return Ok(TypeAircraft);
        }

        // POST: api/TypesAircraft
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TypeAircraftDto TypeAircraft)
        {
            if (TypeAircraft == null)
            {
                ModelState.AddModelError("", "Не указаны данные для типа cамолёта");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(TypeAircraft);

            return Created("api/TypesAircrafts", TypeAircraft);
        }

        // PUT: api/TypesAircraft/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]TypeAircraftDto TypeAircraft)
        {
            if (TypeAircraft == null)
            {
                ModelState.AddModelError("", "Не указаны данные для типа cамолёта");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(TypeAircraft);

            return Ok(TypeAircraft);
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