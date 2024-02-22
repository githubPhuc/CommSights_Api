using CommSights_Api.Database.ModelCommSights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Core.Interfaces
{
    public interface IMembershipPermissionRepository
    {
        public IEnumerable<MembershipPermission> GetByMembershipIDAndCodeToAsNoTracking(int membershipID, string code);
    }
}
