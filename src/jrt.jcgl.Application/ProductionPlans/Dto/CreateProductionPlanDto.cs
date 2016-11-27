using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.ProductionPlans.Dto
{
    public class CreateProductionPlanDto
    {
        public DateTime StartDateTime { get; set; }

        public decimal Value { get; set; }

        public RestType RestType { get; set; }

        public long[] Organzations { get; set; }
    }
}
