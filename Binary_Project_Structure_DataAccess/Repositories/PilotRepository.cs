using Binary_Project_Structure_DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class PilotRepository : Repository<Pilot>
    {
        public async override Task<Pilot> Update(Pilot entity)
        {
            Expression<Func<Pilot, bool>> filter = x => x.Id == entity.Id;
            Pilot pilot = await base.GetById(filter);

            if (pilot == null)
                return null;

            pilot.DateBirth = entity.DateBirth;
            pilot.Experience = entity.Experience;
            pilot.Name = entity.Name;
            pilot.Surname = entity.Surname;
            return pilot;

        }
    }
}
