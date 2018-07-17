using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binary_Project_Structure.Controllers
{
    [Produces("application/json")]
    [Route("api/Tickets")]
    public class TicketsController : Controller
    {
        ITicketService service;

        public TicketsController(ITicketService service)
        {
            this.service = service;
        }

        // GET: api/Tickets
        [HttpGet(Name = "GetTickets")]
        public IActionResult GetTickets()
        {
            return Ok(service.GetAll());
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public IActionResult GetTicket(int id)
        {
            TicketDto ticket = service.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        // POST: api/Tickets
        [HttpPost]
        public IActionResult Post([FromBody]TicketDto ticket)
        {
            if (ticket == null)
            {
                ModelState.AddModelError("", "Не указаны данные для билета");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Create(ticket);

            return Created("api/Tickets", ticket);
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]TicketDto ticket)
        {
            if (ticket == null)
            {
                ModelState.AddModelError("", "Не указаны данные для полёта");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            service.Update(ticket);

            return Ok(ticket);
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
