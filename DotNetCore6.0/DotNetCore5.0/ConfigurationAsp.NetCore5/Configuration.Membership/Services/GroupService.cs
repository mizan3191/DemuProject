using Configuration.Membership.BusinessObjects;
using Configuration.Membership.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Configuration.Membership.Services
{
    public class GroupService : IGroupService
    {
        private readonly IMembershipUnitOfWork _unitOfWork;

        public GroupService(IMembershipUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateUser(UserInformation user)
        {
            if (user == null)
                throw new InvalidOperationException();

            if (user.Name == null)
                throw new InvalidOperationException();

            _unitOfWork.UserInformationRepository.Add(
                new Entities.UserInformation { 
                    Name = user.Name,
                    Address = user.Address,
                    number = user.number,
                    CurrentDateTime = user.CurrentDateTime,
                    Gender = user.Gender,
                    //Photo = user.Photo,
                });

            _unitOfWork.Save();
        }

        public (IList<UserInformation> records, int total, int totalDisplay) GetAllGroup(
            int pageIndex, int pageSize, string searchText, string sortText)
        {
            var createData = _unitOfWork.UserInformationRepository.GetDynamic(
               string.IsNullOrWhiteSpace(searchText) ? null : x => x.Name.Contains(searchText),
               sortText, null, pageIndex, pageSize);

            var resultData = (from create in createData.data
                              select new UserInformation
                              {
                                  Name = create.Name,
                                  number = create.number,
                                  Address = create.Address,
                                  CurrentDateTime=create.CurrentDateTime,
                                  Id = create.Id
                              }).ToList();

            return (resultData, createData.total, createData.totalDisplay);
        }
    }
}