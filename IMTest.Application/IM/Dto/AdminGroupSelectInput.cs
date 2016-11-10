/***********************************************************************
 * Module:  AdminGroupSelectInput.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.AdminGroupSelectInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
   public class AdminGroupSelectInput
   {
      public long adminUserID{get;set;}
      public int startNum{get;set;}
      public int endNum{get;set;}
      public DateTime startTime{get;set;}
      public DateTime endTime{get;set;}
      public String groupName{get;set;}
      public long groupID{get;set;}
      public String groupNotice{get;set;}
      public String groupAdminUserName{get;set;}
      public long groupAdminUserID{get;set;}
   
   }
}