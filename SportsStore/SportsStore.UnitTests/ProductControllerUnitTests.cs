using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SportsStore.Domain.Entities;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;
using SportsStore.WebUI.Models;
using SportsStore.WebUI.HtmlHelpers;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class ProductControllerUnitTests
    {
        [TestMethod]
        public void Can_Paginate()
        {
            //Arrange
            var products = new List<Product>();
            products.Add(new Product { Name = "A", ProductID = 1 });
            products.Add(new Product { Name = "B", ProductID = 2 });
            products.Add(new Product { Name = "C", ProductID = 3 });
            var mock = new Moq.Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(products.AsQueryable());


            var controller = new ProductController(mock.Object);
            controller.PageSize = 2;

            //Action
            ProductsListViewModel result = ((ViewResult)controller.List(2)).Model as ProductsListViewModel;

            //Assert
            Assert.AreEqual(1, result.Products.Count());
            Assert.AreEqual(result.Products.ToList()[0].Name, "C");
        }

        [TestMethod]
        public void Can_Create_Correct_PageViewModel()
        {
            //Arrange
            var products = new List<Product>();
            products.Add(new Product { Name = "A", ProductID = 1 });
            products.Add(new Product { Name = "B", ProductID = 2 });
            products.Add(new Product { Name = "C", ProductID = 3 });
            var mock = new Moq.Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(products.AsQueryable());


            var controller = new ProductController(mock.Object);
            controller.PageSize = 2;

            //Action
            ProductsListViewModel result = ((ViewResult)controller.List(2)).Model as ProductsListViewModel;

            //Assert
            Assert.AreEqual(3, result.PagingInfo.TotalItems);
            Assert.AreEqual(2, result.PagingInfo.CurrentPage);
            Assert.AreEqual(controller.PageSize, result.PagingInfo.ItemsPerPage);
            //Assert.AreEqual(result.ToList()[0].Name, "C");
        }

        [TestMethod]
        public void Can_Create_Page_Links()
        {
            //arrange
            HtmlHelper helper = null;
            var pagingInfo = new PagingInfo
            {
                CurrentPage = 2,
                TotalItems = 28,
                ItemsPerPage = 10
            };


            Func<int, string> pageUrlDelegate = i => "Page" + i.ToString();

            //act
            MvcHtmlString result = helper.PageLinks(pagingInfo, pageUrlDelegate);

            //assert
            Assert.AreEqual(@"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>", result.ToString());

        }
    }
}
