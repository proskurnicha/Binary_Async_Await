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
    [Route("api/Stewardesses")]
    public class StewardessesController : Controller
    {
        IStewardessService service;

        public StewardessesController(IStewardessService service)
        {
            this.service = service;
        }

        // GET: api/Stewardesses
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.GetAll());
        }

        // GET: api/Stewardesses/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            StewardessDto Stewardess = service.GetById(id);
            if (Stewardess == null)
            {
                return NotFound();
            }
            return Ok(Stewardess);
        }

        // POST: api/Stewardesses
        [HttpPost]
        public IActionResult Post([FromBody]StewardessDto Stewardess)
        {
            if (Stewardess == null)
            {
                ModelState.AddModelError("", "Не указаны данные для стюардеси");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Create(Stewardess);

            return Created("api/Stewardesses", Stewardess);
        }

        // PUT: api/Stewardesses/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]StewardessDto Stewardess)
        {
            if (Stewardess == null)
            {
                ModelState.AddModelError("", "Не указаны данные для стюардеси");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Update(Stewardess);

            return Ok(Stewardess);
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