using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Async;

namespace MyLearn.Controllers
{
    public class SendMailController : Controller
    {
        public static DateTime time = DateTime.Now;
        //
        // GET: /SendMail/

        public ActionResult Index()
        {
            return View();
        }

      public static  AsyncManager a = new AsyncManager();
      public Task<JsonResult> Send()
        {
            string fromEmail="frank@newv.com.cn";
            string fromName="深圳新为软件股份有限公司"; string toEmail="otis@newv.com.cn";
            string subject = "找回密码" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string body="<div><p style='margin-top:20px;'>找回你在SmartUFO的密码</p><p style='margin-top:30px;'>&nbsp;&nbsp;&nbsp;&nbsp;您的用户名为:<span style=' color:#F3750F; font-weight:bold; font-size:16px;'>otis1</span></p><p style='margin-top:30px;'>&nbsp;&nbsp;&nbsp;&nbsp;请马上点击以下链接找回您的密码:  <a href='http://192.168.2.12:8013/Account/UpdatePwd/?Key=b3RpczF8b3Rpc0BuZXd2LmNvbS5jbg==&getstring=MjAxNi0xMS0yOCAxNDo0Mzo0MQ=='>http://192.168.2.12:8013/Account/UpdatePwd/?Key=b3RpczF8b3Rpc0BuZXd2LmNvbS5jbg==&getstring=MjAxNi0xMS0yOCAxNDo0Mzo0MQ==</a>  </p><br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;注意:请您在收到邮件1小时内使用，否则该链接将会失效。<br/><br/>&nbsp;&nbsp;&nbsp;&nbsp;我们将一如既往、热忱的为您服务！<br/><br/></div>";
            var result = SendEmailAsync(fromEmail, fromName, toEmail, subject, body);
            return null;
            //return Json(result, JsonRequestBehavior.AllowGet);
        }
        private async Task<string> SendEmailAsync(string fromEmail, string fromName, string toEmail, string subject, string body)
        {
           // MailAddress addrFrom = new MailAddress(fromEmail, fromEmail);
            MailAddress addrFrom = new MailAddress(fromEmail, fromName, Encoding.UTF8);
            MailAddress addrTo = new MailAddress(toEmail, toEmail);
            MailMessage mm = new MailMessage(addrFrom, addrTo);
            mm.BodyEncoding = Encoding.UTF8;
            mm.IsBodyHtml = true;
            mm.Subject = subject;
            mm.Body = body;

            string fromPwd = "";
            NetworkCredential nc = new NetworkCredential(fromEmail, fromPwd);
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = nc;
            smtp.EnableSsl = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Host = "mail.newv.com.cn";
            try
            {
                smtp.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                time = DateTime.Now;
                smtp.SendAsync(mm, "");
                return "true";
            }
            catch (Exception ex)
            {
                var c = ex.ToString();
                return "false";
            }

            //if (mailSent == false)
            //{

            //    smtp.SendAsyncCancel();
            //}

            
        }

        static bool mailSent = false;
        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // 告诉ASP.NET MVC，一个异步操作结束了。
            a.OutstandingOperations.Decrement();

            String token = (string)e.UserState;

            int endTime = DateTime.Now.Second;
            int startTime = time.Second;
             
            mailSent = true;

             
        }





    }
}
