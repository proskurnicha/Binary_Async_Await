using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_DataAccess.Repositories;
using Binary_Project_Structure_DataAccess.Models;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Linq;

namespace Binary_Project_Structure_DataAccess.Repositories
{
    public class StewardessRepository : Repository<Stewardess>
    {
        public async override Task<Stewardess> Update(Stewardess entity)
        {
            Expression<Func<Stewardess, bool>> filter = x => x.Id == entity.Id;
            Stewardess stewardess = await base.GetById(filter);
            
            if (stewardess == null)
                return null;

            context.Set<Stewardess>().FirstOrDefault(filter).DateBirth = entity.DateBirth;
            context.Set<Stewardess>().FirstOrDefault(filter).Name = entity.Name;
            context.Set<Stewardess>().FirstOrDefault(filter).Surname = entity.Surname;
            await context.SaveChangesAsync();
            return stewardess;
        }
    }
}
