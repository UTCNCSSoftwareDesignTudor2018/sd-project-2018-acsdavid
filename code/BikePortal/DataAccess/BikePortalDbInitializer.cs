﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikePortal.DataAccess
{
    public class BikePortalDbInitializer : CreateDatabaseIfNotExists<BikePortalDbContext>
    {
    }
}
