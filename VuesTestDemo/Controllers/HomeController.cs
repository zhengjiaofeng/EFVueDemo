using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VuesTestDemo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FormIndex()
        {
            return View();
        }

        public ActionResult FormTestIndex()
        {
            return View();
        }

        /// <summary>
        /// 指令
        /// </summary>
        /// <returns></returns>
        public ActionResult Directive()
        {
            return View();
        }

        public ActionResult Router()
        {
            return View();
        }

        public ActionResult ExportDemo()
        {
            return View();
        }


    }
}
