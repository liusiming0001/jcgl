using jrt.jcgl.ProductionPlans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace jrt.jcgl.Tests.ProductionPlans
{
    public class ProductionPlansAppService_Tests: AppTestBase
    {
        private readonly IProductionPlansAppService _productionPlansAppService;

        public ProductionPlansAppService_Tests()
        {
            _productionPlansAppService = Resolve<IProductionPlansAppService>();
        }
        [Fact]
        public async Task Test_CreateProductionPlans()
        {
            await _productionPlansAppService.CreateProductionPlans();
        }
    }
}
