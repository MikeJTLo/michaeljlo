using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Abstract;

namespace SportsStore.Domain.Concrete
{
    public class EFProductsRepository : IProductRepository
    {
        private EFDbContext ctx = new EFDbContext();

        public IQueryable<Entities.Product> Products
        {
            get { return ctx.Products; }
        }
    }
}
