using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnLineHotelOs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() /*酒店首页*/
        {
            return View();
        }

        public ActionResult Location() /*酒店位置*/
        {
            return View();
        }

        public ActionResult Introduce() /*酒店介绍*/
        {
            return View();
        }

        public ActionResult Subscrube()/*住房预约*/
        {
            return View();
        }
        public ActionResult Check()/*住房查看*/
        {
            return View();
        }
        public ActionResult About()/*关于我们*/
        {
            return View();
        }
        public ActionResult Contact()/*联系方式*/
        {
            return View();
        }
    }
}