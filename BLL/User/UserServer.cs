using EFDLL;
using Models.InputModels.user;
using Models.user;
using SmartUFO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.User
{
    public class UserServer
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<users> userInfoRepository;
        private Repository<StudentInfo> studenInfoRepository;
        public UserServer()
        {
            userInfoRepository = unitOfWork.Repository<users>();
            studenInfoRepository = unitOfWork.Repository<StudentInfo>();
        }

        /// <summary>
        /// test
        /// </summary>
        /// <returns></returns>
        public List<users> GetUserAll()
        {
            return userInfoRepository.GetAll().ToList();
        }

        /// <summary>
        /// 学生管理列表
        /// </summary>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <param name="total"></param>
        /// <returns></returns>
        public List<studenUserView> GetStudenUserList(string searchQuery, int currentPage, int pageSize, out int total)
        {
            var list = from s in studenInfoRepository.GetAll()
                       join u in userInfoRepository.GetAll()
                       on s.userId equals u.id into temp
                       from tt in temp.DefaultIfEmpty()
                       where tt.identity == 1
                       select new studenUserView()
                       {
                           id = tt.id,
                           user_code = s.userCode,
                           user_mobile = tt.userMobile,
                           user_email = tt.userEmail,
                           user_name = tt.userFullName,
                           user_gender = tt.userGender,
                           user_enble_flag = tt.userEnbleFlag == true ? 1 : 0,
                           create_time = s.createTime,
                           user_login_name = tt.userLoginName,
                           user_id = tt.id,
                           is_graduation = s.isGraduation
                       };
            total = list.Count();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                list = list.Where(d => d.user_login_name.Contains(searchQuery));
            }
            list = list.OrderByDescending(d => d.create_time).Skip((currentPage - 1) * pageSize).Take(pageSize);
            return list.ToList();
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        public void UpdateStudentUser(studenUserView input)
        {
            var user = userInfoRepository.GetById(input.id);
            user.userFullName = input.user_name;
            user.userLoginName = input.user_login_name;
            user.userMobile = input.user_mobile;
            user.userEmail = input.user_email;
            user.userGender = input.user_gender;
            var student = studenInfoRepository.GetAll().Where(d => d.userId == input.id).FirstOrDefault();
            student.userCode = input.user_code;
            student.updateTime = DateTime.Now;
            student.isGraduation = input.is_graduation;
            unitOfWork.Save();
        }

        /// <summary>
        /// 查询一条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public studenUserView GetStudentUserById(Guid id)
        {
            var studenUserView = (from s in studenInfoRepository.GetAll()
                                  join u in userInfoRepository.GetAll()
                                  on s.userId equals u.id into temp
                                  from tt in temp.DefaultIfEmpty()
                                  where tt.identity == 1 && tt.id == id
                                  select new studenUserView()
                                  {
                                      id = tt.id,
                                      user_code = s.userCode,
                                      user_mobile = tt.userMobile,
                                      user_email = tt.userEmail,
                                      user_name = tt.userFullName,
                                      user_gender = tt.userGender,
                                      user_enble_flag = tt.userEnbleFlag == true ? 1 : 0,
                                      create_time = s.createTime,
                                      user_login_name = tt.userLoginName,
                                      user_id = tt.id,
                                      is_graduation = s.isGraduation
                                  }).FirstOrDefault();
            return studenUserView;
        }
    }
}
