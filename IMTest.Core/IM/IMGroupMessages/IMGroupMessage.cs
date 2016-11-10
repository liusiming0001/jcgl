/***********************************************************************
 * Module:  GroupMessage.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.Core.IM.GroupMessage
 ***********************************************************************/

using Abp.Domain.Entities;
using System;

/// Package_Module
namespace IMTest.Core.IM.IMGroupMessages
{
   public class IMGroupMessage : Entity
    {
      /*public System.Collections.ArrayList group;
      
      /// <pdGenerated>default getter</pdGenerated>
      public System.Collections.ArrayList GetGroup()
      {
         if (group == null)
            group = new System.Collections.ArrayList();
         return group;
      }
      
      /// <pdGenerated>default setter</pdGenerated>
      public void SetGroup(System.Collections.ArrayList newGroup)
      {
         RemoveAllGroup();
         foreach (IMGroup.IMGroup oGroup in newGroup)
            AddGroup(oGroup);
      }
      
      /// <pdGenerated>default Add</pdGenerated>
      public void AddGroup(IMGroup.IMGroup newGroup)
      {
         if (newGroup == null)
            return;
         if (this.group == null)
            this.group = new System.Collections.ArrayList();
         if (!this.group.Contains(newGroup))
            this.group.Add(newGroup);
      }
      
      /// <pdGenerated>default Remove</pdGenerated>
      public void RemoveGroup(IMGroup.IMGroup oldGroup)
      {
         if (oldGroup == null)
            return;
         if (this.group != null)
            if (this.group.Contains(oldGroup))
               this.group.Remove(oldGroup);
      }
      
      /// <pdGenerated>default removeAll</pdGenerated>
      public void RemoveAllGroup()
      {
         if (group != null)
            group.Clear();
      }*/
   
      public virtual long GroupMessageID { get; set; }
        public virtual long FromUserID { get; set; }
        public virtual int ToGroupID { get; set; }
        public virtual String Message { get; set; }
        public virtual int Type { get; set; }

    }

    public enum IMGroupMessageType
    {
        Normal,
        Shield,
        Gag
    }
}