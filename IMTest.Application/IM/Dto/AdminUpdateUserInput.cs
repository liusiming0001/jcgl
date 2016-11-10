// File:    AdminUpdateUserInput.cs
// Author:  cyf
// Created: 2016Äê5ÔÂ24ÈÕ 10:17:34
// Purpose: Definition of Class AdminUpdateUserInput

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
   public class AdminUpdateUserInput
   {
      public string userName{get;set;}
      public string passWord {get;set;}
      public string phone {get;set;}
      public string iocn {get;set;}
      public long adminUser{get;set;}
      public string nick {get;set;}
      public int role{get;set;}
   
   }
}