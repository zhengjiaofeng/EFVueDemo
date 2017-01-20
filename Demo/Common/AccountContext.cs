using Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Demo.Common
{
    public class AccountContext:DbContext
      
    {
        public AccountContext()
            : base("AccountContext")
        { 
            
        }

        public DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //指定单数形式的表名默认情况下会生成复数形式的表，如UserInfos
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}