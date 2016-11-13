using jrt.jcgl.Dto;
using jrt.jcgl.Schedulings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Schedulings.Exporting
{
    public interface ISchedulingsListExcelExporter
    {
        FileDto ExportToFile(List<SchedulingListDto> list);
    }
}
