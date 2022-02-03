using Configuration.Membership.Contexts;
using Configuration.Membership.Entities;
using DevSkill.Data;
using System;

namespace Configuration.Membership.Repositories
{
    public class UserInformationRepository : Repository<UserInformation, Guid, MembershipDbContext>, IUserInformationRepository
    {
        public UserInformationRepository(IMembershipDbContext context)
            : base((MembershipDbContext)context)
        {
        }
    }
}