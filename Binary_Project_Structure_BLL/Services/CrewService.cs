using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_DataAccess.Interfaces;
using Binary_Project_Structure_DataAccess.Models;
using Binary_Project_Structure_Shared.DTOs;

namespace Binary_Project_Structure_BLL.Services
{
    public class CrewService : Service, ICrewService
    {
        public CrewService(IUnitOfWork context) : base(context)
        {

        }
        public async Task<List<CrewDto>> GetAll()
        {
            return await GetAll<Crew, CrewDto>();
        }

        public async Task<CrewDto> GetById(int id)
        {
            return await GetById<Crew, CrewDto>(x => x.Id == id);
        }

        public async Task<CrewDto> Create(CrewDto entity)
        {
            return await Create<CrewDto, Crew>(entity);
        }

        public async Task AddRange(List<CrewByApiDto> entitiesDto)
        {
            foreach (var crewByApiDto in entitiesDto)
            {
                Pilot pilot = iMapper.Map<CrewByApiDto, Pilot>(crewByApiDto);
                if (pilot == null)
                    throw new NullReferenceException();

                pilot.Id = default(int);
                Pilot pilotAdded = await context.Set<IRepository<Pilot>>().Create(pilot);

                Crew crew = iMapper.Map<CrewByApiDto, Crew>(crewByApiDto);
                crew.PilotId = pilotAdded.Id;

                crew.Id = default(int);
                Crew crewAdded = await context.Set<IRepository<Crew>>().Create(crew);

                foreach (var Stewardess in crewByApiDto.Stewardess)
                {
                    Stewardess stewardess = iMapper.Map<StewardessByApiDto, Stewardess>(Stewardess);
                    stewardess.CrewId = crewAdded.Id;

                    stewardess.Id = default(int);
                    await context.Set<IRepository<Stewardess>>().Create(stewardess);
                }
            }
        }

        public async Task<CrewDto> Update(CrewDto entity)
        {
            return await Update<CrewDto, Crew>(entity);
        }

        async Task<bool> ICrewService.Delete(int id)
        {
            return await Delete<Crew>(x => x.Id == id);
        }
    }
}
