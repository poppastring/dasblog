using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DasBlog.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        // Main Page
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Page(int page)
        {
            // 0 = main page

            return View();
        }

        // Individual Page + Comment View
        public IActionResult BlogPost(string article)
        {
            ViewData["Message"] = article;

            //Create views for postname???
            return View();
        }

        // blogpost/comment
        // category
        // archive/category
        // archive/month
        // email
        // search
        // timeline ????
        // sitemap
        // rss
        // atom



        public IActionResult Login()
        {
            ViewData["Message"] = "Your application login page.";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
