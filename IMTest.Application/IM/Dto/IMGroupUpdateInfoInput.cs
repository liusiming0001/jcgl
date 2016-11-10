/***********************************************************************
 * Module:  IMGroupUpdateInfoInput.cs
 * Author:  liusm
 * Purpose: Definition of the Class IMTest.IM.Dto.IMGroupUpdateInfoInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    /// IM群信息修改
    public class IMGroupUpdateInfoInput
    {
        public int Type { get; set; }
        public string GroupNioce { get; set; }
        public string GroupName { get; set; }

    }
}