// File:    AdminUserMessageInput.cs
// Author:  cyf
// Created: 2016Äê5ÔÂ24ÈÕ 14:46:57
// Purpose: Definition of Class AdminUserMessageInput

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
   public class AdminUserMessageInput
   {
      public long fromUserID{get;set;}
      public long adminUserID{get;set;}
      public long toUserID{get;set;}
      public int startNum{get;set;}
      public int endNUm{get;set;}
      public DateTime startTime{get;set;}
      public DateTime endTime{get;set;}
   
   }
}