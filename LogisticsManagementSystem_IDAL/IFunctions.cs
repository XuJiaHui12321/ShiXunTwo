using System;
using System.Collections.Generic;
using LogisticsManagementSystem_MODEL;

namespace LogisticsManagementSystem_IDAL
{
    public interface IFunctions
    {
        List<FunctionModel> GetFunctionModels();

        /// <summary>
        /// 根据用户查询用户的菜单权限
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        List<FunctionModel> GetFunctionModels(int userId);
        List<FunctionModel> ErFunctionModels(int FunctionErId);
    }
}
