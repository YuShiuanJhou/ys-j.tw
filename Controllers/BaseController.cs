using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ys_j.Models;

namespace ys_j.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Request.Cookies["googleUId"] != null)
            {
                var googleUser = new GoogleUserDAO().GetByUId(HttpContext.Request.Cookies["googleUId"]);
                ViewBag.googleUser = googleUser;
            }
            base.OnActionExecuting(filterContext);
        }


    }
}
