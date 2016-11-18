// File:    ProdutionPlanMain.cs
// Author:  RD-LSM
// Created: 2016年11月18日 19:59:54
// Purpose: Definition of Class ProdutionPlanMain

using Abp.Domain.Entities;
using System;

namespace jrt.jcgl.ProductionPlans
{
    public class ProdutionPlanMain : Entity<long>
    {
        public decimal plannedQuantity { get; set; }
        public decimal stockQuantity { get; set; }
        public decimal productionQuantity { get; set; }
        public int pS { get; set; }
        public int rawMaterialRequirement { get; set; }
        public int stockId { get; set; }
        public int rawMaterialId { get; set; }

        public System.Collections.Generic.List<ProduictPlanLine> produictPlanLine { get; set; }

    }
}