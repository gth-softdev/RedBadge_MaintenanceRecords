﻿using System.Web;
using System.Web.Mvc;

namespace RedBadge_MaintenanceRecords
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
