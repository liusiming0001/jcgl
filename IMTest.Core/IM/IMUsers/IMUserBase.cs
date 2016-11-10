using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;
namespace IMTest.IM.IMUsers
{
    public class IMUserBase : IEntity<long>
    {
        private long id = 0;
        public long test = 0;
        public long Id
        {
            get
            {
                return test;
            }

            set
            {
                id = value;
            }
        }

        public bool IsTransient()
        {
            throw new NotImplementedException();
        }
    }
}
