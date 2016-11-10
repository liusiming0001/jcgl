/***********************************************************************
 * Module:  AppKey.cs
 * Author:  Administrator
 * Purpose: Definition of the Class com.QCYP.RealProperty.IMServer.Domain.AppKey
 ***********************************************************************/

using Abp.Domain.Entities;
using System;

/// Package_Module
namespace IMTest.Core.IM.IMAppKeys
{
   /// AppKeyπ‹¿Ì
   public class IMAppKey:Entity
   {
        //public virtual long ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Key { get; set; }
        public virtual DateTime CreateTime { get; set; }
        public virtual long CreateUserID { get; set; }

    }
}