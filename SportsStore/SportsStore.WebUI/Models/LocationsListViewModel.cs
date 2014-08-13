using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Models
{
    public class LocationsListViewModel
    {
        public IEnumerable<Location> Locations { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}