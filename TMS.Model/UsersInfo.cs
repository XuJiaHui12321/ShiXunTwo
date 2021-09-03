using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Model.Entity.Personnel
{
    public class UsersInfo
    {
        /// <summary>
        /// 员工Id
        /// </summary>
        public int UsersInfoId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string UsersName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string UsersSex { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string UsersPhone { get; set; }

        /// <summary>
        /// 部门
        /// </summary>
        public int DepartMent_Id { get; set; }

        /// <summary>
        /// 职位
        /// </summary>
        public int Position_Id { get; set; }

        /// <summary>
        /// 院校
        /// </summary>
        public string UsersSchool { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string UsersMajor { get; set; }

        /// <summary>
        /// 家庭住址
        /// </summary>
        public string UsersAddress { get; set; }

        /// <summary>
        /// 学历
        /// </summary>
        public string UsersEducation { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        public string PolitocsStatus { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string Nation { get; set; }

        /// <summary>
        /// 籍贯
        /// </summary>
        public string NativePlace { get; set; }

        /// <summary>
        /// 婚姻
        /// </summary>
        public string Marriage { get; set; }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string UsersEmail { get; set; }

        /// <summary>
        /// 身份证号
        /// </summary>
        public string IdNamber { get; set; }

        /// <summary>
        /// 入职时间
        /// </summary>
        public DateTime StartCompanyDate { get; set; }

        /// <summary>
        /// 工龄
        /// </summary>
        public int WorkAge { get; set; }

        /// <summary>
        /// 员工类别
        /// </summary>
        public int UsersType_Id { get; set; }

        /// <summary>
        /// 状态（待入职  待试用  待转正  待离职  已离职）
        /// </summary>
        public string UsersState { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime UsersCreateDate { get; set; }
    }
}
