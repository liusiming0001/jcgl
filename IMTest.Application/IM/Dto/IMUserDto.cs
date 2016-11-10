/***********************************************************************
 * Module:  IMUser.cs
 * Author:  liusm
 * Purpose: Definition of the Class IMTest.IM.Dto.IMUser
 ***********************************************************************/

using Abp.AutoMapper;
using IMTest.Core.IM.IMUsers;
using System;
using Abp.Application.Services.Dto;
/// Package_Module
namespace IMTest.IM.Dto
{
    /// ÓÃ»§DTO
    [AutoMapFrom(typeof(IMUser))]
    public class IMUserDto:EntityDto<long>
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public new long Id { get; set; }
        public string Phone { get; set; }
        public int Role { get; set; }

    }
}