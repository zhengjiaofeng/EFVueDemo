using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.project
{
   public class Project:BaseEntity
   {  /// <summary>
       /// 编码
       /// </summary>
       [StringLength(32)]
       [Column("projectCode")]
       public string ProjectCode { get; set; }
       /// <summary>
       /// 名称
       /// </summary>
       [StringLength(64)]
       [Column("projectName")]
       public string ProjectName { get; set; }
       /// <summary>
       /// 状态 1:已发布|合作中 0:未发布|待合作   3:已经发布但未公开  根据类型表示不同含义
       /// </summary>
       [DefaultValue(0)]
       [Column("status")]
       public byte Status { get; set; }
       /// <summary>
       /// 类型 1:合作 0:自主运营 
       /// </summary>
       [DefaultValue(0)]
       [Column("type")]
       public byte Type { get; set; }
       /// <summary>
       /// 内容是否有更新 0:未更新 1:有更新  冗余字段
       /// </summary>
       [DefaultValue(0)]
       [Column("contentUpdate")]
       public byte ContentUpdate { get; set; }
       /// <summary>
       /// 发布时间
       /// </summary>
       [Column("publishTime")]
       public DateTime PublishTime { get; set; }
       /// <summary>
       /// 云端项目编号
       /// </summary>
       [Column("cloudProjectId")]
       public int CloudProjectId { get; set; }
       /// <summary>
       /// 项目主办单位  合作运营项目
       /// </summary>
       [Column("organizer")]
       [StringLength(128)]
       public string Organizer { get; set; }
       /// <summary>
       /// 主项目站点运营域名  合作运营项目
       /// </summary>
       [Column("domian")]
       [StringLength(500)]
       public string Domian { get; set; }
       /// <summary>
       /// 合作时间  合作运营项目
       /// </summary>
       [Column("cooperateTime")]
       public DateTime CooperateTime { get; set; }
       /// <summary>
       /// 创建时间
       /// </summary>
       [Column("creationTime")]
       public DateTime CreationTime { get; set; }
       /// <summary>
       /// 最后更新时间
       /// </summary>
       [Column("lastUpdateTime")]
       public DateTime LastUpdateTime { get; set; }
       /// <summary>
       /// 创建人ID
       /// </summary>
       [Column("creatorUid")]
       public Guid CreatorUid { get; set; }
       /// <summary>
       /// 创建人
       /// </summary>
       [StringLength(32)]
       [Column("creator")]
       public string Creator { get; set; }
       /// <summary>
       /// 描述
       /// </summary>
       [Column("projectDes", TypeName = "text")]
       public string ProjectDes { get; set; }

    }
}
