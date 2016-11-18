// File:    Stock.cs
// Author:  RD-LSM
// Created: 2016Äê11ÔÂ18ÈÕ 20:02:56
// Purpose: Definition of Class Stock

using Abp.Domain.Entities;
using System;

namespace jrt.jcgl.Stocks
{
    public class Stock : Entity<int>
    {
        public int rawMaterialId { get; set; }
        public decimal stockValue { get; set; }
        public int type { get; set; }

        public System.Collections.Generic.List<StockLog> stockLog { get; set; }
    }
}