using AppShared.Library.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppShared.Library.Extensions
{
    public static class CustomValidationResponse
    {

        public static void UserCustomValidationResponse(this IServiceCollection service)
        {
            service.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values
                    .Where(x => x.Errors.Count > 0)
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage);

                    ErrorDTO errorDTO = new ErrorDTO(errors.ToList(), true);

                    var response = Response<NoContentResult>.Fail(errorDTO, 400);

                    return new BadRequestObjectResult(response);
                };
            });
        }
    }
}
