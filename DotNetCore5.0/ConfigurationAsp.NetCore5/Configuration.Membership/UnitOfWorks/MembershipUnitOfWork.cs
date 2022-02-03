using Configuration.Membership.Contexts;
using Configuration.Membership.Repositories;
using Configuration.Membership.UnitOfWorks;
using DevSkill.Data;
using Microsoft.EntityFrameworkCore;

namespace Configuration.Membership.UnitOfWorks
{
    public class MembershipUnitOfWork : UnitOfWork, IMembershipUnitOfWork
    {
        public IUserInformationRepository UserInformationRepository { get; private set; }

        public MembershipUnitOfWork(IMembershipDbContext context,
            IUserInformationRepository groupRepository
            ) : base((DbContext)context)
        {
            UserInformationRepository = groupRepository;
        }
    }
}