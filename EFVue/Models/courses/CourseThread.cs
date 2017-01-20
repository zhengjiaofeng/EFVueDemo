using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.courses
{
   public class CourseThread:BaseEntity
    {
        /// <summary>
        /// 课程ID
        /// </summary>
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid courseId { get; set; }

        /// <summary>
        /// 课时ID
        /// </summary>
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid lessonId { get; set; }

        /// <summary>
        /// 模块的ID
        /// </summary>
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid moduleId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid userId { get; set; }

        /// <summary>
        /// 笔记的ID
        /// </summary>
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid noteId { get; set; }

        /// <summary>
        /// 话题及问题的类型:discussion(课程提问)、notes(笔记)、question(直接提问)
        /// </summary>
        [StringLength(50)]
        [DefaultValue("")]
        public string type { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        [DefaultValue(false)]
        public bool isStick { get; set; }

        /// <summary>
        /// 是否精华
        /// </summary>
        [DefaultValue(false)]
        public bool isElite { get; set; }

        /// <summary>
        /// 是否关闭
        /// </summary>
        [DefaultValue(false)]
        public bool isClosed { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [StringLength(255)]
        [DefaultValue("")]
        public string title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        [DefaultValue("")]
        public string content { get; set; }

        /// <summary>
        /// 回复次数
        /// </summary>
        [DefaultValue(0)]
        public int replyNum { get; set; }

        /// <summary>
        /// 浏览次数
        /// </summary>
        [DefaultValue(0)]
        public int browseNum { get; set; }

        /// <summary>
        /// 关注次数
        /// </summary>
        [DefaultValue(0)]
        public int focusNum { get; set; }

        /// <summary>
        /// 最后回复人ID
        /// </summary>
        [DefaultValue("")]
        public string lastReplyUserId { get; set; }

        /// <summary>
        /// 最后回复的时间
        /// </summary>
        public DateTime lastReplyTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createTime { get; set; }

        public CourseThread()
        {
            // lastReplyTime = DateTime.Now;
            createTime = DateTime.Now;
        }

        /// <summary>
        /// 平台id
        /// </summary>
        public Guid learnPlatformId { get; set; }

        /// <summary>
        /// 置顶时间
        /// </summary>
      //  public DateTime? topTime { get; set; }
    }
}
