using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LogisticsManagementSystem_IDAL;
using LogisticsManagementSystem_MODEL;
using Microsoft.AspNetCore.Authorization;

namespace LogisticsManagementSystem_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        IFunctions functions;
        public FunctionController(IFunctions _functions)
        {
            functions = _functions;
        }
        [HttpGet]

        [Authorize]
        [Route("HomeMenu")]
        public ActionResult HomeMenu(int UserId)
        {
            List<FunctionModel> listFunction= functions.GetFunctionModels(UserId);
            return Ok(listFunction);
        }
        [HttpGet]
        [Authorize]
        public ActionResult ErFunctionModels(int FunctionErId)
        {
            List<FunctionModel> listFunction = functions.ErFunctionModels(FunctionErId);
            return Ok(listFunction);
        }
    }
}
