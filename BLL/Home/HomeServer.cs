using EFDLL;
using Models.InputModels.studyPlate;
using Models.project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.courses;
namespace BLL.Home
{
    public class HomeServer
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<LearningPlatform> learningPlatformRepository;
        private Repository<Project> projectRepository;
        private Repository<ProjectPlatform> projectPlatformRepository;
        private Repository<ProjectCourse> projectCourseRepository;
        private Repository<Models.courses.Course> courseRepository;

        public HomeServer()
        {
            learningPlatformRepository = unitOfWork.Repository<LearningPlatform>();
            projectRepository = unitOfWork.Repository<Project>();
            projectPlatformRepository = unitOfWork.Repository<ProjectPlatform>();
            projectCourseRepository = unitOfWork.Repository<ProjectCourse>();
            courseRepository = unitOfWork.Repository<Models.courses.Course>();
        }

        public List<StudyPlatformObj> GetStudyCenter( ref int total,int pageSize = 20,int page=1)
        {
            List<StudyPlatformObj> list = new List<StudyPlatformObj>();
            List<StudyPlatformObj> platformList = (from pp in projectPlatformRepository.GetAll()
                                                   join lp in learningPlatformRepository.GetAll() on pp.PlatformId equals lp.id
                                                   join p in projectRepository.GetAll() on pp.ProjectId equals p.id
                                                   where (p.Status == 1 || p.Status == 3) && lp.IsDel == false
                                                   select new StudyPlatformObj()
                                                   {
                                                       CreateTime = lp.CreateTime,
                                                       ImgPath = lp.ImgPath,
                                                       PlatId = pp.PlatformId,
                                                       Introduction = lp.Introduction,
                                                       PlatName = lp.LearningPlatformName,
                                                       ProjectId = pp.ProjectId,
                                                   }).ToList();
            total = platformList.Count();
            platformList = platformList.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            //前台项目统计课程的时候必须是已经发布的
            List<ProjectCourse> projectCourseList = null;
            var data = from pc in projectCourseRepository.GetAll()
                       join c in courseRepository.GetAll() on pc.CourseId equals c.id
                       where c.status == "published"
                       select pc;
            projectCourseList = data.ToList();
            foreach (var item in platformList)
            {
                item.CourseCount = projectCourseList.Count(d => d.ProjectId == item.ProjectId);
                item.ImgPath = "/Fiels/course/480.jpg";
                list.Add(item);
            }
            return list;
        }
        
    }
}
