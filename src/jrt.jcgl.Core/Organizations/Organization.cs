using Abp.Domain.Entities.Auditing;
using Abp.Organizations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jrt.jcgl.Organizations
{
    public class Organization: FullAuditedEntity<long>
    {
        public virtual long OrganizationUnitId { get; set; }

        public virtual OrganizationUnit OrganizationUnit { get; set; }

        public OrganizationType? Type { get; set; }

        public int? SerialNumber { get; set; }
    }
}
