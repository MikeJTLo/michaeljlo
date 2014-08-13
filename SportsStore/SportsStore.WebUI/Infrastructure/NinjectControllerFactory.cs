using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel = new StandardKernel();

        public NinjectControllerFactory()
        {
            //var products = new List<Product>();
            //products.Add(new Product { Name = "Sneaker"});
            //products.Add(new Product { Name = "Baseball" });
            //products.Add(new Product { Name = "Boxing Glove" });
            //var mock = new Moq.Mock<IProductRepository>();
            //mock.Setup(m => m.Products).Returns(products.AsQueryable());
            ninjectKernel.Bind<IProductRepository>().To<EFProductsRepository>();
            ninjectKernel.Bind<ILocationRepository>().To<EFLocationsRepository>();
            //we're going to add bindings.
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ?
                null : (IController)ninjectKernel.Get(controllerType);
        }

    }
}