using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Stocks.Dto
{
    [AutoMapFrom(typeof(Stock))]
    public class StockListDto : EntityDto<long>
    {
        public string RawMaterialName { get; set; }
        public decimal StockValue { get; set; }
        public StockType Type { get; set; }
    }
}
