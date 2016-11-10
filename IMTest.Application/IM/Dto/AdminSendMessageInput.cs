/***********************************************************************
 * Module:  AdminSendMessageInput.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.AdminSendMessageInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
   public class AdminSendMessageInput
   {
      public String fromUserID{get;set;}
      public String toUserID{get;set;}
      public String content{get;set;}
      public int type{get;set;}
   
   }
}