using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.InputModels.courses
{
    public class CourseThreadInputDto
    {
        public string studyPlatform { get; set; }

        public string courseName { get; set; }

        public string type { get; set; }

        public string courseId { get; set; }

        public string lessonId { get; set; }

        public string courseThreadId { get; set; }

        public string moduleId { get; set; }

        public string userId { get; set; }

        // public string type { get; set; }

        public string title { get; set; }

        public string content { get; set; }

        public int postNum { get; set; }

        public DateTime latestPostTime { get; set; }

        public DateTime createTime { get; set; }

        /// <summary>
        /// 课程的关键字
        /// </summary>
        public string keyWord { get; set; }

        /// <summary>
        /// 主题的关键字
        /// </summary>
        public string threadKeyWord { get; set; }

        public string currentUserId { get; set; }

        /// <summary>
        /// 回复类型
        /// </summary>
        public bool postType { get; set; }
        /// <summary>
        /// 排序表达式
        /// </summary>
        // public string OrderExpression { get { return SortCloumnName + " " + SortOrder; } }

        /// <summary>
        /// 是否置顶
        /// </summary>
        public bool isStick { get; set; }

        /// <summary>
        /// 是否精华
        /// </summary>
        public bool isElite { get; set; }

        /// <summary>
        /// 标题的关键字
        /// </summary>
        public string titleKeyWorld { get; set; }

        /// <summary>
        /// 角色类型
        /// </summary>
        public int identity { get; set; }

        /// <summary>
        /// 置顶时间
        /// </summary>
        public DateTime topTime { get; set; }

        /// <summary>
        /// 提问人信息 全网答疑提问者可能不在当前平台 格式机构加姓名 学员A(白云学院)
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 提问人所在机构
        /// </summary>
        public string applyPartnerId { get; set; }
        /// <summary>
        /// 项目ID
        /// </summary>
        public string projectId { get; set; }

        /// <summary>
        /// 平台id
        /// </summary>
        public string LearningPlatformId { get; set; }
    }
}
