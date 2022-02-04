using Configuration.Membership.BusinessObjects;
using System.Collections.Generic;

namespace Configuration.Membership.Services
{
    public interface IGroupService
    {
        void CreateUser(UserInformation user);
        (IList<UserInformation> records, int total, int totalDisplay) GetUsers(int pageIndex, int pageSize,
            string searchText, string sortText);
    }
}