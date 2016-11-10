/***********************************************************************
 * Module:  IMregisterInput.cs
 * Author:  liusm
 * Purpose: Definition of the Class IMTest.IM.Dto.IMregisterInput
 ***********************************************************************/

using Abp.Application.Services.Dto;
using System;
using System.ComponentModel.DataAnnotations;

/// Package_Module
namespace IMTest.IM.Dto
{
    /// IM注册DTO,用户ID,昵称,密码,Appkey,权限
    public class IMRegisterInput: IInputDto
    {
        [Required]
        public long UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Appkey { get; set; }
        [Required]
        public int Role { get; set; }
    }
}