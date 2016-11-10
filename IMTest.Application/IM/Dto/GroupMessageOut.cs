/***********************************************************************
 * Module:  GroupMessageOut.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.GroupMessageOut
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    public class GroupMessageOut
    {
        public long groupMessageID { get; set; }
        public long fromUserID { get; set; }
        public long toGroupID { get; set; }
        public string message { get; set; }
        public string fromUserName { get; set; }
        public string toGroupName { get; set; }
        public int type;
        public DateTime createTime { get; set; }

    }
}