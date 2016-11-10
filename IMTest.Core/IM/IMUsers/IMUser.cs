/***********************************************************************
 * Module:  User.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.Core.IM.User
 ***********************************************************************/

using Abp.Domain.Entities;
using IMTest.IM.IMUsers;
using System;

/// Package_Module
namespace IMTest.Core.IM.IMUsers
{
    public class IMUser :IMUserBase
    {
        //public new long Id { get; set; }
        public virtual string AppKey { get; set; }
        public virtual string Icon { get; set; }
        public virtual string Phone { get; set; }
        /// 就是Excel中的房屋类型
        public virtual string PassWord { get; set; }
        public virtual int Role { get; set; }
        public virtual string NickName { get; set; }
        public virtual int UserType { get; set; }
        //public virtual long UserID { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual long CreateUserID { get; set; }

    }

    public enum IMUserType
    {
        Logout,
        Normal,
        Deleted
    }
}