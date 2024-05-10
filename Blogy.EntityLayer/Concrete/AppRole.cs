using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.EntityLayer.Concrete
{
    public class AppRole:IdentityRole<int>
    {
        public AppRole() : base()
        {
        }

        public AppRole(string roleName) : base(roleName)
        {
        }

        public string Description { get; set; }
    }
}
