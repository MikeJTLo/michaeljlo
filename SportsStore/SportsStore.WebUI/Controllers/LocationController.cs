using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class LocationController : Controller
    {
        public int PageSize = 1;
        private ILocationRepository repository2;

        public LocationController(ILocationRepository locationRepository)
        {
            repository2 = locationRepository;
        }

        public ActionResult List(int page = 1)
        {
            var locations = repository2.Locations.OrderBy(loc => loc.LocID).Skip((page - 1) * PageSize).Take(PageSize);

            var model = new LocationsListViewModel
            {
                Locations = locations,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    TotalItems = repository2.Locations.Count(),
                    ItemsPerPage = PageSize
                }
            };
            return View(model);
        }

    }
}
