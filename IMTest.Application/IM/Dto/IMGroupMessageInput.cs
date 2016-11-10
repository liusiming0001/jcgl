/***********************************************************************
 * Module:  IMGroupMessageInput.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.IMGroupMessageInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    public class IMGroupMessageInput
    {
        public long fromUserID { get; set; }
        public long toUserID { get; set; }
        public string appkey { get; set; }
        public string content { get; set; }

    }
}