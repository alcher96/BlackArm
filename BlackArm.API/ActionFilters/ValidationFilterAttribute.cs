using BlackArm.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlackArm.API.ActionFilters;

public class ValidationFilterAttribute : IActionFilter
{
    private readonly ILoggerManager _logger;

    public ValidationFilterAttribute( ILoggerManager logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        var action = context.RouteData.Values["action"];
        var controller = context.RouteData.Values["controller"];
        var param = context.ActionArguments
            .SingleOrDefault(x => x.Value.ToString().Contains("Dto")).Value;

        if (param == null)
        {
            _logger.LogError($"Object sent from client null. Controller: {controller}, Action: {action}");
            context.Result = new BadRequestObjectResult($"Object sent from client null. Controller: {controller}, Action: {action}");
            return;
        }

        if (!context.ModelState.IsValid)
        {
            _logger.LogError($"Invalid Model state. Controller: {controller}, Action: {action}");
            context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        throw new NotImplementedException();
    }
}