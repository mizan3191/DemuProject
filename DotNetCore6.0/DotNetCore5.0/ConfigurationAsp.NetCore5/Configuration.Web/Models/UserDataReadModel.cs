using Autofac;
using Configuration.Membership.Services;
using Configuration.Web.Controllers;
using System;
using System.Linq;

namespace Configuration.Web.Models
{
    public class UserDataReadModel
    {
        private ILifetimeScope _scope;
        private IGroupService _service;

        public UserDataReadModel(IGroupService service)
        {
            _service = service;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IGroupService>();
        }

        //internal object GetAllUserList(DataTablesAjaxRequestModel ajax)
        //{
        //    var data = _service.GetAllUser(
        //       ajax.PageIndex,
        //       ajax.PageSize,
        //       ajax.SearchText,
        //       ajax.GetSortText(new string[] { "Name", "Address", "number", "CurrentDateTime", "Gender" }));

        //    return new
        //    {
        //        recordsTotal = data.total,
        //        recordsFiltered = data.totalDisplay,
        //        data = (from record in data.records
        //                select new string[]
        //                {
        //                        record.Name,
        //                        record.Address,
        //                        record.number.ToString(),
        //                        record.CurrentDateTime.ToString(),
        //                        record.Gender,
        //                        record.Id.ToString()
        //                }
        //            ).ToArray()
        //    };
        //}
    }
}