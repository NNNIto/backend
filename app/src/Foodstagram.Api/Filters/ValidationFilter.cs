
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Foodstagram.Api.Filters;

public sealed class ValidationFilter : IActionFilter
{
	public void OnActionExecuting(ActionExecutingContext context)
	{
		if (!context.ModelState.IsValid)
		{
			var problemDetails = new ValidationProblemDetails(context.ModelState)
			{
				Status = StatusCodes.Status400BadRequest,
				Title = "Validation error"
			};

			context.Result = new BadRequestObjectResult(problemDetails);
		}
	}

	public void OnActionExecuted(ActionExecutedContext context)
	{
		
	}
}
