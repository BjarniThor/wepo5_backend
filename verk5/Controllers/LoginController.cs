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
using WebMatrix.WebData;
using verk5.Models;

namespace verk5.Controllers
{
    
    public class LoginController : ApiController
    {
        private verk5Context db = new verk5Context();

        [HttpPost]
        ///Shitty fix for user authentication
        public LoginUserRolesDTO.LoginUserRoles PostLogin(LoginUserRoles lur)
        {
            if (WebSecurity.Login(lur.Username, lur.Password))
            {
                return new LoginUserRolesDTO.LoginUserRoles()
                    {
                        Username = lur.Username,
                        Role = Roles.GetRolesForUser(lur.Username)
                    };
            }
            else
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.BadRequest));
            }

        }
    }
}
