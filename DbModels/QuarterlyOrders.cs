using System;
using System.Collections.Generic;

namespace NetCoreApis_Mssql_Docker.DbModels
{
    public partial class QuarterlyOrders
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
