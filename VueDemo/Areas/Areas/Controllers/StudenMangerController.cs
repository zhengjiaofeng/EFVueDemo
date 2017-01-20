using BLL.User;
using Models.InputModels.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VueDemo.Areas.Areas.Controllers
{
    public class StudenMangerController : Controller
    {
        private UserServer userService;
        //
        // GET: /Areas/StudenManger/
        public StudenMangerController()
        {
            userService = new UserServer();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VueTableIndex()
        {
            return View();
        }

        public ActionResult ExportDefaultIndex()
        {
            return View();
        }
        public ActionResult edit()
        {
            return View();
        }

        public JsonResult GetUserStudenList(string searchQuery, int currentPage = 1, int page = 10)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            try
            {
                int total = 0;
                var list = userService.GetStudenUserList(searchQuery,currentPage, page, out total);
                dic.Add("row", list);
                dic.Add("total", total % 10 > 0 ? total / 10 + 1 : total / 10);
                dic.Add("currentPage", currentPage);
            }
            catch (Exception ex)
            {
                var a = ex.ToString();
            }
            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 查询一条
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult GetStudentUserById(Guid id)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            bool isSuccess = false;
            try
            {
                var list = userService.GetStudentUserById(id);
                isSuccess = true;
                dic.Add("row", list);
                dic.Add("isSuccess", isSuccess);
            }
            catch (Exception ex)
            {
                dic.Add("isSuccess", isSuccess);
            }

            return Json(dic, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public JsonResult UpdateStudentUser(studenUserView input)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            bool isSuccess = false;
            try
            {
                input.is_graduation = false;
                userService.UpdateStudentUser(input);
                isSuccess = true;
                dic.Add("isSuccess", isSuccess);
            }
            catch (Exception ex)
            {
                dic.Add("isSuccess", isSuccess);
            }

            return Json(dic, JsonRequestBehavior.AllowGet);
        }

    }
}
