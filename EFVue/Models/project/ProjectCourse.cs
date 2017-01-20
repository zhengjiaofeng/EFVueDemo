using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.project
{
   public class ProjectCourse:BaseEntity
   {/// <summary>
       /// 项目编号
       /// </summary>
       [Column("projectId")]
       public Guid ProjectId { get; set; }
       /// <summary>
       /// 课程编号
       /// </summary>
       [Column("courseId")]
       public Guid CourseId { get; set; }
       /// <summary>
       /// 是否来自云端 合作项目下发的课程(来自云端)不允许编辑、不允许删除此记录
       /// </summary>
       [Column("isFromCloud")]
       [DefaultValue(0)]
       public byte IsFromCloud { get; set; }
       /// <summary>
       /// 课程内容是否有更新
       /// </summary>
       [DefaultValue(0)]
       [Column("contentUpdate")]
       public byte ContentUpdate { get; set; }
       /// <summary>
       /// 内容更新时间
       /// </summary>
       [Column("updateTime")]
       public DateTime UpdateTime { get; set; }
    }
}
