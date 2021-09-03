using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TMS.Common.Filter
{
    /// <summary>
    /// 自定义异常中间件（管道）
    /// </summary>
    public class CustomerExceptionMiddleware
    {
            /// <summary>
            /// 委托
            /// </summary>
            private readonly RequestDelegate _next;

            public CustomerExceptionMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {

                    context.Response.ContentType = "application/problem+json";

                    var title = "An error occured: " + ex.Message;
                    var details = ex.ToString();

                    var problem = new ProblemDetails
                    {
                        Status = 200,
                        Title = title,
                        Detail = details
                    };

                    var stream = context.Response.Body;
                    await JsonSerializer.SerializeAsync(stream, problem);
                }
            }
        }
}
