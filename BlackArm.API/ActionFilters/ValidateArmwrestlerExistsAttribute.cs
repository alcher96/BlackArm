using BlackArm.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlackArm.API.ActionFilters;

public class ValidateArmwrestlerExistsAttribute : IAsyncActionFilter
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public ValidateArmwrestlerExistsAttribute(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
    
   
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var trackChanges = context.HttpContext.Request.Method.Equals("PUT");
        
        var id = (Guid)context.ActionArguments["id"];
        
        var armwrestler = await _repository.ArmWrestler.GetWrestlerAsync(id, trackChanges);
        if (armwrestler == null)
        {
            _logger.LogInfo($"ArmWrestler {id} not found");
            context.Result = new NotFoundResult();
        }
        else
        {
            context.HttpContext.Items.Add("ArmWrestler", armwrestler);
            await next();
        }
    }
}