using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using Verkvaki.Helpers;
using WebMatrix.WebData;
using verk5.Models;
using verk5.Filters;
using System.Web.Http.Controllers;

namespace verk5.Controllers
{

    public class LoginController : ApiController
    {
        private verk5Context db = new verk5Context();

        [HttpPost]
        [AllowCrossSiteJson]
        ///Shitty fix for user authentication
        public LoginUserRolesDTO.LoginUserRoles PostLogin(LoginUserRoles lur)
        {
            if (WebSecurity.Login(lur.Username, lur.Password))
            {
                return new LoginUserRolesDTO.LoginUserRoles()
                    {
                        Username = lur.Username,
                        Role = Roles.GetRolesForUser(lur.Username),
                        StatusCode = HttpStatusCode.OK.ToString()
                    };
            }
            else
            {
                return new LoginUserRolesDTO.LoginUserRoles()
                {
                    Username = null,
                    Role = null,
                    StatusCode = HttpStatusCode.NotFound.ToString()
                };
            }

        }
    }
}
