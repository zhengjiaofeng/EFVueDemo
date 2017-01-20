
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Models;

namespace Models.courses
{
    public class CourseLesson:BaseEntity
    {
        /// <summary>
        /// 课时ID
        /// </summary>
        //[Key]
        //[StringLength(36)]
        //public string id { get; set; }

        /// <summary>
        /// 课时编号
        /// </summary>
        [StringLength(50)]
        public string no { get; set; }

        /// <summary>
        /// 课时所属课程ID
        /// </summary>
        [StringLength(36)]
        public string courseId { get; set; }

        /// <summary>
        /// 课时所属章节ID
        /// </summary>
        [StringLength(36)]
        public string chapterId { get; set; }

        /// <summary>
        /// 课时编号
        /// </summary>
        public int number { get; set; }

        /// <summary>
        /// 课时在课程中的序号
        /// </summary>
        public int seq { get; set; }

        /// <summary>
        /// 是否为免费课时
        /// </summary>
        public int free { get; set; }

        /// <summary>
        /// 课时状态 published、unpublished
        /// </summary>
        [StringLength(36)]
        public string status { get; set; }

        /// <summary>
        /// 课时标题
        /// </summary>
        [StringLength(50)]
        public string title { get; set; }

        /// <summary>
        /// 课时摘要
        /// </summary>
        [StringLength(255)]
        public string summary { get; set; }

        /// <summary>
        /// 课时标签
        /// </summary>
        [StringLength(255)]
        public string tags { get; set; }

        /// <summary>
        /// 课时类型(text,video,web,scorm,audio,assesswork,document)
        /// </summary>
        [StringLength(20)]
        public string type { get; set; }

        /// <summary>
        /// 类型标记
        /// </summary>
        [StringLength(50)]
        public string typeMark { get; set; }

        /// <summary>
        /// 课时正文
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// 学完课时获得的学分
        /// </summary>
        public int giveCredit { get; set; }

        /// <summary>
        /// 学习课时前，需要到达的学分
        /// </summary>
        public int requireCredit { get; set; }

        /// <summary>
        /// 媒体文件ID
        /// </summary>
        [StringLength(36)]
        public string mediaId { get; set; }

        /// <summary>
        /// 媒体文件来源(self:本站上传，youku:优酷)
        /// </summary>
        [StringLength(255)]
        public string mediaSource { get; set; }

        /// <summary>
        /// 媒体文件名称
        /// </summary>
        [StringLength(255)]
        public string mediaName { get; set; }

        /// <summary>
        /// 媒体文件资源名
        /// </summary>
        [StringLength(255)]
        public string mediaUri { get; set; }

        /// <summary>
        /// 时长
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// 上传的资料数量
        /// </summary>
        public int materialNum { get; set; }

        /// <summary>
        /// 测验题目数量
        /// </summary>
        public int quizNum { get; set; }

        /// <summary>
        /// 已学的学员数
        /// </summary>
        public int learnedNum { get; set; }

        /// <summary>
        /// 查看数
        /// </summary>
        public int viewedNum { get; set; }

        /// <summary>
        /// 直播课时开始时间
        /// </summary>
        public int startTime { get; set; }

        /// <summary>
        /// 直播课时结束时间
        /// </summary>
        public int endTime { get; set; }

        /// <summary>
        /// 直播课时加入人数
        /// </summary>
        public int memberNum { get; set; }

        /// <summary>
        /// 发布状态
        /// </summary>
        [StringLength(255)]
        public string replayStatus { get; set; }

        /// <summary>
        /// 发布人ID
        /// </summary>
        [StringLength(36)]
        public string userId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [StringLength(19)]
        public string createTime { get; set; }
        /// <summary>
        /// 最后更新时间
        /// </summary>
        [StringLength(19)]
        public string lastUpdateTime { get; set; }
        /// <summary>
        /// 是否为新
        /// </summary>
        public bool isNew { get; set; }

        /// <summary>
        /// PPT自动轮播时间
        /// </summary>
        public int documentSlideShowSpeed { get; set; }
    }

    /// <summary>
    /// 课时类型
    /// </summary>
    public class LessonType
    {
        /// <summary>
        /// 类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 类型图标
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 时长
        /// </summary>
        public string duration { get; set; }
    }

    /// <summary>
    /// 用户课时
    /// </summary>
    public class UserCourseLesson
    {
        /// <summary>
        /// 章节id
        /// </summary>
        public string chapterId { get; set; }

        /// <summary>
        /// 章节编号
        /// </summary>
        public int chapterNumber { get; set; } 

        /// <summary>
        /// 章节名称
        /// </summary>
        public string chapterTitle { get; set; }
        
        /// <summary>
        /// 课时id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 学习状态
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 课程id
        /// </summary>
        public string courseId { get; set; }

        /// <summary>
        /// 课时标题
        /// </summary>
        public string title { get; set; }
        public string title2 { get; set; }

        /// <summary>
        /// 课时类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 考试标记
        /// </summary>
        public string typeMark { get; set; }

        /// <summary>
        /// 课时时长
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int seq { get; set; }

        /// <summary>
        /// 百分比
        /// </summary>
        public decimal percent { get; set; }

        public bool isNew { get; set; }
    }


    /// <summary>
    /// 用户课时
    /// </summary>
    public class ChapterLessonModel
    {
        /// <summary>
        /// 章节id
        /// </summary>
        public string chapterId { get; set; }

        /// <summary>
        /// 章节编号
        /// </summary>
        public int chapterNumber { get; set; }

        /// <summary>
        /// 章节名称
        /// </summary>
        public string chapterTitle { get; set; }

        /// <summary>
        /// 课时id
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// 学习状态
        /// </summary>
        public string status { get; set; }

        /// <summary>
        /// 课程id
        /// </summary>
        public string courseId { get; set; }

        /// <summary>
        /// 课时标题
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// 课时类型
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 考试分类
        /// </summary>
        public string typeMark { get; set; }

        /// <summary>
        /// 课时时长
        /// </summary>
        public string time { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int seq { get; set; }

        /// <summary>
        /// 是否免费课时
        /// </summary>
        public int free { get; set; }

        /// <summary>
        /// 试卷id
        /// </summary>
        public string mediaId { get; set; }

        /// <summary>
        /// 试卷类型
        /// </summary>
        public string tags { get; set; }

        /// <summary>
        /// 媒体文件名称
        /// </summary>
        public string mediaName { get; set; }

        /// <summary>
        /// 媒体文件地址
        /// </summary>
        public string mediaUri { get; set; }

        public List<ChapterLessonModel> LessonList { get; set; }
    }
}
