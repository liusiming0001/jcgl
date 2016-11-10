/***********************************************************************
 * Module:  IMGroupCreatInput.cs
 * Author:  liusm
 * Purpose: Definition of the Class IMTest.IM.Dto.IMGroupCreatInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    /// IM´´½¨ÈºDTO
    public class IMGroupCreatInput
    {
        public int Type { get; set; }
        public string GroupNioce { get; set; }
        public string GroupName { get; set; }
        public string AdminUserID { get; set; }

    }
}