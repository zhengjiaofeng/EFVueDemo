using BLL.Home;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace VueDemo.Controllers
{
    public class HomeController : Controller
    {
        private HomeServer homeServer;
        public HomeController()
        {
            homeServer = new HomeServer();
        }
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetStudyCenter(int pageSize=20,int page=1)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            bool isSuccess = false;
            try
            {
                int total=0;
                var list = homeServer.GetStudyCenter(ref  total, pageSize, page);
                isSuccess=true;
                int totalPage = (total / 20) > 0 ? total / 20 + 1 : 1;
                dic.Add("totalPage", totalPage);
                dic.Add("row", list);
                dic.Add("isSuccess", isSuccess);
            }
            catch (Exception ex)
            {
                var a = ex.ToString();
                dic.Add("isSuccess", isSuccess);
            }
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

    }
}
