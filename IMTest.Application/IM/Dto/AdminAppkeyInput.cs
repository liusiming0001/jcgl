/***********************************************************************
 * Module:  AdminAppkeyInput.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.AdminAppkeyInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    /// AppKeyπ‹¿Ì
    public class AdminAppkeyInput
    {
        private long ID { get; set; }
        private string Name { get; set; }
        private string Key { get; set; }
        private DateTime CreateTime { get; set; }
        private long CreateUserID { get; set; }

    }
}