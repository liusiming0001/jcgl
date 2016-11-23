using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using jrt.jcgl.RawMaterials;
using jrt.jcgl.Stocks.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Stocks
{
    public class StocksAppService : IStocksAppService
    {
        #region 变量
        private readonly IRepository<RawMaterial> _rawMaterialRepository;
        private readonly IRepository<Stock> _stockRepository;
        private readonly IRepository<StockLog, long> _stockLogRepository;
        #endregion

        #region 构造函数
        public StocksAppService(
            IRepository<RawMaterial> _rawMaterialRepository,
            IRepository<Stock> _stockRepository,
            IRepository<StockLog, long> _stockLogRepository)
        {
            this._rawMaterialRepository = _rawMaterialRepository;
            this._stockRepository = _stockRepository;
            this._stockLogRepository = _stockLogRepository;
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 添加库存
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task StockInput(StocksInputDto input)
        {
            try
            {
                var stock = await _stockRepository.FirstOrDefaultAsync(input.Id);
                stock.StockValue = stock.StockValue + input.InputValue;
                await _stockRepository.UpdateAsync(stock);
                await _stockLogRepository.InsertAsync(new StockLog
                {
                    StockId = input.Id,
                    HandleUserId = input.UserId,
                    Quality = input.InputValue,
                    Remark=input.Remark,
                    HandleTime = DateTime.Now,
                    Type=StockLogType.Input
                });
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 出库库存
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task StockOutput(StocksOutputDto input)
        {
            try
            {
                var stock = await _stockRepository.FirstOrDefaultAsync(input.Id);
                stock.StockValue = stock.StockValue - input.OutputValue;
                await _stockRepository.UpdateAsync(stock);
                await _stockLogRepository.InsertAsync(new StockLog
                {
                    StockId = input.Id,
                    HandleUserId = input.UserId,
                    Quality = -input.OutputValue,
                    Remark = input.Remark,
                    HandleTime = DateTime.Now,
                    Type=StockLogType.Output
                });
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        /// <summary>
        /// 获取库存列表
        /// </summary>
        /// <returns></returns>
        public async Task<ListResultOutput<StockListDto>> GetStockList()
        {
            try
            {
                var query = from log in _stockRepository.GetAll()
                            select new
                            {
                                log,
                                RawMaterialName = log.RawMaterial.Name,
                                Type = log.Type,
                            };

                var items = await query.OrderBy(q => q.RawMaterialName).ToListAsync();
                var output = items.Select(i =>
                {
                    var dto = i.log.MapTo<StockListDto>();
                    dto.RawMaterialName = i.RawMaterialName;
                    dto.Type = i.Type;
                    return dto;
                }).ToList();
                return new ListResultOutput<StockListDto>(output);
            }
            catch (Exception e)
            {
                throw e;
            }
        } 
        #endregion
    }
}
