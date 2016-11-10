/***********************************************************************
 * Module:  GroupMemberSetInput.cs
 * Author:  liusm
 * Purpose: Definition of the Class IMTest.IM.Dto.GroupMemberSetInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    /// 群成员操作
    public class GroupMemberSetInput
    {
        public string GroupId { get; set; }
        public string Userid { get; set; }
        public int type { get; set; }

    }
}