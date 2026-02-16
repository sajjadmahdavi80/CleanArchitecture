using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviors;

public class ExceptionHandlingBehavior<TRequest, TResponse>(ILogger logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{


    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        try
        {
            return await next(cancellationToken);
        }
        catch (Exception ex)
        {
            string requestName = typeof(TRequest).Name;

            logger.LogError(
                ex,
                "Unhandled exception for request {RequestName} {@Request}",
                requestName,
                request);

            throw ex;
        }
    }
}
