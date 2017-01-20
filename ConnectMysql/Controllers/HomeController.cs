using ConnectMysql.Content;
using ConnectMysql.Models;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConnectMysql.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        EFContext db = new EFContext();
        public ActionResult Index()
        {
            List<users> list = new List<users>();
            try
            {
                IQueryable<users> a = db.Set<users>();
                IQueryable<CourseThread> b = db.Set<CourseThread>();
                list=a.ToList();
            }
            catch (Exception ex)
            {
                var a = ex.ToString();
            }
            return View(list);
        }

    }
}
