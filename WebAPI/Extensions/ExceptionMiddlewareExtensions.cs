/*
 * Copyright (c) 2019, TopCoder, Inc. All rights reserved.
 */
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebAPI.Exceptions;
using WebAPI.Models;

namespace WebAPI.Extensions
{
    /// <summary>
    /// The extension to handle Exceptions and convert them to corresponding status code.
    /// </summary>
    internal static class ExceptionMiddlewareExtensions
    {
        /// <summary>
        /// Configures the exception handler.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="logger">The logger.</param>
        internal static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    string message;
                    HttpStatusCode statusCode;
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        string actionName = context.Request.Method + " " + context.Request.Path;
                        bool isError = true;
                        if (contextFeature.Error is ArgumentException)
                        {
                            isError = false;
                            statusCode = HttpStatusCode.BadRequest;
                        }
                        else if (contextFeature.Error is EntityNotFoundException)
                        {
                            statusCode = HttpStatusCode.NotFound;
                        }
                        else
                        {
                            statusCode = HttpStatusCode.InternalServerError;
                        }

                        message = contextFeature.Error.Message;
                        string logMessage = $"Error when requesting '{actionName}'. Details: {contextFeature.Error}";
                        if (isError)
                        {
                            logger.LogError(logMessage);
                        }
                        else
                        {
                            logger.LogWarning(logMessage);
                        }
                    }
                    else
                    {
                        message = "Error on server.";
                        statusCode = HttpStatusCode.InternalServerError;
                    }

                    var exceptions = FlattenExceptions(contextFeature.Error);
                    var error = new ApiError
                    {
                        Message = string.Join(Environment.NewLine, exceptions.Select(x => x.Message))
                    };

                    context.Response.StatusCode = (int)statusCode;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(error, Formatting.Indented));
                });
            });
        }

        /// <summary>
        /// Flattens the exceptions.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>List of flattened exceptions.</returns>
        private static IList<Exception> FlattenExceptions(Exception exception)
        {
            var result = new List<Exception>();
            while (exception != null)
            {
                result.Add(exception);
                exception = exception.InnerException;
            }
            return result;
        }
    }
}
