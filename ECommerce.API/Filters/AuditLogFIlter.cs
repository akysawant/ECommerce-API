using Microsoft.AspNetCore.Mvc.Filters;

namespace ECommerce.API.Filters
{
    public class AuditLogFIlter : IActionFilter
    {
        private readonly ILogger<AuditLogFIlter> _logger;

        public AuditLogFIlter(ILogger<AuditLogFIlter> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation(
                "Action Finished : {ActionName}",
                context.ActionDescriptor.DisplayName);
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation(
                "Action starting : {ActionName}",
                context.ActionDescriptor.DisplayName);
        }
    }
}
