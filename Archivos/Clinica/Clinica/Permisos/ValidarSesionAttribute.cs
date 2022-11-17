using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Clinica.Permisos
{
	public class ValidarSesionAttribute : ActionFilterAttribute

	{

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (HttpContext.Current.Session["usuario"] == null)
            {

                filterContext.Result = new RedirectResult("~/Acceso/Login");
            }

            base.OnActionExecuting(filterContext);
        }




    }
}
