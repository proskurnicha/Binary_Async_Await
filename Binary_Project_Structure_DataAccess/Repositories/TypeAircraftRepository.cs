using System;
using System.Collections.Generic;
using System.Text;
using Binary_Project_Structure_DataAccess.Repositories;
using Binary_Project_Structure_DataAccess.Models;

namespace Binary_Project_Structure_DataAccess.Repositories
{
    public  class TypeAircraftRepository : Repository<TypeAircraft>
    {
        public override TypeAircraft Update(TypeAircraft entity)
        {
            Func<TypeAircraft, bool> filter = x => x.Id == entity.Id;
            TypeAircraft typeAircraft = base.GetById(filter);
            
            if (typeAircraft == null)
                return null;

            typeAircraft.NumberPlaces = entity.NumberPlaces;
            typeAircraft.AircraftModel = entity.AircraftModel;
            typeAircraft.CarryingCapacity = entity.CarryingCapacity;
            return typeAircraft;
        }
    }
}
