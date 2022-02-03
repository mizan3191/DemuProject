using Configuration.Membership.Contexts;
using Configuration.Membership.Entities;
using DevSkill.Data;
using System;

namespace Configuration.Membership.Repositories
{
    public interface IUserInformationRepository : IRepository<UserInformation, Guid, MembershipDbContext>
    {
    }
}