using Autofac;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Configuration.Web.Models
{
    public class EditUserModel
    {
        [MaxLength(100, ErrorMessage = "Name should be less than 100 characters")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Address should be less than 250 characters")]
        public string Address { get; set; }

        [MaxLength(15, ErrorMessage = "Phone Number should be less than 15 characters")]
        public string number { get; set; }

        public string Gender { get; set; }
        public string Photo { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public IFormFile FormFile { get; set; }
        private ILifetimeScope _scope;

        public EditUserModel()
        {

        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}