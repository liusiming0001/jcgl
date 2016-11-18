// File:    StockLog.cs
// Author:  RD-LSM
// Created: 2016年11月18日 20:04:09
// Purpose: Definition of Class StockLog

using Abp.Domain.Entities;
using System;

namespace jrt.jcgl.Stocks
{
    public class StockLog : Entity<long>
    {
        private int stockId { get; set; }
        private decimal quality { get; set; }
        private int handleUserId { get; set; }
        private DateTime handleTime { get; set; }

    }
}