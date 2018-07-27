using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_BLL.Services;
using Binary_Project_Structure_Shared.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Binary_Project_Structure.Controllers
{
    [Produces("application/json")]
    [Route("api/Crews")]
    [EnableCors("MyPolicy")]
    public class CrewsController : Controller
    {
        ICrewService service;
        IParceService parceService;
        FormatterForCrewService formatter = new FormatterForCrewService();
        public CrewsController(ICrewService service, IParceService parceService)
        {
            this.service = service;
            this.parceService = parceService;
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
            CrewDto Crew = await service.GetById(id);
            if (Crew == null)
            {
                return NotFound();
            }
            return Ok(Crew);
        }

        // GET: api/Crews/GetTen
        [HttpGet]
        [Route("GetTen")]
        public async Task<IActionResult> GetTen()
        {
            List<CrewByApiDto> crewsByApiDto = await parceService.GetCrews();
            if (crewsByApiDto == null)
            {
                return NotFound();
            }
            Task[] tasks = new Task[2];
            tasks[0] = (Task.Run(() => service.AddRange(crewsByApiDto)));
            tasks[1] = (Task.Run(() =>
             {
                 string format = "d_MMM_yyyy_h_mm_ss";
                 string path = "log_" + DateTime.Now.ToString(format) + ".csv";
                 using (StreamWriter streamWriter = new StreamWriter(new FileStream(path, FileMode.Create)))
                 {
                     Parallel.ForEach(crewsByApiDto, current =>
                         streamWriter.Write(formatter.ToCsv(current))
                     );
                 }
             }));
            Task.WaitAll(tasks);
            return Ok();
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
