﻿using AppShared.Library.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppShared.Library.Extensions
{
    public static class CustomExceptionHandle
    {
        public static void UseCutomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.StatusCode = 500;
                    context.Response.ContentType = "application/json";

                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (errorFeature != null)
                    {
                        var ex = errorFeature.Error;

                        ErrorDTO errorDTO = null;

                        if (ex is CustomException)
                        {
                            errorDTO = new ErrorDTO(ex.Message, true);
                        }
                        else
                        {
                            errorDTO = new ErrorDTO(ex.Message, false);
                        }

                        var response = Response<NoDataDTO>.Fail(errorDTO, 500);

                        await context.Response
                        .WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });

        }
    }
}
