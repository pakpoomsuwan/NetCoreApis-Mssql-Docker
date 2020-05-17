using System;
using System.Collections.Generic;

namespace NetCoreApis_Mssql_Docker.DbModels
{
    public partial class CurrentProductList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
    }
}
