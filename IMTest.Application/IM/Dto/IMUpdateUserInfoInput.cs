/***********************************************************************
 * Module:  IMUpdateUserInfoInput.cs
 * Author:  liusm
 * Purpose: Definition of the Class IMTest.IM.Dto.IMUpdateUserInfoInput
 ***********************************************************************/

using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel.DataAnnotations;

/// Package_Module
namespace IMTest.IM.Dto
{
    /// 修改IM用户信息DTO
    public class IMUpdateUserInfoInput : IValidate, IPassivable
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string Phone { get; set; }

        public bool IsActive
        {
            get;
            set;
        }
    }
}