using Autofac;
using Configuration.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Configuration.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ILifetimeScope _scope;

        public UserController(ILogger<UserController> logger,
            ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Table()
        {
            var model = _scope.Resolve<TableModel>();
            return View(model);
        }

        public JsonResult GetUserData()
        {
            var dataTablesModel = new DataTablesAjaxRequestModel(Request);
            //var model = new TableModel();
            var model = _scope.Resolve<TableModel>();
            var data = model.GetUsers(dataTablesModel);
            return Json(data);
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
