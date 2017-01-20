using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.InputModels.homePage
{
    public class HomePageCourse
    {
        public string id { get; set; }
        public string teacherIds { get; set; }
        public string largePicture { get; set; }
        public int studentNum { get; set; }
        public string title { get; set; }
        public int lessonNum { get; set; }
        public decimal price { get; set; }
        public string pathfullid { get; set; }
        public string categoryId { get; set; }
        public int length { get; set; }
        public string timingMode { get; set; }
        public string createTime { get; set; }
    }
}
