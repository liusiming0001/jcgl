using jrt.jcgl.DataExporting.Excel.EpPlus;
using jrt.jcgl.Dto;
using jrt.jcgl.Schedulings.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Schedulings.Exporting
{
    public class SchedulingsListExcelExporter : EpPlusExcelExporterBase, ISchedulingsListExcelExporter
    {
        public FileDto ExportToFile(List<SchedulingListDto> list)
        {
            return CreateExcelPackage(
                            "排班表.xlsx",
                            excelPackage =>
                            {
                                var sheet = excelPackage.Workbook.Worksheets.Add(L("AuditLogs"));
                                sheet.OutLineApplyStyle = true;

                                AddHeader(
                                    sheet,
                                    L("SchedulingDate"),
                                    L("ExtractBatchNum"),
                                    L("ExtractMemberName"),
                                    L("ExtractWorkInfo"),
                                    L("MembraneBatchNum"),
                                    L("MembraneMemberName"),
                                    L("MembraneWorkInfo"),
                                    L("MedicinalName"),
                                    L("WorkType"),
                                    L("Remark")
                                );

                                AddObjects(
                                    sheet, 2, list,
                                    _ => _.SchedulingDate,
                                    _ => _.ExtractBatchNum,
                                    _ => _.ExtractMemberName,
                                    _ => _.ExtractWorkInfo,
                                    _ => _.MembraneBatchNum,
                                    _ => _.MembraneMemberName,
                                    _ => _.MembraneWorkInfo,
                                    _ => _.MedicinalName,
                                    _ => L(_.WorkType.ToString()),
                                    _ => _.Remark
                                    );

                                //Formatting cells

                                var timeColumn = sheet.Column(1);
                                timeColumn.Style.Numberformat.Format = "mm-dd-yy";
                            });
        }
    }
}
