using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Stocks.Dto
{
    public class StocksOutputDto:EntityDto
    {
        public decimal OutputValue { get; set; }
        public long UserId { get; set; }
        public string Remark { get; set; }
    }
}
