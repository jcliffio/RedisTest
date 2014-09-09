using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RedisClientProject;
using RedisTest.Models.Home;

namespace RedisTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var redisClient = new RedisClient();

            redisClient.SetStringByKey("jcliffio:test-time", DateTime.Now.ToString());

            var cachedTime = redisClient.GetStringByKey("jcliffio:test-time");

            var indexViewModel = new IndexViewModel
            {
                CachedTime = cachedTime
            };

            return View(indexViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}