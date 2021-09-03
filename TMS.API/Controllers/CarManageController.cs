using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.IRepository;
using TMS.Model.Entity.BaseInfo;
using Microsoft.AspNetCore.Authorization;//JWT

namespace TMS.API.Controllers
{
    /// <summary>
    /// 车辆管理
    /// </summary>
    [ApiController]
   // [Authorize]
    [Route("CarManageApi")]
    public class CarManageController : Controller
    {
        private ILogger<CarManageController> _logger;//日志
        private ICarManageRepository dal;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dal"></param>
        public CarManageController(ILogger<CarManageController> logger, ICarManageRepository _dal)
        {
            _logger = logger;//日志
            dal = _dal;
        }

        /// <summary>
        /// 显示列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CarManageIndex")]
        public IActionResult CarManageIndex()
        {
            try
            {
                List<CarManage> list = dal.CarShow();
                _logger.LogInformation("======{p1}======{p2}======", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:fff 成功"), list.Count.ToString());
                return Json(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "##{p1}## CarManageController-CarManageIndex() Exception", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss 报错啦！！！"));
                return Json("{'result':'error'}");
                throw;
            }
            
        }

        /// <summary>
        /// 砍价商品信息
        /// </summary>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">每页几条数据</param>
        /// <returns></returns>
        [Route("Proc_Page")]
        [HttpGet]
        public IActionResult Proc_Page(int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                int totalCount;
                List<CarManage> car = dal.GeCarManagePage(pageIndex, pageSize, out totalCount);

                ////实例化返回数据
                //ResultDataModel<CarManage> result = new ResultDataModel<CarManage>();
                //result.code = true;
                //result.data = bargainirgs;//数据集
                return Json(car);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }




        /// <summary>
        /// 新增汽车
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddCarManage")]
        public IActionResult AddCarManage(CarManage car)
        {
            try
            {
                bool result = dal.AddCarManage(car);
                return Json(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 删除操作员
        /// </summary>
        /// <param name="CarManageId"></param>
        /// <returns></returns>
        [Route("CarDel")]
        [HttpPost]
        public IActionResult CarDel(int CarManageId)
        {
            try
            {
                bool result = dal.DeleteCar(CarManageId);
                return Json(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="CarManageId"></param>
        /// <returns></returns>
        [Route("EditCar")]
        [HttpPost]
        public IActionResult EditCar(int CarManageId)
        {
            try
            {
                CarManage result = dal.EditCarManage(CarManageId);
                return Json(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="car"></param>
        /// <returns></returns>
        [Route("UpdateCarManage")]
        [HttpPost]
        public IActionResult UpdateCarManage(CarManage car)
        {
            try
            {
                bool result = dal.UpdateCar(car);
                return Ok(result);
            }
            catch (Exception)
            {
                return Ok("数据错误");
            }
        }





    }
}
