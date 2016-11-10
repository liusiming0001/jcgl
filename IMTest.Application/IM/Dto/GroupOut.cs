/***********************************************************************
 * Module:  GroupOut.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.GroupOut
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    public class GroupOut
    {
        public string gdminUserID { get; set; }
        public string gdminUserName { get; set; }
        public string groupName { get; set; }
        public string groupNioce { get; set; }
        public int type { get; set; }
        public DateTime createTime { get; set; }

    }
}