using ConnectMysql.Models;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ConnectMysql.Content
{
    public class EFContext:DbContext
    {
        public EFContext()
            : base("Default")
        {
            //禁用了自动初始化：
            this.Database.Initialize(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //指定单数形式的表名默认情况下会生成复数形式的表，如UserInfos
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<users> users { get; set; }
        public DbSet<CourseThread> CourseThread { get; set; }
    }
}