/***********************************************************************
 * Module:  GroupAdminSetInput.cs
 * Author:  liusm
 * Purpose: Definition of the Class IMTest.IM.Dto.GroupAdminSetInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    /// IM群管理员设置
    public class GroupAdminSetInput
    {
        private string GroupId { get; set; }
        private string UserId { get; set; }
        private int Type { get; set; }

    }
}