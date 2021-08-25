using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Portal.Domain.Core.Auth
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}