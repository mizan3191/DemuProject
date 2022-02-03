using Microsoft.AspNetCore.Identity;
using System;

namespace Configuration.Membership.Entities
{
    public class UserToken : IdentityUserToken<Guid>
    {
    }
}