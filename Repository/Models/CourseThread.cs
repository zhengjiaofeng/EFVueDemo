using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Repository.Models
{
    public class CourseThread: BaseEntity
    {
       // public Guid id { get; set; }
        public Guid userId { get; set; }
        public string title { get; set; }

    }
}