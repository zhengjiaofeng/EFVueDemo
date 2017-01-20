using Demo.Models;
using Repository.Common;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repository.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private UnitOfWork unitOfWork = new UnitOfWork();
        private Repository<UserInfo> userInfoRepository;
        private Repository<CourseThread> courseThreadRepository;
        EFContext ef = new EFContext();

        public HomeController()
        {
            //通过工作单元来初始化仓储
            userInfoRepository = unitOfWork.Repository<UserInfo>();
            courseThreadRepository = unitOfWork.Repository<CourseThread>();
        }
        public ActionResult Index()
        {
            List<UserInfo> list = new List<UserInfo>();
            try
            {
             IQueryable<UserInfo> iQ= userInfoRepository.GetAll();
             IQueryable<CourseThread> ic = courseThreadRepository.GetAll();
             list = iQ.ToList();
             var  A= ic.ToList();
            }
            catch (Exception ex)
            {
                var a = ex.ToString();
            }
            return View(list);
        }

    }
}
