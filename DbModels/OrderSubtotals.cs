using System;
using System.Collections.Generic;

namespace NetCoreApis_Mssql_Docker.DbModels
{
    public partial class OrderSubtotals
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
