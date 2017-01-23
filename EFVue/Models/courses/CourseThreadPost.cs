using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.courses
{
    public class CourseThreadPost : BaseEntity
    { /// <summary>
        /// 课程ID
        /// </summary>
        public Guid courseId { get; set; }

        /// <summary>
        /// 课时ID
        /// </summary>
        public Guid lessonId { get; set; }

        /// <summary>
        /// 话题ID
        /// </summary>
        public Guid threadId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public Guid userId { get; set; }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 是否加精
        /// </summary>
        public bool isElite { get; set; }

        public string content { get; set; }

        public DateTime createTime { get; set; }

    }
}
