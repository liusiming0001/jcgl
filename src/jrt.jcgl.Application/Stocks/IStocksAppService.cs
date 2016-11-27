using Abp.Application.Services;
using Abp.Application.Services.Dto;
using jrt.jcgl.Stocks.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Stocks
{
    public interface IStocksAppService : IApplicationService
    {
        Task StockInput(StocksInputDto input);
        Task StockOutput(StocksOutputDto input);
        Task<ListResultOutput<StockListDto>> GetStockList();
        Task<PagedResultOutput<StockOutputLogDto>> GetStockOutputLog(GetStockOutputLogInput input);
        Task<PagedResultOutput<StockInputLogDto>> GetStockInputLog(GetStockInputLogInput input);
    }
}
