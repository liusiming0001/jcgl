/***********************************************************************
 * Module:  IMGroupDto.cs
 * Author:  liusm
 * Purpose: Definition of the Class IMTest.IM.Dto.IMGroupDto
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    /// IMȺDTO
    public class IMGroupDto
    {
        public int Type { get; set; }
        public string GroupNioce { get; set; }
        public string GroupName { get; set; }
        public string AdminUserID { get; set; }
        public string GroupId { get; set; }

    }
}