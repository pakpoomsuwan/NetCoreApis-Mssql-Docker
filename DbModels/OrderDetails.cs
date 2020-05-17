﻿using System;
using System.Collections.Generic;

namespace NetCoreApis_Mssql_Docker.DbModels
{
    public partial class OrderDetails
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        public virtual Orders Order { get; set; }
        public virtual Products Product { get; set; }
    }
}