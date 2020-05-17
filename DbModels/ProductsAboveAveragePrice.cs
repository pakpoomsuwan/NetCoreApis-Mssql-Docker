using System;
using System.Collections.Generic;

namespace NetCoreApis_Mssql_Docker.DbModels
{
    public partial class ProductsAboveAveragePrice
    {
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
    }
}
