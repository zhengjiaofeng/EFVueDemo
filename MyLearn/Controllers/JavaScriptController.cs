using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyLearn.Controllers
{
    public class JavaScriptController : Controller
    {
        //
        // GET: /JavaScript/

        public ActionResult Index()
        {
            var a = test();
            
            return View();
        }

        public int test()
        {
            var a = 1;
            var b = 1;
            try
            {
                return a = 2;
            }

            catch (Exception ex)
            {

            }

            finally
            {
                b = 2;
            }

            return b;
        }

    }
}
