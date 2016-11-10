/***********************************************************************
 * Module:  GroupRelationship.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.Core.IM.GroupRelationship
 ***********************************************************************/

using Abp.Domain.Entities;
using System;
using IMTest.Core.IM.IMGroups;
/// Package_Module
namespace IMTest.Core.IM.IMGroupRelationships
{
    /// Èº¹ØÏµ
    public class IMGroupRelationship : Entity
    {
        public virtual IMGroup group { get; set; }

        //public virtual long ID { get; set; }
        public virtual int GroupID { get; set; }
        public virtual long UserID { get; set; }
        public virtual int Type { get; set; }
        public virtual int GroupMessageType { get; set; }

    }
    public enum IMGroupRelationshipType
    {
        Admin,
        Lord,
        FriendsGroup
    }
}