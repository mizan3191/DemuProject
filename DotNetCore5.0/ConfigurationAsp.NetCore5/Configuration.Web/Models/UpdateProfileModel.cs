using Autofac;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Configuration.Web.Models
{
    public class UpdateProfileModel
    {
        [MaxLength(100, ErrorMessage = "Name should be less than 100 characters")]
        public string FullName { get; set; }
        [MaxLength(250, ErrorMessage = "Address should be less than 250 characters")]
        public string Address { get; set; }
        [MaxLength(15, ErrorMessage = "Blood Group should be less than 15 characters")]
        public string BloodGroup { get; set; }
        [MaxLength(15, ErrorMessage = "Phone Number should be less than 15 characters")]
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
        public IFormFile FormFile { get; set; }
        private ILifetimeScope _scope;

        public UpdateProfileModel()
        {
            
        }

        public void Resolve(ILifetimeScope scope)
        {
            _scope = scope;
        }
    }
}