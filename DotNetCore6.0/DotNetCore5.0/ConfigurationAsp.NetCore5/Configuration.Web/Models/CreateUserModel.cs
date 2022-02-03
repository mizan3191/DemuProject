using Autofac;
using Configuration.Membership.BusinessObjects;
using Configuration.Membership.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Configuration.Web.Models
{
    public class CreateUserModel
    {
        
        public string Name { get; set; }
        public string Address { get; set; }
        public int number { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public IFormFile FormFile { get; set; }

        private ILifetimeScope _scope;
        private IGroupService _service;

        public CreateUserModel()
        {

        }

         public CreateUserModel(IGroupService service)
        {
            _service = service;
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
            _service = _scope.Resolve<IGroupService>();
        }

        public void UserCreate()
        {
            var user = new UserInformation()
            {
                Name = Name,
                Address = Address,
                number = number,
                CurrentDateTime = DateTime.Now,
                Gender = Gender,
               // Photo = Photo,
            };
            _service.CreateUser(user);
        }
    }
}