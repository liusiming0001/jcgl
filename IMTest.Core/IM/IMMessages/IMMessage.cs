/***********************************************************************
 * Module:  Message.cs
 * Author:  liusm
 * Purpose: Definition of the Class IMTest.Core.IM.Message
 ***********************************************************************/

using Abp.Domain.Entities;
using System;

/// Package_Module
namespace IMTest.Core.IM.IMMessages
{
    public class IMMessage : Entity
    {
        public virtual long MessageID { get; set; }
        public virtual long FromUserID { get; set; }
        public virtual long ToUserID { get; set; }
        public virtual string MessageInfo { get; set; }
        public virtual int Type { get; set; }
        public virtual long CrearteTime { get; set; }

    }

    public enum IMMessageType
    {
        Text,
        Audio,
        Vedio,
        File,
        Location,
    }
}