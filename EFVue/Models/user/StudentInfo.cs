
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartUFO.User
{
    public class StudentInfo :BaseEntity
    {
          /// <summary>
       ///学生ID
       /// </summary>
     //  public string id { get; set; }

        /// <summary>
        /// user表id
        /// </summary>
        ///

        public StudentInfo()
        {

             if (this.id == null) {
                 this.id = Guid.NewGuid();
             }
             if (this.createTime == null) {

                 this.createTime = DateTime.Now;
             }
             if (this.updateTime == null) {

                 this.updateTime = DateTime.Now;
             }
         }
         
       public Guid userId{get;set;}
 
      
       /// <summary>
       /// 学号
       /// </summary>
        [StringLength(255)]
       public string userCode { get; set; }

       

      

       

       /// <summary>
       /// 昵称
       /// </summary>
       [StringLength(255)]
       public string userNickname { get; set; }

 

       /// <summary>
       /// 所在省份(籍贯)
       /// </summary>
        [StringLength(50)]
       public string userProvince { get; set; }

       /// <summary>
       /// 所在城市(来源地区)
       /// </summary>
       [StringLength(255)]
       public string userCity { get; set; }

       

       /// <summary>
       ///  (院校ID)
       /// </summary>
       [DefaultValue("00000000-0000-0000-0000-000000000000")]
       public Guid schoolId { get; set; }

       /// <summary>
       /// 院系 |部门id
       /// </summary>
       [DefaultValue("00000000-0000-0000-0000-000000000000")]
       public Guid userFacultyid { get; set; }

       /// <summary>
       /// 院系 |部门
       /// </summary>
       [StringLength(255)]
       public string userFaculty { get; set; }
       
       /// <summary>
       ///专业ID 
       /// </summary>
       [DefaultValue("00000000-0000-0000-0000-000000000000")]
       public Guid userSpecialtyid { get; set; }

       /// <summary>
       /// 专业
       /// </summary>
       [StringLength(255)]
       public string userSpecialty { get; set; }

       /// <summary>
       /// 班级ID
       /// </summary>
       [DefaultValue("00000000-0000-0000-0000-000000000000")]
       public Guid userClassid { get; set; }


       /// <summary>
       /// 班级名称
       /// </summary>
       [StringLength(255)]
       public string userClass { get; set; }


       /// <summary>
       /// 学生形式
       /// </summary>
       [StringLength(255)]
       public string studyForm { get; set; }

       /// <summary>
       /// 学习标记
       /// </summary>
       [StringLength(255)]
       public string studyFlag { get; set; }

       /// <summary>
       /// 层次
       /// </summary>
       [StringLength(255)]
       public string level { get; set; }

       /// <summary>
       ///学制
       /// </summary>
       [StringLength(255)]
       public string userEductional { get; set; }

       /// <summary>
       /// 入学时间
       /// </summary>
       public DateTime? userAdmission { get; set; }
       
       /// <summary>
       /// 年级
       /// </summary>
       [StringLength(255)]
       public string userGrade { get; set; }

       /// <summary>
       /// 宿舍
       /// </summary>
       [StringLength(255)]
       public string userDormitory { get; set; }

        
       
       /// <summary>
       ///邮编 
       /// </summary>
       [StringLength(255)]
       public string userZipcode { get; set; }

       /// <summary>
       /// 学生邀请码
       /// </summary>
       [StringLength(255)]
       public string userInviteCode { get; set; }

       /// <summary>
       ///  注册邀请码
       /// </summary>
       [StringLength(255)]
       public string userRegisterInviteCode { get; set; }

       /// <summary>
       /// 是否禁用
       /// </summary>
       public int userEnbleFlag { get; set; }

       /// <summary>
       /// 是否毕业
       /// </summary>
       public bool isGraduation { get; set; }
       
       /// <summary>
       /// 毕业时间
       /// </summary>
       public DateTime? graduationDate { get; set; }

       /// <summary>
       /// 创建时间
       /// </summary>
       public DateTime createTime { get; set; }

       /// <summary>
       /// 更新时间
       /// </summary>
       public DateTime updateTime { get; set; }


        
        /// <summary>
        /// 是否删除
        /// </summary>
       public bool isDel { get; set; }

       
        
       //public object GetObj(UserBase _user)
       //{
       //    return new
       //    {
       //        id=this.id,
       //      user_id = this.userId,
       //     user_login_name =_user.userLoginName,
       //     user_code =this.userCode,
       //     user_mobile =_user.userMobile,
       //                  user_email = _user.userEmail,
       //                  user_name = _user.userFullName,
       //                  user_nickname = this.userNickname,
       //                //  user_national = this.userNational,
       //              //    user_political = this.userPolitical,
       //                  user_password = _user.userPassWord,
       //                  user_province = this.userProvince,
       //                  user_city = this.userCity,
       //               //   user_birthday = this.userBirthday,
       //                  user_gender = _user.userGender,
       //                  school_id = this.schoolId,
       //                  user_facultyid = this.userFacultyid,
       //                  user_faculty = this.userFaculty,
       //                  user_specialtyid = this.userSpecialtyid,
       //                  user_specialty = this.userSpecialty,
       //                  user_classid = this.userClassid,
       //                  user_class = this.userClass,
       //                  study_form = this.studyForm,
       //                  study_flag = this.studyFlag,
       //                  level = this.level,
       //                  user_eductional = this.userEductional,
       //                  user_admission = this.userAdmission,
       //                  user_grade = this.userGrade,
       //                  user_dormitory = this.userDormitory,
       //                 // user_idcard = this.userIdcard,
       //                  user_zipcode = this.userZipcode,
       //                  user_inviteCode = this.userInviteCode,
       //                  user_register_inviteCode = this.userRegisterInviteCode,
       //                  user_enble_flag = this.userEnbleFlag,
       //                  is_graduation = this.isGraduation,
       //                  graduation_date = this.graduationDate,
       //                  create_time = this.createTime,
       //                  updateTime = this.updateTime
       //     };
           
       //}

    }
}
