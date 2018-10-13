using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogezyApplication.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Comments = new HashSet<Comment>();
        }

        public ICollection<Comment> Comments { get; set; }
    }
}
