using Configuration.Membership.UnitOfWorks;

namespace Configuration.Membership.Services
{
    public class GroupService : IGroupService
    {
        private readonly IMembershipUnitOfWork _unitOfWork;

        public GroupService(IMembershipUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}