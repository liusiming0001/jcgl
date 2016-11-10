/***********************************************************************
 * Module:  Friend.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.Core.IM.Friend
 ***********************************************************************/

using Abp.Domain.Entities;
using System;

/// Package_Module
namespace IMTest.Core.IM.IMFriends
{
    /// 好友基础信息
    public class IMFriend : Entity
    {
        public virtual long FriendID { get; set; }
        public virtual long FromID { get; set; }
        public virtual long ToUserID { get; set; }
        public virtual int Type { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual long CreateUserID { get; set; }

    }

    public enum IMFriendType
    {
        Fried,
        BlackList
    }
}