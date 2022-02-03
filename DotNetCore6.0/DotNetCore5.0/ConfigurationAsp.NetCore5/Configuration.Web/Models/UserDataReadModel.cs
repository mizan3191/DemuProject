using Autofac;
using Configuration.Membership.Services;
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

        internal object GetAllUserList(DataTablesAjaxRequestModel ajax)
        {
            var data = _service.GetAllGroup(
               ajax.PageIndex,
               ajax.PageSize,
               ajax.SearchText,
               ajax.GetSortText(new string[] { "Name", "Address", "CreateDate", "number" })
               );

            return new
            {
                recordsTotal = data.total,
                recordsFiltered = data.totalDisplay,
                data = (from record in data.records
                        select new string[]
                        {
                            record.Name,
                            record.Address,
                            record.number.ToString(),
                            record.CurrentDateTime.ToString(),
                            record.Id.ToString(),
                        }).ToArray()
            };
        }
    }
}