// File:    AdminFriendInput2.cs
// Author:  常宇峰
// Created: 2016年5月18日 13:17:24
// Purpose: Definition of Class AdminFriendInput2

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
   public class FriendOut
   {
      public long userID{get;set;}
      public int type{get;set;}
      public long friendID{get;set;}
      public DateTime createTime{get;set;}
      public String userName{get;set;}
      public String friendName{get;set;}
      public long adminUserID{get;set;}
      public int count{get;set;}
   
   }
}