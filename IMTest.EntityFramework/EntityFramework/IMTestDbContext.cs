using System.Data.Common;
using Abp.Zero.EntityFramework;
using IMTest.Authorization.Roles;
using IMTest.MultiTenancy;
using IMTest.Users;
using System.Data.Entity;
using IMTest.Core.IM.IMUsers;
using IMTest.Core.IM.IMGroupRelationships;
using IMTest.Core.IM.IMGroups;
using IMTest.Core.IM.IMFriends;
using IMTest.Core.IM.IMGroupMessages;
using IMTest.Core.IM.IMMessages;
using IMTest.Core.IM.IMAppKeys;

namespace IMTest.EntityFramework
{
    public class IMTestDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        public virtual IDbSet<IMUser> IMUser { get; set; }

        public virtual IDbSet<IMGroup> IMGroup { get; set; }

        public virtual IDbSet<IMFriend> IMFriend { get; set; }

        public virtual IDbSet<IMGroupRelationship> IMGroupRelationship { get; set; }

        public virtual IDbSet<IMGroupMessage> IMGroupMessage { get; set; }

        public virtual IDbSet<IMMessage> IMMessage { get; set; }

        public virtual IDbSet<IMAppKey> IMAppKey { get; set; }
        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public IMTestDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in IMTestDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of IMTestDbContext since ABP automatically handles it.
         */
        public IMTestDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public IMTestDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
