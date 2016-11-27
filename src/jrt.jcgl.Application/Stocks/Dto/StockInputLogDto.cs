using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Stocks.Dto
{
    public class StockInputLogDto : EntityDto<long>
    {
        public string StockName { get; set; }
        public decimal Quality { get; set; }
        public string HandleUserName { get; set; }
        public DateTime HandleTime { get; set; }
        public string Remark { get; set; }
        public StockType Type { get; set; }
    }
}
