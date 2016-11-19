// File:    Stock.cs
// Author:  RD-LSM
// Created: 2016Äê11ÔÂ18ÈÕ 20:02:56
// Purpose: Definition of Class Stock

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using jrt.jcgl.RawMaterials;
using System;
using System.Collections.Generic;

namespace jrt.jcgl.Stocks
{
    public class Stock : FullAuditedEntity<int>
    {
        public virtual int? RawMaterialId { get; set; }
        public decimal StockValue { get; set; }
        public StockType Type { get; set; }

        public virtual ICollection<StockLog> stockLog { get; set; }
        public virtual RawMaterial RawMaterial { get; set; }
    }
}