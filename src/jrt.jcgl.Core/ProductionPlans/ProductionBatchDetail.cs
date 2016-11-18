// File:    ProductionBatchDetail.cs
// Author:  RD-LSM
// Created: 2016年11月18日 19:58:22
// Purpose: Definition of Class ProductionBatchDetail

using Abp.Domain.Entities;
using System;

namespace jrt.jcgl.ProductionPlans
{
   public class ProductionBatchDetail : Entity<long>
    {
      public int rawMaterial{get;set;}
      public string batchNum{get;set;}
      public int productionLineCount{get;set;}
      public decimal mission{get;set;}
      public DateTime missionDate{get;set;}
      public decimal cYL{get;set;}
      public int sGL{get;set;}
   
   }
}