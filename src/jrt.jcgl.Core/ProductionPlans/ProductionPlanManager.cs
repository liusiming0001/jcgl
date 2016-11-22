using Abp.Configuration;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Organizations;
using jrt.jcgl.Configuration;
using jrt.jcgl.CustomHolidays;
using jrt.jcgl.RawMaterials;
using jrt.jcgl.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        private readonly IRepository<CustomHoliday, long> _cusomHolidayRepository;
        private readonly IRepository<OrganizationUnit, long> _organizationUnitRepository;
        private readonly ISettingManager SettingManager;
        private int datecount = 0;
        #endregion
        #region 构造函数
        public ProductionPlanManager(
           IRepository<ProductionPlan, long> _productionPlanRepository,
           IRepository<ProductionBatchDetail, long> _productionBatchDetailRepository,
           IRepository<ProductionPlanAudit, long> _productionPlanAuditRepository,
           IRepository<ProduictPlanLine, long> _produictPlanLineRepository,
           IRepository<ProdutionPlanMain, long> _produtionPlanMainRepository,
           IRepository<RawMaterial> _rawMaterialRepository,
           IRepository<Stock> _stockRepository,
           IRepository<CustomHoliday, long> _cusomHolidayRepository,
           ISettingManager SettingManager)
        {
            this._productionPlanRepository = _productionPlanRepository;
            this._productionBatchDetailRepository = _productionBatchDetailRepository;
            this._productionPlanAuditRepository = _productionPlanAuditRepository;
            this._produictPlanLineRepository = _produictPlanLineRepository;
            this._produtionPlanMainRepository = _produtionPlanMainRepository;
            this._rawMaterialRepository = _rawMaterialRepository;
            this._stockRepository = _stockRepository;
            this._cusomHolidayRepository = _cusomHolidayRepository;
            this.SettingManager = SettingManager;
        }
        #endregion
        #region 制定生产计划
        public async Task FormulateProdutionPlan(decimal Demand, DateTime StartDate, long[] OrganzationUnitIds, RestType RestType)
        {
            var productionplan = await CreateProductionPlan(Demand, StartDate, OrganzationUnitIds);
            await CreateProductionPlanMain(Demand, productionplan);
        }
        /// <summary>
        /// 创建主表
        /// </summary>
        /// <param name="Demand"></param>
        /// <param name="StartDate"></param>
        /// <returns></returns>
        #region 计划总表
        private async Task<ProductionPlan> CreateProductionPlan(decimal Demand, DateTime StartDate, long[] OrganzationUnitIds)
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

                foreach (var item in OrganzationUnitIds)
                {
                    await _produictPlanLineRepository.InsertAsync(new ProduictPlanLine
                    {
                        ProductionPlanId = output.Id,
                        OrganizationUnitId = item
                    });
                }

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
        private async Task<List<ProdutionPlanMain>> CreateProductionPlanMain(decimal Demand, ProductionPlan ProductionPlan)
        {
            List<ProdutionPlanMain> ProdutionPlanMains = new List<ProdutionPlanMain>();
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
                ProdutionPlanMains.Add(produtionplanmain);
                await _produtionPlanMainRepository.InsertAsync(produtionplanmain);
            }
            return ProdutionPlanMains;
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
        private async Task CreateProductionBatchDetail(List<ProdutionPlanMain> ProdutionPlanMains, long[] OrganzationUnitIds, RestType RestType, DateTime StartDate)
        {
            int count = 0;
            DateTime WorkDate = new DateTime();
            var SCXCount = OrganzationUnitIds.Count();
            foreach (var item in ProdutionPlanMains)
            {
                int organzationcount = 0;
                foreach (var o in OrganzationUnitIds)
                {
                    organzationcount++;
                    count++;
                    if (count == 1)
                    {
                        WorkDate = StartDate;
                    }
                    WorkDate = getWorkDate(WorkDate, RestType);
                    var unit = await _organizationUnitRepository.FirstOrDefaultAsync(o);
                    await _productionBatchDetailRepository.InsertAsync(new ProductionBatchDetail
                    {
                        SerailNum = count,
                        ProductionLine = unit.DisplayName,
                        MissionQuantity = item.ProductionQuantity / SCXCount,
                        BatchQuantity = GetRawMaterialConstant(item.RawMaterial, RawMaterialConstantType.N),
                        CYL = GetRawMaterialConstant(item.RawMaterial, RawMaterialConstantType.CYL),
                        SGL = GetRawMaterialConstant(item.RawMaterial, RawMaterialConstantType.SGL),
                        MissionDate = WorkDate,
                        BatchNum = getBatchNum(WorkDate, organzationcount, false)
                    });
                }
            }
        }
        private DateTime getWorkDate(DateTime LastBatchDate, RestType RestType, int count = 0)
        {
            var productioncycle = SettingManager.GetSettingValue<int>(AppSettings.ProductionSetting.ProductionCycle);
            int year = LastBatchDate.Year;
            int month = LastBatchDate.Month;
            int day = LastBatchDate.Day + productioncycle + datecount;
            if ((month == 1 ||
                month == 3 ||
                month == 5 ||
                month == 7 ||
                month == 8 ||
                month == 10) && day > 31)
            {
                month++;
                day = day - 31;
            }
            if (month == 12 && day > 31)
            {
                month = 1;
                year++;
                day = day - 31;
            }
            if ((month == 4 ||
                month == 6 ||
                month == 9 ||
                month == 11) && day > 30)
            {
                month++;
                day = day - 30;
            }
            if (year % 4 == 0 && month == 2 && day > 29)
            {
                month++;
                day = day - 29;
            }
            if (year % 4 != 0 && month == 2 && day > 28)
            {
                month++;
                day = day - 28;
            }
            var date = new DateTime(year, month, day);
            bool flag = false;
            switch (RestType)
            {
                case RestType.Normal: flag = isHolidayType1(date); break;
                case RestType.Single: flag = isHolidayType2(date); break;
                case RestType.Custom: flag = isHolidayType3(date); break;
                default: break;
            }
            if (flag == true)
            {
                datecount++;
                date = getWorkDate(LastBatchDate, RestType, datecount);
            }
            datecount = 0;
            return date;
        }
        private string getBatchNum(DateTime workdate, int organzationcount, bool isupdate)
        {
            string updatesign = "W";
            if (isupdate)
                updatesign = "G";
            string batchnum = string.Format("JP{0}{1}{2}", workdate.ToString("yyyyMMdd"), updatesign, organzationcount);
            return batchnum;
        }
        #region 休息日类型
        private bool isHolidayType1(DateTime day)
        {
            ///API未更新数据源 ！
            string url = string.Format("http://www.easybots.cn/api/holiday.php?d={0}", day.ToString("yyyyMMdd"));
            WebClient wc = new WebClient();
            Encoding enc = Encoding.GetEncoding("UTF-8");
            byte[] pageData = wc.DownloadData(url);
            string re = enc.GetString(pageData);
            var a = re.Substring(13, 1);

            if (a == "0")
                return false;
            else
                return true;
        }
        private bool isHolidayType2(DateTime day)
        {
            string url = string.Format("http://www.easybots.cn/api/holiday.php?d={0}", day.ToString("yyyyMMdd"));
            WebClient wc = new WebClient();
            Encoding enc = Encoding.GetEncoding("UTF-8");
            byte[] pageData = wc.DownloadData(url);
            string re = enc.GetString(pageData);
            var a = re.Substring(13, 1);

            if (a == "0")
                return false;
            else if (a != "0" && day.DayOfWeek == DayOfWeek.Saturday)
                return false;
            else
                return true;
        }
        private bool isHolidayType3(DateTime day)
        {
            var holiyday = _cusomHolidayRepository.FirstOrDefault(c => c.Holiday == day);
            if (holiyday == null)
                return false;
            return true;
        }
        #endregion
        #endregion
        #endregion
    }
}
