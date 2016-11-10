/***********************************************************************
 * Module:  IMChangePasswordInput.cs
 * Author:  liusm
 * Purpose: Definition of the Class IMTest.IM.Dto.IMChangePasswordInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    /// IMÃÜÂëÐÞ¸ÄDTO
    public class IMChangePasswordInput
    {
        private string UserID { get; set; }
        private string OriginalPassword { get; set; }
        private string NewPassword { get; set; }
        private string ConfirmPassword { get; set; }

    }
}