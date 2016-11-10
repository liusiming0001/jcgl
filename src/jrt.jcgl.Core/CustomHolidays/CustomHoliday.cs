using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.CustomHolidays
{
    public class CustomHoliday:Entity<long>
    {
        /// <summary>
        /// 自定义休息日
        /// </summary>
        public DateTime Holiday { get; set; }
    }
}
