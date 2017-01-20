using Demo.Common;
using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        AccountContext db = new AccountContext();
        public ActionResult Index()
        {
            List<UserInfo> list = new List<UserInfo>();
            try
            {
                UserInfo model = new UserInfo();
                model.id = Guid.NewGuid();
                model.userName = "峰1";
                db.UserInfo.Add(model);
                db.SaveChanges();

                IQueryable<UserInfo> Iq = db.UserInfo.OrderBy(d => d.id);
                list = Iq.ToList();
            }
            catch (Exception ex)
            {
                var a = ex.ToString();
            }
            
            return View(list);
        }

        

        

    }
}
