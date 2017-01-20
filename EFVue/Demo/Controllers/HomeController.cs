using BLL.User;
using Models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private UserServer userServer;
        public HomeController()
        {
            userServer = new UserServer ();
        }
        //
        // GET: /Home/
        public HomeController(UserServer _userServer)
        {
            userServer = _userServer;
        }
        public ActionResult Index()
        {
            try
            {
                List<users> list = new List<users>();
                list = userServer.GetUserAll().ToList();

            }
            catch (Exception ex)
            {
                var c = ex.ToString();
            }
            
            return View();
        }

    }
}
