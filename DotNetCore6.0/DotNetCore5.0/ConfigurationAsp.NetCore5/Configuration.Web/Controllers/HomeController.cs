using Autofac;
using Configuration.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Configuration.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILifetimeScope _scope;

        public HomeController(ILogger<HomeController> logger,
            ILifetimeScope scope)
        {
            _logger = logger;
            _scope = scope;
        }

        public IActionResult Index()
        {
            var model = _scope.Resolve<CreateUserModel>();
            return View(model);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Index(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.Resolve(_scope);
                    model.UserCreate();

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "User does not create");
                }
            }
            return View(model);
        }

        public IActionResult Read()
        {
            var model = _scope.Resolve<UserDataReadModel>();
            return View(model);
        }
        //public JsonResult GetAllUsers()
        //{
        //    var ajax = new DataTablesAjaxRequestModel(Request);
        //    var model = _scope.Resolve<UserDataReadModel>();

        //    var data = model.GetAllUserList(ajax);
        //    return Json(data);
        //}


        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
