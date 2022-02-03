using Configuration.Membership.Repositories;
using DevSkill.Data;

namespace Configuration.Membership.UnitOfWorks
{
    public interface IMembershipUnitOfWork : IUnitOfWork
    {
        IUserInformationRepository UserInformationRepository { get; }
    }
}