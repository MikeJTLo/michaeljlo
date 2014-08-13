﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    public interface ILocationRepository
    {
        IQueryable<Location> Locations { get; }
    }
}
