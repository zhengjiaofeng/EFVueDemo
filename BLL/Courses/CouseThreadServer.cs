using BLL.Commont;
using EFDLL;
using Models.courses;
using Models.InputModels.courses;
using Models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Courses
{
    public class CouseThreadServer
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<CourseThread> courseThreadRepository;
        private Repository<users> usersRepository;
        private Repository<Course> courseRepository;
        private Repository<CourseThreadPost> courseThreadPost;
        public CouseThreadServer()
        {
            courseThreadRepository = unitOfWork.Repository<CourseThread>();
            usersRepository = unitOfWork.Repository<users>();
            courseRepository = unitOfWork.Repository<Course>();
            courseThreadPost = unitOfWork.Repository<CourseThreadPost>();
        }

        /// <summary>
        /// 在线答疑列表
        /// </summary>
        /// <param name="type"></param>
        /// <param name="total"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<CourseThreadEntity> GetCourseThreadList(string type, ref int total, int page = 1, int pageSize = 20)
        {
            List<CourseThreadEntity> list = new List<CourseThreadEntity>();
            var data = from ct in courseThreadRepository.GetAll()
                       join u in usersRepository.GetAll() on ct.userId equals u.id
                       join c in courseRepository.GetAll() on ct.courseId equals c.id into tem2
                       from t2 in tem2.DefaultIfEmpty()
                       where ct.type != "note"
                       orderby ct.createTime descending
                       select new
                       {
                           u.userLoginName,
                           ct.courseId,
                           ct.userId,
                           CourseName = t2.title,
                           u.userFullName,
                           ct.createTime,
                           Title = ct.title,
                           ThreadId = ct.id,
                           UserNameHeadImgUrl = u.smallAvatar,
                           PostNum = ct.replyNum,
                           LastPostTime = ct.lastReplyTime,
                           Type = ct.type,
                           isShowQuestion = t2 == null ? false : t2.isShowQuestion
                       };

            if (!string.IsNullOrEmpty(type) && type != "all")
            {
                data = data.Where(d => d.Type == type);
            }
            total = data.Count();
            var result = data.Skip((page - 1) * 20).Take(pageSize).ToList();
            foreach (var item in result)
            {
                CourseThreadEntity obj = new CourseThreadEntity();
                obj.userFullName = item.userLoginName;
                obj.CourseId = item.courseId.ToString();
                obj.UserId = item.userId.ToString();
                obj.CourseName = item.CourseName;
                obj.UserName = item.userFullName;
                obj.CreateTime = item.createTime;
                obj.Title = item.Title;
                obj.ThreadId = item.ThreadId.ToString();
                obj.UserNameHeadImgUrl = item.UserNameHeadImgUrl;
                obj.PostNum = item.PostNum;
                obj.LastPostTime = item.LastPostTime;
                obj.Type = item.Type;
                obj.IsShowQuestion = item.isShowQuestion;

                obj.CreateTimeStr = GetTimtSetDay(obj.CreateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                obj.LastPostTimeStr = GetRelativeTime(obj.LastPostTime.ToString("yyyy-MM-dd HH:mm:ss"));
                //var ctp = userData.FirstOrDefault(d => d.threadId == item.ThreadId);
                //if (ctp == null || string.IsNullOrWhiteSpace(ctp.userLoginName))
                //{
                //    obj.PostUserName = string.Empty;
                //}
                //else
                //{
                //    obj.PostUserName = string.IsNullOrWhiteSpace(ctp.userFullName) ? ctp.userLoginName : ctp.userFullName;
                //}
                list.Add(obj);
            }

            return list;
        }

        /// <summary>
        /// 最后回复时间
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        private string GetTimtSetDay(string Data)
        {
            string latestPostData = "";
            if (!string.IsNullOrEmpty(Data))
            {
                DateTime lateTime = DateTime.Parse(Data);
                DateTime nowTime = DateTime.Now;

                TimeSpan ts = nowTime - lateTime;
                double days = ts.TotalDays;

                int day = Math.Abs(((TimeSpan)(DateTime.Now - lateTime)).Days);
                if (day > 366)
                    latestPostData = lateTime.ToString("yyyy-MM-dd");
                else if (day > 30 && day < 366)
                    latestPostData = lateTime.ToString("MM-dd");
                else if (DateTime.Now.ToShortDateString() != lateTime.ToShortDateString())//判断日期
                    latestPostData = day + "天前";
                else if (DateTime.Now.Hour != lateTime.Hour)
                    latestPostData = (DateTime.Now.Hour - lateTime.Hour).ToString() + "小时前";
                else if (DateTime.Now.Minute != lateTime.Minute)
                    latestPostData = (DateTime.Now.Minute - lateTime.Minute).ToString() + "分钟前";
                else if (DateTime.Now.Second != lateTime.Second)
                    latestPostData = (DateTime.Now.Second - lateTime.Second).ToString() + "秒前";
                else
                    latestPostData = "刚刚";

                if (latestPostData == "0天前")
                    latestPostData = Math.Abs(((TimeSpan)(DateTime.Now - lateTime)).Hours) + "小时前";
            }
            return latestPostData;
        }

        private string GetRelativeTime(string time)
        {
            DateTime dt1 = Convert.ToDateTime(time);
            DateTime dt2 = DateTime.Now;
            TimeSpan ts = dt2 - dt1;
            string dateDiff = string.Empty;
            if (string.IsNullOrEmpty(time))
            {
                dateDiff = "";
            }
            else if (ts.Days >= 1)
            {
                dateDiff = ts.Days.ToString() + "天前";
            }
            else if (ts.Hours >= 1)
            {
                dateDiff = ts.Hours.ToString() + "小时前";
            }
            else if (ts.Minutes >= 1)
            {
                dateDiff = ts.Minutes.ToString() + "分钟前";
            }
            else if (ts.Seconds >= 3)
            {
                dateDiff = ts.Seconds.ToString() + "秒前";
            }
            else
            {
                dateDiff = "刚刚";
            }
            return dateDiff;
        }

        public async Task<bool> AddCourseThread(CourseThreadInputDto input)
        {
            if (string.IsNullOrEmpty(input.userId) || string.IsNullOrEmpty(input.type))
            {
                return false;
            }
            try
            {
                CourseThread ct = new CourseThread();
                ct.id = Guid.NewGuid();
                ct.userId = Guid.Parse(input.userId);
                ct.title = input.title;
                ct.content = input.content;
                ct.replyNum = 0;
                ct.lessonId = input.lessonId.TryParseGuid();
                ct.moduleId = input.moduleId.TryParseGuid();
                ct.createTime = DateTime.Now;
                ct.type = input.type;
                ct.learnPlatformId = input.LearningPlatformId.TryParseGuid();
                this.courseThreadRepository.Insert(ct);
                unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<CourseThreadDetail> GetCourseThreadDetailList(string threadId, int pageSiz, ref int total)
        {
            var list = new  List<CourseThreadDetail>();
            var data = from cp in courseThreadPost.GetAll()
                       join u in usersRepository.GetAll() on cp.userId equals u.id
                       // join c in courseRepository.GetAll() on cp.courseId equals c.id
                       where cp.threadId.ToString()==threadId
                       orderby cp.createTime
                       select new CourseThreadDetail()
                        {
                            ThreadId = cp.id.ToString(),
                            // ReplyNum = c.replyNum,
                            Content = cp.content,
                            CreateTime = cp.createTime,
                            UserHeadImg = u.smallAvatar,
                            UserId = u.id,
                            UserName = u.userFullName ?? u.userLoginName
                        };
            list = data.ToList();
            total = data.Count();
            return list;
           
        }

        public CourseThread GetCourseThread(string threadId)
        {
            CourseThread courseThread = new CourseThread();
            try
            {
                courseThread = courseThreadRepository.GetById(threadId);
            }
            catch (Exception ex)
            {
                
            }
            return courseThread ?? new CourseThread();
        }
    }
}
