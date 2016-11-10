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
    /// IMע��DTO,�û�ID,�ǳ�,����,Appkey,Ȩ��
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