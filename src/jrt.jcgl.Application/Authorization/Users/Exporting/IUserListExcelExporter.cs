using System.Collections.Generic;
using jrt.jcgl.Authorization.Users.Dto;
using jrt.jcgl.Dto;

namespace jrt.jcgl.Authorization.Users.Exporting
{
    public interface IUserListExcelExporter
    {
        FileDto ExportToFile(List<UserListDto> userListDtos);
    }
}