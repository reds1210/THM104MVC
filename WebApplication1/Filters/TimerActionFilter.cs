using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace WebApplication1.Filters
{
    public class TimerActionFilter :IActionFilter
    {
        private readonly ILogger<TimerActionFilter> _logger;
        private Stopwatch _stopwatch=null;
        public TimerActionFilter(ILogger<TimerActionFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();
            var controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            var actionName = context.ActionDescriptor.DisplayName;
            _logger.LogCritical($"caller:{controllerName}-{actionName}, {_stopwatch.ElapsedMilliseconds}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch = Stopwatch.StartNew();
            var controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            var actionName = context.ActionDescriptor.DisplayName;
            _logger.LogCritical($"caller:{controllerName}-{actionName}, Start");
        }
    }
}
