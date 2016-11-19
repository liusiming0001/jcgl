// File:    StockLog.cs
// Author:  RD-LSM
// Created: 2016年11月18日 20:04:09
// Purpose: Definition of Class StockLog

using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using jrt.jcgl.Authorization.Users;
using System;

namespace jrt.jcgl.Stocks
{
    public class StockLog : FullAuditedEntity<long>
    {
        public virtual int StockId { get; set; }
        public decimal Quality { get; set; }
        public virtual long? HandleUserId { get; set; }
        public DateTime HandleTime { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual User HandleUser { get; set; }
    }
}