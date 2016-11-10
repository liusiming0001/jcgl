/***********************************************************************
 * Module:  IMUserMessageInput.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.IMUserMessageInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    public class IMUserMessageInput
    {
        public long fromUserID { get; set; }
        public long toUserID { get; set; }
        public long appkey { get; set; }

    }
}