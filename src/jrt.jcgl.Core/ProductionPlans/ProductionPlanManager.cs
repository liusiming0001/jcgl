using Abp.Dependency;
using Abp.Domain.Repositories;
using jrt.jcgl.RawMaterials;
using jrt.jcgl.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.ProductionPlans
{
    public class ProductionPlanManager : ITransientDependency, IProductionPlanManager
    {
        #region 变量
        private readonly IRepository<ProductionPlan, long> _productionPlanRepository;
        private readonly IRepository<ProductionBatchDetail, long> _productionBatchDetailRepository;
        private readonly IRepository<ProductionPlanAudit, long> _productionPlanAuditRepository;
        private readonly IRepository<ProduictPlanLine, long> _produictPlanLineRepository;
        private readonly IRepository<ProdutionPlanMain, long> _produtionPlanMainRepository;
        private readonly IRepository<RawMaterial> _rawMaterialRepository;
        private readonly IRepository<Stock> _stockRepository;
        #endregion
        #region 构造函数
        public ProductionPlanManager(
           IRepository<ProductionPlan, long> _productionPlanRepository,
           IRepository<ProductionBatchDetail, long> _productionBatchDetailRepository,
           IRepository<ProductionPlanAudit, long> _productionPlanAuditRepository,
           IRepository<ProduictPlanLine, long> _produictPlanLineRepository,
           IRepository<ProdutionPlanMain, long> _produtionPlanMainRepository,
           IRepository<RawMaterial> _rawMaterialRepository,
           IRepository<Stock> _stockRepository)
        {
            this._productionPlanRepository = _productionPlanRepository;
            this._productionBatchDetailRepository = _productionBatchDetailRepository;
            this._productionPlanAuditRepository = _productionPlanAuditRepository;
            this._produictPlanLineRepository = _produictPlanLineRepository;
            this._produtionPlanMainRepository = _produtionPlanMainRepository;
            this._rawMaterialRepository = _rawMaterialRepository;
            this._stockRepository = _stockRepository;
        }
        #endregion
        #region 制定生产计划
        public async Task FormulateProdutionPlan(decimal Demand, DateTime StartDate, long[] OrganzationUnitIds)
        {
            var productionplan = await CreateProductionPlan(Demand, StartDate);
            await CreateProductionPlanMain(Demand, productionplan);
        }
        /// <summary>
        /// 创建主表
        /// </summary>
        /// <param name="Demand"></param>
        /// <param name="StartDate"></param>
        /// <returns></returns>
        #region 计划总表
        private async Task<ProductionPlan> CreateProductionPlan(decimal Demand, DateTime StartDate)
        {
            try
            {
                var productionplan = await _productionPlanRepository.FirstOrDefaultAsync(p => p.StartDate == StartDate);
                if (productionplan != null)
                    throw new Exception("当天已存在其他生产计划");
                var output = await _productionPlanRepository.InsertAsync(
                    new ProductionPlan
                    {
                        Demand = Demand,
                        StartDate = StartDate
                    }
                );

                return output;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 创建计划总表
        /// </summary>
        /// <param name="Demand"></param>
        /// <param name="ProductionPlan"></param>
        /// <returns></returns>
        private async Task CreateProductionPlanMain(decimal Demand, ProductionPlan ProductionPlan)
        {
            var raw = await _rawMaterialRepository.GetAllListAsync();
            var stock = await _stockRepository.GetAllListAsync();
            if (raw == null)
                throw new Exception("找不到任何原料信息，请先添加原料信息。");
            int count = 0;
            foreach (var item in raw)
            {
                count++;
                var plannedquantity = Demand / 150 * GetRawMaterialConstant(item, RawMaterialConstantType.M);
                var stockquantity = GetRawMaterialStockNS(item);
                var productionquantity = (plannedquantity - stockquantity) > 0 ? (plannedquantity - stockquantity) : 0;
                var ps = Math.Ceiling(productionquantity / GetRawMaterialConstant(item, RawMaterialConstantType.N));
                ProdutionPlanMain produtionplanmain = new ProdutionPlanMain
                {
                    RawMaterialId = item.Id,
                    PlannedQuantity = plannedquantity,
                    StockQuantity = stockquantity,
                    ProductionQuantity = productionquantity,
                    PS = (int)ps,
                    RawMaterialRequirement = ps * GetRawMaterialConstant(item, RawMaterialConstantType.T),
                    SerialNumber = count
                };
                await _produtionPlanMainRepository.InsertAsync(produtionplanmain);
            }
        }
        /// <summary>
        /// 获取原料常熟
        /// </summary>
        /// <param name="item"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private decimal GetRawMaterialConstant(RawMaterial item, RawMaterialConstantType type)
        {
            var constant = item.RawMaterialConstant.Where(r => r.Type == type).FirstOrDefault();
            if (constant == null)
                throw new Exception("无法找到此药品的计划生产量常数");
            return constant.Constant;
        }
        /// <summary>
        /// 获取浓缩液库存
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private decimal GetRawMaterialStockNS(RawMaterial item)
        {
            var stock = _stockRepository.GetAll().Where(s => s.RawMaterialId == item.Id && s.Type == StockType.NSY).FirstOrDefault();
            if (stock == null)
                return 0;
            return stock.StockValue;
        }
        #endregion
        #region 批次明细
        private async Task CreateProductionBatchDetail()
        {

        }
        #endregion
        #endregion
    }
}
