/***********************************************************************
 * Module:  AdminAppKeySelectInput.cs
 * Author:  Administrator
 * Purpose: Definition of the Class IMTest.IM.Dto.AdminAppKeySelectInput
 ***********************************************************************/

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    public class AdminAppKeySelectInput
    {
        public long adminUserID { get; set; }
        public int startNum { get; set; }
        public int endNum { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string key { get; set; }
        public long ID { get; set; }
        public string value { get; set; }

    }
}