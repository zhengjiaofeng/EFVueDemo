using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Models.user;
using SmartUFO.User;
using Models.project;
using Models.courses;
namespace EFDLL
{
    public class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("VueContext")
        {
            try
            {
                this.Database.Initialize(true);
            }
            catch (Exception ex)
            { 
                
            }

            // Database.SetInitializer<EFDbContext>(null);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //指定单数形式的表名默认情况下会生成复数形式的表，如UserInfos
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<TeacherInfo>().ToTable("teacher_info");
            modelBuilder.Entity<StudentInfo>().ToTable("student_info");
            modelBuilder.Entity<Course>().ToTable("course");
            modelBuilder.Entity<CourseLesson>().ToTable("course_lesson");
            modelBuilder.Entity<CourseThread>().ToTable("course_thread");
            modelBuilder.Entity<LearningPlatform>().ToTable("learning_platforms");
            modelBuilder.Entity<Project>().ToTable("project");
            modelBuilder.Entity<ProjectPlatform>().ToTable("project_platform");
            modelBuilder.Entity<ProjectCourse>().ToTable("project_course");
            modelBuilder.Entity<CourseThreadPost>().ToTable("course_thread_post");
           
        }
        public DbSet<users> UserInfo { get; set; }
        public DbSet<StudentInfo> StudentInfo { get; set; }
        public DbSet<TeacherInfo> TeacherInfo { get; set; }

        public DbSet<Course> Course { get; set; }
        public DbSet<CourseLesson> CourseLesson { get; set; }

        public DbSet<LearningPlatform> LearningPlatform { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectPlatform> ProjectPlatform { get; set; }
        public DbSet<ProjectCourse> ProjectCourse { get; set; }

        public DbSet<CourseThread> CourseThread { get; set; }

        public DbSet<CourseThreadPost> CourseThreadPost { get; set; }
        


    }
}
