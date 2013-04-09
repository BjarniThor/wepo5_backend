using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace verk5.Models
{   
    public class LoginUserRolesDTO
    {
        public class LoginUserRoles
        {
            public String Username { get; set; }
            public string[] Role { get; set; }
            public String StatusCode { get; set; }
        }
    }
    
}