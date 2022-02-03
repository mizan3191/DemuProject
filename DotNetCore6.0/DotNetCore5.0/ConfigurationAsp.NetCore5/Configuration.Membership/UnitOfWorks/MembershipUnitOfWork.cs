using Configuration.Membership.Contexts;
using Configuration.Membership.Repositories;
using DevSkill.Data;
using Microsoft.EntityFrameworkCore;

namespace Configuration.Membership.UnitOfWorks
{
    public class MembershipUnitOfWork : UnitOfWork, IMembershipUnitOfWork
    {
        public IUserInformationRepository UserInformationRepository { get; private set; }

        public MembershipUnitOfWork(IMembershipDbContext context,
            IUserInformationRepository informationRepository
            ) : base((DbContext)context)
        {
            UserInformationRepository = informationRepository;
        }
    }
}