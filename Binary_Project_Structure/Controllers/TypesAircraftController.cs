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
    [Route("api/TypesAircraft")]
    public class TypesAircraftController : Controller
    {
        ITypeAircraftService service;

        public TypesAircraftController(ITypeAircraftService service)
        {
            this.service = service;
        }

        // GET: api/TypesAircraft
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetAll());
        }

        // GET: api/TypesAircraft/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            TypeAircraftDto TypeAircraft = service.GetById(id);
            if (TypeAircraft == null)
            {
                return NotFound();
            }
            return Ok(TypeAircraft);
        }

        // POST: api/TypesAircraft
        [HttpPost]
        public IActionResult Post([FromBody]TypeAircraftDto TypeAircraft)
        {
            if (TypeAircraft == null)
            {
                ModelState.AddModelError("", "Не указаны данные для типа cамолёта");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Create(TypeAircraft);

            return Created("api/TypesAircrafts", TypeAircraft);
        }

        // PUT: api/TypesAircraft/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TypeAircraftDto TypeAircraft)
        {
            if (TypeAircraft == null)
            {
                ModelState.AddModelError("", "Не указаны данные для типа cамолёта");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Update(TypeAircraft);

            return Ok(TypeAircraft);
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