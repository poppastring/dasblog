using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using newtelligence.DasBlog.Runtime;
using newtelligence.DasBlog.Web.Core;

namespace DasBlog.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

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
            // var loggingService = LoggingDataServiceFactory.GetService(SiteUtilities.MapPath("~/logs/"));
            // var dataService = BlogDataServiceFactory.GetService(SiteUtilities.MapPath("~/content/"), loggingService);

            // Entry entry = dataService.GetEntry("WeblogEntryId");

            ViewData["Message"] = article;

            //Create views for postname???
            return View();
        }

        // blogpost/comment
        // permalink
        // date (get entries for month/date/etc.)
        // category
        // archive/category
        // archive/month
        // email
        // search
        // timeline ????
        // microsummary ????
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

