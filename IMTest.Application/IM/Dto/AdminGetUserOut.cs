// File:    AdminGetUserOut.cs
// Author:  �����
// Created: 2016��5��18�� 13:31:19
// Purpose: Definition of Class AdminGetUserOut

using System;

/// Package_Module
namespace IMTest.IM.Dto
{
    public class AdminGetUserOut
    {
        public string userID { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public int role { get; set; }
        public int type { get; set; }
        public int icon { get; set; }
        public int phone { get; set; }
        public DateTime createTime { get; set; }

    }
}