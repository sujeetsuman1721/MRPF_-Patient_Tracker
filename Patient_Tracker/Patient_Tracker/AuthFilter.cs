using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Patient_Tracker
{
    public class AuthFilter:IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is HttpRequestException)
            {
                context.Result = new RedirectToActionResult("Login", "Auth", null);
            }
        }
    }
}
