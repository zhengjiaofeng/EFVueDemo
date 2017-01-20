using MyLearn.Content;
using MyLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MyLearn.Controllers
{
    public class SendPhoneCodeController : Controller
    {
        //
        // GET: /SendPhoneCode/
        SendPhoneCode sendPhone = new SendPhoneCode();

        SendCode sc = new SendCode();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult SendMessage()
        {
            var IsSuccess = false;
            string phone = "15880213971";
           // string msg = "【新为软件】您的验证码是" + GetRand() + ",在5分钟内有效。如非本人操作请忽略本短信";
            string msg = string.Format("{0}为您的登录动态密码，请于{1}分钟内填写。如非本人操作，请忽略本短信。", GetRand(), 5);
           // string msg = string.Format("{0}为您的验证码，请于{1}分钟内填写。如非本人操作，请忽略本短信。", GetRand(), 5);
            try
            {
               // var result = sendPhone.SendSmsCode(phone, msg);
                var result = sc.SendSmsCode(phone, msg);
                if (result.Result.result == "0")
                {
                    IsSuccess = true;
                }
            }
            catch (Exception ex)
            {

            }
            return Json(IsSuccess,JsonRequestBehavior.AllowGet);
        }

        private int GetRand()
        {
            Random r = new Random();
            //string str = string.Empty;
            //string[] strArr = {  "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            //for (var i = 0; i < 6; i++)
            //{
            //    int index = r.Next(strArr.Length);
            //    str += strArr[index];
            //}
            var str = r.Next(100000, 1000000);
            return str;

        }

    }
}
