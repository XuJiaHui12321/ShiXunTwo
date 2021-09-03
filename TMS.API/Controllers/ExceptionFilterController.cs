using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Model.Entity;

namespace TMS.API.Controllers
{
    /// <summary>
    /// 测试异常处理
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ExceptionFilterController : ControllerBase
    {
        [HttpGet]
        public async Task<ResultModel<int>> Get()
        {
            int i = 0;
            int k = 10;
            // 这里会发生异常
            int j = await Task.Run<int>(() =>
            {
                return k / i;
            });


            return new ResultModel<int>()
            {
                ResultCode = 1,
                ResultMsg = "Success",
                ResultData = j
            };
        }
    }
}
