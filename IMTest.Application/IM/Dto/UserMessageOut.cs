// File:    UserMessageOut.cs
// Author:  cyf
// Created: 2016Äê5ÔÂ19ÈÕ 13:42:11
// Purpose: Definition of Class UserMessageOut

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    public class UserMessageOut
    {
        public long fromUserID { get; set; }
        public long toUroupID { get; set; }
        public string message { get; set; }
        public string fromUserName { get; set; }
        public string toUserName { get; set; }
        public int type { get; set; }
        public DateTime createTime { get; set; }
        public long ID { get; set; }

        public int count { get; set; }

    }
}