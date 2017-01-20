using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.project
{
  public  class ProjectPlatform:BaseEntity
    {
        /// <summary>
        /// 项目编号
        /// </summary>
        [Column("projectId")]
        public Guid ProjectId { get; set; }
        /// <summary>
        /// 课程编号
        /// </summary>
        [Column("platformId")]
        public Guid PlatformId { get; set; }

    }
}
