using System;

namespace Configuration.Membership.BusinessObjects
{
    public class UserInformation
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int number { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
}