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
        public async Task<IActionResult> GetTickets()
        {
            return Ok(await service.GetAll());
        }

        // GET: api/Tickets/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicket(int id)
        {
            TicketDto ticket = await service.GetById(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        // POST: api/Tickets
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TicketDto ticket)
        {
            if (ticket == null)
            {
                ModelState.AddModelError("", "Не указаны данные для билета");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Create(ticket);

            return Created("api/Tickets", ticket);
        }

        // PUT: api/Tickets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]TicketDto ticket)
        {
            if (ticket == null)
            {
                ModelState.AddModelError("", "Не указаны данные для полёта");
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await service.Update(ticket);

            return Ok(ticket);
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
