/***********************************************************************
 * Module:  AdminGroupUpdateInput.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.AdminGroupUpdateInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
   public class AdminGroupUpdateInput
   {
      public long groupID{get;set;}
      public String groupName{get;set;}
      public String groupNoitce{get;set;}
      public long adminUserID{get;set;}
   
   }
}