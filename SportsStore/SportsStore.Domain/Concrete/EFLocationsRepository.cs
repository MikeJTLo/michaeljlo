using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Abstract;

namespace SportsStore.Domain.Concrete
{
    public class EFLocationsRepository : ILocationRepository
    {
        private EFDbContext ctx2 = new EFDbContext();

        public IQueryable<Entities.Location> Locations
        {
            get { return ctx2.Locations; }
        }
    }
}
