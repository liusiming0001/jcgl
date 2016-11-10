/***********************************************************************
 * Module:  IMFriendListOutput.cs
 * Author:  liusm
 * Purpose: Definition of the Class IMTest.IM.Dto.IMFriendListOutput
 ***********************************************************************/

using System;
using System.Collections.Generic;

/// Package_Module
namespace IMTest.IM.Dto
{
   /// IM查询好友列表DTO
   public class IMFriendListOutput
   {
      public List<FriendOut> FriendList { get; set; }
    }
}