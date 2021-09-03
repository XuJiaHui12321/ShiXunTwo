using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Common.Filter
{
    /// <summary>
    /// 静态类
    /// </summary>
    public static class ExceptionMiddlewareExtension
    {

            /// <summary>
            /// 静态方法
            /// </summary>
            /// <param name="app">要进行扩展的类型</param>
            public static void UseExceptionMiddleware(this IApplicationBuilder app)
            {
                app.UseMiddleware(typeof(CustomerExceptionMiddleware));
            }
        }
}
