using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace QuickList.ActionFilters
// 9* create our own custom Action Filter. In order to create a custom Action Filter, we need to create a class that inherits from one of the following: IActionFilter.  We will then be forced to implement two methods: OneActionExecuting and OnActionExecuted. pg 14
{
    public class GlobalRouting : IActionFilter
    {
        private readonly ClaimsPrincipal _claimsPrincipal;
        public GlobalRouting(ClaimsPrincipal claimsPrincipal)
        {
            _claimsPrincipal = claimsPrincipal;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controller = context.RouteData.Values["controller"];
            if (controller.Equals("Home"))
            {
                if (_claimsPrincipal.IsInRole("Shopper"))
                {
                    context.Result = new RedirectToActionResult("Index",
                    "Shoppers", null);
                }
                //else if (_claimsPrincipal.IsInRole("Employee"))
                //{
                //    context.Result = new RedirectToActionResult("Index",
                //    "Employees", null);
                //}
            }
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }

}
