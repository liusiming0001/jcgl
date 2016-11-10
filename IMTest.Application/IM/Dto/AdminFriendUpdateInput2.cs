/***********************************************************************
 * Module:  AdminFriendUpdateInput2.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.AdminFriendUpdateInput2
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    public class AdminFriendUpdateInput2
    {
        public long fromUserID { get; set; }
        public long toUserID { get; set; }
        public long adminUserID { get; set; }

    }
}