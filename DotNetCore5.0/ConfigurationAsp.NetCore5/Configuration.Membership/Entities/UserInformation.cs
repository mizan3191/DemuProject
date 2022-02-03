using DevSkill.Data;
using Microsoft.AspNetCore.Http;
using System;

namespace Configuration.Membership.Entities
{
    public class UserInformation : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public int number { get; set; }
        public string Photo { get; set; }
        public IFormFile FormFile { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
}