using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.InputModels.courses
{
    public class CourseThreadDetail : BaseEntity
    {
        /// <summary>
        /// 主题ID
        /// </summary>
        private string _ThreadId = string.Empty;
        public string ThreadId
        {
            get { return _ThreadId; }
            set { _ThreadId = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        private string _Title = string.Empty;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        /// <summary>
        /// 回复的条数
        /// </summary>
        private int _ReplyNum = 0;
        public int ReplyNum
        {
            get { return _ReplyNum; }
            set { _ReplyNum = value; }
        }

        private Guid _UserId = Guid.Empty;
        public Guid UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }

        private string _UserName = string.Empty;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }

        private string _UserHeadImg = string.Empty;
        public string UserHeadImg
        {
            get { return _UserHeadImg; }
            set { _UserHeadImg = value; }
        }

        private DateTime _CreateTime = DateTime.Now;
        public DateTime CreateTime
        {
            get { return _CreateTime; }
            set { _CreateTime = value; }
        }

        private string _Content = string.Empty;
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        private Position _Position = Position.Right;
        public Position Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        private string _TimeConvert = string.Empty;
        public string TimeConvert
        {
            get { return _TimeConvert; }
            set { _TimeConvert = value; }
        }

        /// <summary>
        /// 是否置顶
        /// </summary>
        private bool _IsStick = false;
        public bool IsStick
        {
            get { return _IsStick; }
            set { _IsStick = value; }
        }

        private int _StickVal = 0;
        public int StickVal
        {
            get { return _StickVal; }
            set { _StickVal = value; }
        }

        /// <summary>
        /// 是否精华
        /// </summary>
        private bool _IsElite = false;
        public bool IsElite
        {
            get { return _IsElite; }
            set { _IsElite = value; }
        }

        private int _EliteVal = 0;
        public int EliteVal
        {
            get { return _StickVal; }
            set { _StickVal = value; }
        }

        private Guid _Id = Guid.Empty;
        public Guid Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }
    public enum Position
    {
        Left,
        Center,
        Right
    }
}
