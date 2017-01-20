using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.InputModels.studyPlate
{
    public class StudyPlatformViewModel
    {
        private List<StudyPlatformObj> _StudyPlatformList = new List<StudyPlatformObj>();
        public List<StudyPlatformObj> StudyPlatformList
        {
            get { return _StudyPlatformList; }
            set { _StudyPlatformList = value; }
        }

        private int _CurrentPage = 0;
        public int CurrentPage
        {
            get { return _CurrentPage; }
            set { _CurrentPage = value; }
        }

        private int _SumPage = 0;
        public int SumPage
        {
            get { return _SumPage; }
            set { _SumPage = value; }
        }

    }

    public class StudyPlatformObj
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        private Guid _ProjectId = Guid.Empty;
        public Guid ProjectId
        {
            get { return _ProjectId; }
            set { _ProjectId = value; }
        }

        private Guid _PlatId = Guid.Empty;
        public Guid PlatId
        {
            get { return _PlatId; }
            set { _PlatId = value; }
        }

        /// <summary>
        /// 平台的名称
        /// </summary>
        private string _PlatName = string.Empty;
        public string PlatName
        {
            get { return _PlatName; }
            set { _PlatName = value; }
        }

        /// <summary>
        /// 平台的简介
        /// </summary>
        private string _Introduction = string.Empty;
        public string Introduction
        {
            get { return _Introduction; }
            set { _Introduction = value; }
        }

        /// <summary>
        /// 平台的图片
        /// </summary>
        private string _ImgPath = string.Empty;
        public string ImgPath
        {
            get { return _ImgPath; }
            set { _ImgPath = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        private DateTime _CreateTime = DateTime.Now;
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        /// <summary>
        /// 平台的课程数
        /// </summary>
        private int _CourseCount = 0;
        public int CourseCount
        {
            get { return _CourseCount; }
            set { _CourseCount = value; }
        }
    }
}
