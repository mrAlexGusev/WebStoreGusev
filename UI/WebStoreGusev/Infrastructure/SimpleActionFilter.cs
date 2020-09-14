using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebStoreGusev.Infrastructure
{
    public class SimpleActionFilter : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // постобработка
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // предобработка
        }
    }
}
