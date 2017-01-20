using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.project
{
   public class LearningPlatform:BaseEntity
   {/// <summary>
       /// 学习平台名称
       /// </summary>
       [StringLength(255)]
       public string LearningPlatformName { get; set; }

       /// <summary>
       /// 学习平台Code
       /// </summary>
       [StringLength(50)]
       public string LearningPlatformCode { get; set; }

       /// <summary>
       /// 学习平台简介
       /// </summary>
       [StringLength(800)]
       public string Introduction { get; set; }

       /// <summary>
       /// 学习平台图片（上传路径）
       /// </summary>
       [StringLength(500)]
       public string ImgPath { get; set; }

       /// <summary>
       /// 创建时间
       /// </summary>
       public DateTime CreateTime { get; set; }

       /// <summary>
       /// 创建人ID
       /// </summary>
       public Guid CreateUserId { get; set; }


       /// <summary>
       /// 是否删除
       /// </summary>
       public bool IsDel { get; set; }
    }
}
