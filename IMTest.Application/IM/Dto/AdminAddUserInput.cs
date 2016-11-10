/***********************************************************************
 * Module:  AdminAddUserInput.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.AdminAddUserInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    public class AdminAddUserInput
    {
        public string userName { get; set; }
        public string passWord { get; set; }
        public string phone { get; set; }
        public string iocn { get; set; }
        public long adminUser { get; set; }
        public string nick { get; set; }
        public int role { get; set; }
    }
}