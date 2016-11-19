using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.ProductionPlans
{
    public interface IProductionPlanManager
    {
        Task FormulateProdutionPlan(decimal Demand,DateTime StartDate,long[] OrganzationUnitIds);
    }
}
