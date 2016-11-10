/***********************************************************************
 * Module:  Group.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.Core.IM.Group
 ***********************************************************************/

using Abp.Domain.Entities;
using System;

/// Package_Module
namespace IMTest.Core.IM.IMGroups
{
    public class IMGroup : Entity
    {
        public virtual int GroupID { get; set; }
        public virtual long AdminUserID { get; set; }
        public virtual string GroupName { get; set; }
        public virtual string GroupNioce { get; set; }
        public virtual int Type { get; set; }

    }

    public enum IMGroupType
    {
         Deleted,
         Normal,
        Shield
    }
}