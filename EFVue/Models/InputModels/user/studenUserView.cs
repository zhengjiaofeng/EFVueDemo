using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.InputModels.user
{
    public class studenUserView:BaseEntity
    {
        /// <summary>
        ///学生ID
        /// </summary>
        //   public string id { get; set; }


        public Guid user_id { get; set; }

        /// <summary>
        ///学生用户名
        /// </summary>
        public string user_login_name { get; set; }

        /// <summary>
        /// 学号
        /// </summary>
        public string user_code { get; set; }

        /// <summary>
        /// 手机
        /// </summary>
        public string user_mobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string user_email { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string user_name { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string user_nickname { get; set; }

        /// <summary>
        /// 民族
        /// </summary>
        public string user_national { get; set; }

        /// <summary>
        /// 政治面貌
        /// </summary>
        public string user_political { get; set; }

        /// <summary>
        /// 登录密码
        /// </summary>
        public string user_password { get; set; }

        /// <summary>
        /// 所在省份(籍贯)
        /// </summary>
        public string user_province { get; set; }

        /// <summary>
        /// 所在城市(来源地区)
        /// </summary>
        public string user_city { get; set; }

        /// <summary>
        /// 生日
        /// </summary>
        public DateTime? user_birthday { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string user_gender { get; set; }

        /// <summary>
        /// 组织架构(院校ID)
        /// </summary>
        public string school_id { get; set; }

        /// <summary>
        /// 院系 |部门id
        /// </summary>
        public string user_facultyid { get; set; }

        /// <summary>
        /// 院系 |部门
        /// </summary>
        public string user_faculty { get; set; }

        /// <summary>
        ///专业ID 
        /// </summary>
        public string user_specialtyid { get; set; }

        /// <summary>
        /// 专业
        /// </summary>
        public string user_specialty { get; set; }

        /// <summary>
        /// 班级ID
        /// </summary>
        public string user_classid { get; set; }


        /// <summary>
        /// 班级名称
        /// </summary>
        public string user_class { get; set; }


        /// <summary>
        /// 学生形式
        /// </summary>
        public string study_form { get; set; }

        /// <summary>
        /// 学习标记
        /// </summary>
        public string study_flag { get; set; }

        /// <summary>
        /// 层次
        /// </summary>
        public string level { get; set; }

        /// <summary>
        ///学制
        /// </summary>
        public string user_eductional { get; set; }

        /// <summary>
        /// 入学时间
        /// </summary>
        public DateTime? user_admission { get; set; }

        /// <summary>
        /// 年级
        /// </summary>
        public string user_grade { get; set; }

        /// <summary>
        /// 宿舍
        /// </summary>
        public string user_dormitory { get; set; }

        /// <summary>
        /// 身份证号码
        /// </summary>
        public string user_idcard { get; set; }

        /// <summary>
        ///邮编 
        /// </summary>
        public string user_zipcode { get; set; }

        /// <summary>
        /// 学生邀请码
        /// </summary>
        public string user_inviteCode { get; set; }

        /// <summary>
        ///  注册邀请码
        /// </summary>
        public string user_register_inviteCode { get; set; }

        /// <summary>
        /// 是否禁用
        /// </summary>
        public int user_enble_flag { get; set; }

        /// <summary>
        /// 是否毕业
        /// </summary>
        public bool is_graduation { get; set; }

        /// <summary>
        /// 毕业时间
        /// </summary>
        public DateTime? graduation_date { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? create_time { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? updateTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        public bool isDel { get; set; }

        /// <summary>
        /// 小头像
        /// </summary>
        public string smallAvatar { get; set; }

        /// <summary>
        /// 中头像
        /// </summary>
        public string mediumAvatar { get; set; }

        /// <summary>
        /// 大头像
        /// </summary>
        public string largeAvatar { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string about { get; set; }

        public string signature { get; set; }


        /// <summary>
        /// 未读私信条数
        /// </summary>
        public int? newMessageNum { get; set; }


        /// <summary>
        /// 未读消息数目
        /// </summary>
        public int? newNotificationNum { get; set; }

        /// <summary>
        /// 实名认证状态
        /// </summary>
        public string approvalStatus { get; set; }

        /// <summary>
        /// 登录ip
        /// </summary>
        public string loginIp { get; set; }

        /// <summary>
        /// 登录时间
        /// </summary>
        public DateTime? loginTime { get; set; }

        /// <summary>
        /// 部门(组织架构Id)
        /// </summary>
        public string departmentId { get; set; }

        public string department { get; set; }

        public List<string> departmentIdList { get; set; }
        public List<string> departmentNameList { get; set; }


    }
}
