using Microsoft.AspNetCore.Mvc.Filters;

namespace BookMyShow.Filters
{
    public class CustomValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Before Filter");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("After Filter");
        }
    }
}
