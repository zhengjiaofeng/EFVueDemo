
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Models;
using System.ComponentModel;

namespace Models.courses
{
    /// <summary>
    /// 课程
    /// </summary>
    public class Course : BaseEntity
    {
        /// <summary>
        /// 课程编码
        /// </summary>
        [StringLength(50)]
        public string code { get; set; }

        /// <summary>
        /// 课程编号
        /// </summary>
        [StringLength(50)]
        public string no { get; set; }

        /// <summary>
        /// 课程标题
        /// </summary>
        [StringLength(50)]
        public string title { get; set; }

        /// <summary>
        /// 课程副标题
        /// </summary>
        [StringLength(50)]
        public string subTitle { get; set; }

        /// <summary>
        /// 课程状态[published:已发布,unpublished:未发布,closed:已关闭,trash:废弃]
        /// </summary>
        [StringLength(20)]
        public string status { get; set; }

        [StringLength(20)]
        public string type { get; set; }

        /// <summary>
        /// 直播课程最大学员数上限
        /// </summary>
        public int maxStudentNum { get; set; }

        /// <summary>
        /// 课程价格
        /// </summary>
        public decimal price { get; set; }

        /// <summary>
        /// 售价
        /// </summary>
        public decimal salePrice { get; set; }

        /// <summary>
        /// 免费课程类型,课程价格为0时包含此字段值[允许任何人加入:freedom,申请加入:approval,不允许任何人加入:addition]
        /// </summary>
        [StringLength(50)]
        public string freeType { get; set; }

        /// <summary>
        /// 课程过期天数
        /// </summary>
        public int expiryDay { get; set; }

        /// <summary>
        /// 学生人数是否显示
        /// </summary>
        [StringLength(20)]
        public string showStudentNumType { get; set; }

        /// <summary>
        /// 连载模式[finished:已完结,serialize:更新中,default:非连载课程]
        /// </summary>
        [StringLength(20)]
        public string serializeMode { get; set; }

        /// <summary>
        /// 计时方式[course：课程，lesson:课时]
        /// </summary>
        [StringLength(10)]
        public string timingMode { get; set; }

        /// <summary>
        /// 课程时长
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// 课程销售总收入
        /// </summary>
        public decimal income { get; set; }

        /// <summary>
        /// 课时数
        /// </summary>
        public int lessonNum { get; set; }

        /// <summary>
        /// 学完课程所有课时获得的总学分
        /// </summary>
        public int giveCredit { get; set; }

        /// <summary>
        /// 排行分数
        /// </summary>
        public int rating { get; set; }

        /// <summary>
        /// 投票人数
        /// </summary>
        public int ratingNum { get; set; }

        /// <summary>
        /// 可以免费看的会员等级
        /// </summary>
        public int vipLevelId { get; set; }

        /// <summary>
        /// 分类Id
        /// </summary>        
        public Guid categoryId { get; set; }

        /// <summary>
        /// 分类路径
        /// </summary>
        public string categoryFullPath { get; set; }

        /// <summary>
        /// 标签Id组
        /// </summary>
        public string tags { get; set; }

        /// <summary>
        /// 课程小图片
        /// </summary>
        [StringLength(255)]
        public string smallPicture { get; set; }

        /// <summary>
        /// 课程中图片
        /// </summary>
        [StringLength(255)]
        public string middlePicture { get; set; }

        /// <summary>
        /// 课程大图片
        /// </summary>
        [StringLength(255)]
        public string largePicture { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string about { get; set; }

        /// <summary>
        /// 视频简介
        /// </summary>
        [StringLength(255)]
        public string videoAbout { get; set; }

        /// <summary>
        /// 是否允许补交作业
        /// </summary>
        public bool isUndo { get; set; }

        /// <summary>
        /// 是否显示视频简介
        /// </summary>
        public bool isVideoAbout { get; set; }

        /// <summary>
        /// 显示的课程教师Id
        /// </summary>
        public string teacherIds { get; set; }

        /// <summary>
        /// 学科Id
        /// </summary>        
        public Guid subjectId { get; set; }

        /// <summary>
        /// 组织架构Id
        /// </summary>
        public string departmentId { get; set; }

        /// <summary>
        /// 课程目标
        /// </summary>        
        public string goals { get; set; }

        /// <summary>
        /// 适合人群
        /// </summary>      
        public string audiences { get; set; }

        /// <summary>
        /// 是否为推荐课程
        /// </summary>
        public bool recommended { get; set; }

        /// <summary>
        /// 推荐序号
        /// </summary>
        public int recommendedSeq { get; set; }

        /// <summary>
        /// 推荐时间
        /// </summary>
        [StringLength(19)]
        public string recommendedTime { get; set; }

        /// <summary>
        /// 上课地区Id
        /// </summary>  
        [DefaultValue("00000000-0000-0000-0000-000000000000")]
        public Guid locationId { get; set; }

        /// <summary>
        /// 上课地区地址
        /// </summary>
        [StringLength(255)]
        public string address { get; set; }

        /// <summary>
        /// 学员数
        /// </summary>
        public int studentNum { get; set; }

        /// <summary>
        /// 查看次数
        /// </summary>
        public int hitNum { get; set; }

        /// <summary>
        /// 课程发布人Id
        /// </summary>        
        public Guid userId { get; set; }

        /// <summary>
        /// 免费结束时间
        /// </summary>
        [StringLength(19)]
        public string freeEndTime { get; set; }

        /// <summary>
        /// 序号
        /// </summary>
        public int seq { get; set; }

        /// <summary>
        /// 是否防挂机
        /// </summary>
        public bool prevent { get; set; }

        /// <summary>
        /// 是否完成所有非考试课时才能参加考试
        /// </summary>
        public bool isNeedCompletedLessons { get; set; }

        /// <summary>
        /// 挂机时长
        /// </summary>
        public int prvtLen { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>        
        public DateTime createTime { get; set; }

        /// <summary>
        /// 是否为考试
        /// [course:普通课程，exam:考试课程]
        /// </summary>
        [StringLength(36)]
        public string examModel { get; set; }

        /// <summary>
        /// 是否允许修改保存课程
        /// </summary>
        public bool isEdit { get; set; }

        /// <summary>
        /// 是否显示评论
        /// </summary>
        public bool isComment { get; set; }

        /// <summary>
        /// 是否显示问答
        /// </summary>
        public bool isShowQuestion { get; set; }

        public Guid thirdCodeId { get; set; }

        public string thirdTeacherId { get; set; }

        /// <summary>
        /// 课程计划班级Id
        /// </summary>        
        public Guid thirdClassId { get; set; }

        /// <summary>
        /// 评分标准
        /// </summary>
        public string scoringCriteria { get; set; }

        /// <summary>
        /// 有效期类型[time,batch]，默认time
        /// </summary>
        [StringLength(20)]
        public string validityType { get; set; }

        public Guid thirdSemesterId { get; set; }

        /// <summary>
        /// 是否只有课程包能购买
        /// </summary>
        public bool onlyCoursePackage { get; set; }

        /// <summary>
        /// 课程学分
        /// </summary>
        public decimal credits { get; set; }

        /// <summary>
        /// 是否是自定义编号
        /// </summary>        
        public bool isAutoNo { get; set; }

        /// <summary>
        /// 上传图片文件Id
        /// </summary>        
        public Guid picFileId { get; set; }

        /// <summary>
        /// 上传视频文件Id
        /// </summary>        
        public Guid videoFileId { get; set; }

        /// <summary>
        /// 二维码
        /// </summary>
        public string QRCode { get; set; }
    }
}
