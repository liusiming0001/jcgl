/***********************************************************************
 * Module:  AdminGroupMessageInput.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.AdminGroupMessageInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    public class AdminGroupMessageInput
    {
        public string groupName { get; set; }
        public long fromUserID { get; set; }
        public long adminUserID { get; set; }
        public long toUserID { get; set; }
        public int startNum { get; set; }
        public int endNUm { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        private long groupID { get; set; }

    }
}