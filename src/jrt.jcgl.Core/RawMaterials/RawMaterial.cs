using Abp.Domain.Entities;
using System;

namespace jrt.jcgl.RawMaterials
{
    public class RawMaterial:Entity<int>
    {
        public string name { get; set; }
        public string batchNumber { get; set; }
        public string producer { get; set; }
        public string manufacturer { get; set; }
        public string supplier { get; set; }
        public string level { get; set; }
        public string specifications { get; set; }
        public UnitsType units { get; set; }

        public System.Collections.Generic.List<RawMaterialConstant> rawMaterialConstant { get; set; }
    }
}