// File:    RawMaterialConstant.cs
// Author:  RD-LSM
// Created: 2016年11月18日 20:07:17
// Purpose: Definition of Class RawMaterialConstant

using Abp.Domain.Entities;
using System;

namespace jrt.jcgl.RawMaterials
{
    public class RawMaterialConstant : Entity<int>
    {
        public int rawMaterialId { get; set; }
        public RawMaterialConstantType type { get; set; }
        public decimal constant { get; set; }

    }
}