using System.Collections.Generic;
using jrt.jcgl.Auditing.Dto;
using jrt.jcgl.Dto;

namespace jrt.jcgl.Auditing.Exporting
{
    public interface IAuditLogListExcelExporter
    {
        FileDto ExportToFile(List<AuditLogListDto> auditLogListDtos);
    }
}
