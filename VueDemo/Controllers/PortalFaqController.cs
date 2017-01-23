using BLL.Courses;
using Models.InputModels.courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VueDemo.Controllers
{
    public class PortalFaqController : Controller
    {
        //
        // GET: /PortalFaq/
        private CouseThreadServer couseThreadServer;
        public PortalFaqController()
        {
            couseThreadServer = new CouseThreadServer();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CourseThreadDetail(string treadId)
        {
            ViewBag.treadId = treadId;
            return View();
        }

        public JsonResult GetCourseThreadDetailList(string threadId)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            bool isSuccess = false;
            try
            {
                int total = 0;
                var detailList = couseThreadServer.GetCourseThreadDetailList(threadId, total, ref total);
                var courseThread = couseThreadServer.GetCourseThread(threadId);
                isSuccess = true;
                dic.Add("total", total);
                dic.Add("detailList", detailList);
                dic.Add("courseThread", courseThread);
                dic.Add("isSuccess", isSuccess);
            }
            catch (Exception ex)
            {
                isSuccess = false;
                dic.Add("isSuccess", isSuccess);
            }
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseThreadList(string type, int page = 1, int pageSize = 20)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            bool isSuccess = false;
            try
            {
                int total = 0;
                var list = couseThreadServer.GetCourseThreadList(type, ref total, page, pageSize);
                isSuccess = true;
                dic.Add("totalPage", total / 10 > 0 ? total / 10 + 1 : 1);
                dic.Add("row", list);
                dic.Add("isSuccess", isSuccess);
            }
            catch (Exception ex)
            {
                isSuccess = false;
                dic.Add("isSuccess", isSuccess);
            }
            return Json(dic, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetCourseAllCount()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            bool isSuccess = false;
            try
            {
                int allTotal = 0;
                int questionTotal = 0;
                int discussionTotal = 0;
                var allCount = couseThreadServer.GetCourseThreadList("all", ref allTotal);
                dic.Add("allCount", allTotal);
                var questionCount = couseThreadServer.GetCourseThreadList("question", ref questionTotal);
                dic.Add("questionCount", questionTotal);
                var discussionCount = couseThreadServer.GetCourseThreadList("discussion", ref discussionTotal);
                dic.Add("discussionCount", discussionTotal);
                isSuccess = true;
                dic.Add("isSuccess", isSuccess);
            }
            catch (Exception ex)
            {
                isSuccess = false;
                dic.Add("isSuccess", isSuccess);
            }
            return Json(dic, JsonRequestBehavior.AllowGet);
        }
        [ValidateInput(false)]
        public JsonResult AddCourseThread()
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            bool isSuccess = false;
            try
            {
                CourseThreadInputDto input = new CourseThreadInputDto();
                input.userId = "3f92c97e-2dad-4a41-8ad5-f5d246b49a68";
                input.type = "question";
                input.title = Request.Params["title"];
                input.content = Server.UrlDecode(Request.Params["content"]);
                input.LearningPlatformId = "e6f7336e-d11a-45d5-9a66-cad9a97c9210";
                var a = couseThreadServer.AddCourseThread(input);
                isSuccess = a.Result;
                dic.Add("isSuccess", isSuccess);
            }
            catch (Exception ex)
            {
                isSuccess = false;
                dic.Add("isSuccess", isSuccess);
            }
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

    }
}
