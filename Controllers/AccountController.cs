using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ys_j.Models;

namespace ys_j.Controllers
{
    [AllowAnonymous, Route("account")]
    public class AccountController : Controller
    {
        [Route("google-login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse", "Account") };
            return Challenge(properties, GoogleDefaults.AuthenticationScheme);
        }

        [Route("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var GoogleUserDAO = new GoogleUserDAO();
            var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var claimValues = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => claim.Value).ToList();
            var googleUser = new GoogleUser
            {
                uId = claimValues[0],
                fullName = claimValues[1],
                firstName = claimValues[2],
                lastName = claimValues[3],
                email = claimValues[4],
                date = DateTime.Now
            };

            if (new GoogleUserDAO().GetByUId(googleUser.uId) == null)
            {
                GoogleUserDAO.Insert(googleUser);
            }

            Response.Cookies.Append("googleUId", googleUser.uId);



            return RedirectToAction("Index", "SideProjects");

        }

    }
}
