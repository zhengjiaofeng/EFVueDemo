using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.InputModels.courses
{
    public class courseTreadView
    {
        public class CourseThreadViewModel
        {
            private List<CourseThreadEntity> _ThreadEntityList = new List<CourseThreadEntity>();
            public List<CourseThreadEntity> ThreadEntityList
            {
                get { return _ThreadEntityList; }
                set { _ThreadEntityList = value; }
            }
            //判断是否登陆
            public bool isLog = false;

            private int _ThreadEntityListCount = 0;
            public int ThreadEntityListCount
            {
                get { return _ThreadEntityListCount; }
                set { _ThreadEntityListCount = value; }
            }

            private int _CurrentPage = 0;
            public int CurrentPage
            {
                get { return _CurrentPage; }
                set { _CurrentPage = value; }
            }

            private string _CurrentType = string.Empty;
            public string CurrentType
            {
                get { return _CurrentType; }
                set { _CurrentType = value; }
            }

            private int _AllType = 0;
            private int AllType
            {
                get { return _AllType; }
                set { _AllType = value; }
            }

            private int _DirectCount = 0;
            public int DirectCount
            {
                get { return _DirectCount; }
                set { _DirectCount = value; }
            }

            private int _CourseCount = 0;
            public int CourseCount
            {
                get { return _CourseCount; }
                set { _CourseCount = value; }
            }

            private int _AllCount = 0;
            public int AllCount
            {
                get { return _AllCount; }
                set { _AllCount = value; }
            }

            private string _KeyWord = string.Empty;
            public string KeyWord
            {
                get { return _KeyWord; }
                set { _KeyWord = value; }
            }


            private bool _IsLogin = false;
            /// <summary>
            /// 判断是否登录
            /// </summary>
            public bool IsLogin
            {
                get { return _IsLogin; }
                set { _IsLogin = value; }
            }


            private List<CourseThreadEntity> _RecommendList = new List<CourseThreadEntity>();
            /// <summary>
            /// 推荐答疑
            /// </summary>
            public List<CourseThreadEntity> RecommendList
            {
                get { return _RecommendList; }
                set { _RecommendList = value; }
            }


            private string _TitleKeyWord = string.Empty;

            /// <summary>
            /// 教师答疑的标题关键字
            /// </summary>
            public string TitleKeyWord
            {
                get { return _TitleKeyWord; }
                set { _TitleKeyWord = value; }
            }


            private int _TabIndex = 0;

            /// <summary>
            /// 选项卡
            /// </summary>
            public int TabIndex
            {
                get { return _TabIndex; }
                set { _TabIndex = value; }
            }

            /// <summary>
            /// 学习平台
            /// </summary>
            //private List<LearningPlatformDto> _PlateListItem = new List<LearningPlatformDto>();
            //public List<LearningPlatformDto> PlateListItem
            //{
            //    get { return _PlateListItem; }
            //    set { _PlateListItem = value; }
            //}
            /// <summary>
            /// 共享项目(开放给其他伙伴合作的项目)
            /// </summary>
            //private List<SelectListItem> _ProjectListItem = new List<SelectListItem>();
            //public List<SelectListItem> ProjectListItem
            //{
            //    get { return _ProjectListItem; }
            //    set { _ProjectListItem = value; }
        }
        private string _PlatFormId = string.Empty;
        public string PlatFormId
        {
            get { return _PlatFormId; }
            set { _PlatFormId = value; }
        }
    }

    public class CourseThreadEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string userFullName { get; set; }


        public string CourseId { get; set; }

        public string UserId { get; set; }
        private string _ThreadId = string.Empty;
        public string ThreadId
        {
            get { return _ThreadId; }
            set { _ThreadId = value; }
        }

        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        private string _LearnPlatformId = string.Empty;
        public string LearnPlatformId
        {
            get { return _LearnPlatformId; }
            set { _LearnPlatformId = value; }
        }
        private string _UserName = string.Empty;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _UserNameHeadImgUrl = string.Empty;
        public string UserNameHeadImgUrl
        {
            get { return _UserNameHeadImgUrl; }
            set { _UserNameHeadImgUrl = value; }
        }

        private string _PostUserName = string.Empty;
        public string PostUserName
        {
            get { return _PostUserName; }
            set { _PostUserName = value; }
        }

        private string _CourseName = string.Empty;
        public string CourseName
        {
            get { return _CourseName; }
            set { _CourseName = value; }
        }

        private DateTime _CreateTime = DateTime.Now;
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        private string _CreateTimeStr = string.Empty;
        public string CreateTimeStr
        {
            get { return _CreateTimeStr; }
            set { _CreateTimeStr = value; }
        }


        private int _PostNum = 0;
        public int PostNum
        {
            get { return _PostNum; }
            set { _PostNum = value; }
        }

        private DateTime _LastPostTime = DateTime.Now;
        public DateTime LastPostTime
        {
            get { return _LastPostTime; }
            set { _LastPostTime = value; }
        }

        private string _LastPostTimeStr = string.Empty;
        public string LastPostTimeStr
        {
            get { return _LastPostTimeStr; }
            set { _LastPostTimeStr = value; }
        }

        private string _Type = string.Empty;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }


        /// <summary>
        /// 是否显示问答
        /// </summary>
        private bool _IsShowQuestion;
        public bool IsShowQuestion
        {
            get { return _IsShowQuestion; }
            set { _IsShowQuestion = value; }
        }

        /// <summary>
        /// 内容
        /// </summary>
        private string _Content;
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        /// <summary>
        /// 是否推荐
        /// </summary>
        private string _Recommended;
        public string Recommended
        {
            get { return _Recommended; }
            set { _Recommended = value; }
        }

        private string _PlatformId = string.Empty;
        /// <summary>
        /// 平台id
        /// </summary>
        public string PlatformId
        {
            get { return _PlatformId; }
            set { _PlatformId = value; }
        }

    }

}
