// File:    AdminFriendInput.cs
// Author:  常宇峰
// Created: 2016年5月18日 13:17:24
// Purpose: Definition of Class AdminFriendInput

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    public class AdminFriendSelectInput
    {
        public long fromUserID { get; set; }
        public bool order { get; set; }
        public int endNum { get; set; }
        public int startNum { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public long adminUserID { get; set; }
        public long toUserID { get; set; }

    }
}