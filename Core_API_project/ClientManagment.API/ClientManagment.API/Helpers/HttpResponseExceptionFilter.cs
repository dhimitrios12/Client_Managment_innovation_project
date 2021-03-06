﻿using System;
using ClientManagement.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ClientManagment.API.Helpers
{
	public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
	{
		public int Order { get; set; } = int.MaxValue - 10;
		public void OnActionExecuted(ActionExecutedContext context)
		{
			if (context.Exception is HttpResponseException exception)
			{
				context.Result = new ObjectResult(new {exception.Field, exception.Message})
				{
					StatusCode = exception.Status,
				};
				context.ExceptionHandled = true;
			}
		}

		public void OnActionExecuting(ActionExecutingContext context)
		{
			
		}
	}
}