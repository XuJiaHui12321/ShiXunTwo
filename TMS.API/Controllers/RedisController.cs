using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OneOf.Types;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Threading.Tasks;
using TMS.Common.Redis;
using TMS.IRepository;
using TMS.Model;

namespace TMS.API.Controllers
{
    /// <summary>
    /// redis测试
    /// </summary>
    [Route("api/redis")]
    [ApiController]
    public class RedisController : Controller
    {
        private readonly IDatabase _redis;
        public RedisController(RedisHelper client)
        {
            _redis = client.GetDatabase();
        }

        [HttpGet]
        public string Get()
        {
            // 往Redis里面存入数据
            _redis.StringSet("Name", "Tom");
            // 从Redis里面取数据
            string name = _redis.StringGet("Name");
            return name;
        }






        ////学生类
        //public class Student
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public string Pwd { get; set; }
        //}




        ////redis key
        //int REDISKEY = 1;
        ////得到Redis缓存数据
        //[HttpGet]
        //public string GetRedis(EnumType.RedisType redisType)
        //{
        //    //集合模拟数据
        //    List<Student> students = new List<Student>()
        //    {
        //        new Student { Id = 1, Name = "王", Pwd = "111" },
        //        new Student { Id = 2, Name = "王12", Pwd = "222" },
        //        new Student { Id = 3, Name = "王23", Pwd = "333" }
        //    };
        //    //模拟单个数据
        //    Student student = new Student()
        //    {
        //        Id = 1,
        //        Name = "李四",
        //        Pwd = "1231456"
        //    };
        //    //_redis.KeyExpire("list",DateTime.Now.AddSeconds(20));//设置过期时间,以秒为单位
        //    //_redis.KeyDelete("name");//删除缓存

        //    //将RedisKey加一
        //    REDISKEY += 1;
        //    //添加Redis缓存
        //    AddRedis(redisType, REDISKEY.ToString(), JsonConvert.SerializeObject(students));

        //    //添加Redis缓存
        //    AddRedis(redisType = (EnumType.RedisType)4, student.Id.ToString(), JsonConvert.SerializeObject(student));


        //    //获取枚举类型对应的值
        //    //string redisKey = Enum.GetName(typeof(EnumType.RedisType), redisType);
        //    string redisKey = redisType.ToString();
        //    //拼接Redis的Key名
        //    redisKey += ("_" + student.Id);

        //    //判断该key是否存在
        //    //_redis.CacheRedis.KeyExists(redisKey);

        //    //返回key所存储的数据类型
        //    //var redisKeyType = _redis.CacheRedis.KeyType(redisKey);

        //    //根据RedisKey读取Redis缓存数据
        //    var studentRedis = _redis.CacheRedis.StringGet(redisKey);

        //    //判断是否从Redis中取到数据
        //    if (studentRedis == "")
        //    {
        //        //Redis没有，在数据库中查找
        //    }
        //    try
        //    {
        //        //转换为集合
        //        List<Student> listStudent = JsonConvert.DeserializeObject<List<Student>>(studentRedis);
        //        return JsonConvert.SerializeObject(listStudent);

        //    }
        //    catch (Exception)
        //    {
        //        //转换为对象
        //        Student singleStudent = JsonConvert.DeserializeObject<Student>(studentRedis);
        //        return JsonConvert.SerializeObject(singleStudent);

        //    }

        //}

        //public void AddRedis(EnumType.RedisType redisType, string key, string value)
        //{
        //    //获取枚举类型对应的值
        //    //string redisKey = Enum.GetName(typeof(RedisType), redisType);
        //    string redisKey = redisType.ToString();
        //    //拼接Redis的Key名
        //    redisKey += ("_" + key);

        //    //写入Redis缓存
        //    _redis.CacheRedis.StringSet(redisKey, value);

        //}



    }
}
