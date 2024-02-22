using CommSights_Api.Core.Interfaces;
using CommSights_Api.Data.ModelCommSights;
using CommSights_Api.Database.ModelCommSights;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Abstractions.Services
{
    public class MembershipPermissionRepositoryServices: IMembershipPermissionRepository
    {
        private readonly CommSightsContext _context;
        public MembershipPermissionRepositoryServices(CommSightsContext context)
        {
            this._context = context;
        }
        public IEnumerable<MembershipPermission> GetByMembershipIDAndCodeToAsNoTracking(int membershipID, string code)
        => _context.MembershipPermissions.Where(item => item.MembershipId == membershipID && item.Code.Equals(code)).OrderBy(item => item.DateUpdated).AsNoTracking();
    }
}
