using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class UserInfo : BaseEntity
    {
        public Guid id { get; set; }

        public string userName { get; set; }
    }
}