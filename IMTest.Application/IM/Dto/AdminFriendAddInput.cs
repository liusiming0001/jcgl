/***********************************************************************
 * Module:  AdminFriendAddInput.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.AdminFriendAddInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    public class AdminFriendAddInput
    {
        public long fromUserID { get; set; }
        public long toUserID { get; set; }
    }
}