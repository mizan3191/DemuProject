using Autofac;
using Configuration.Membership.Services;
using Configuration.Web.Controllers;
using System.Linq;

namespace Configuration.Web.Models
{
    public class TableModel
    {
        private ILifetimeScope _scope;
        private IGroupService _service;

        public TableModel(IGroupService service)
        {
            _service = service;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IGroupService>();
        }

        internal object GetUsers(DataTablesAjaxRequestModel tableModel)
        {
            var data = _service.GetUsers(
                tableModel.PageIndex,
                tableModel.PageSize,
                tableModel.SearchText,
                tableModel.GetSortText(new string[] { "Name", "Address", "number", "CurrentDateTime", "Gender" }));

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
                                record.Gender,
                                record.Id.ToString()
                        }
                    ).ToArray()
            };
        }
    }
}
