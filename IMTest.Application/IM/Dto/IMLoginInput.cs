/***********************************************************************
 * Module:  IMLoginInput.cs
 * Author:  liusm
 * Purpose: Definition of the Class IMTest.IM.Dto.IMLoginInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    /// 登陆DTO 用户ID，用户密码
    public class IMLoginInput
    {
        public string UserId { get; set; }
        public string PassWord { get; set; }

    }
}