using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DasBlog.Web.UI.Controllers
{
    public class FeedController : Controller
    {
        public IActionResult Index()
        {
            return Rss();
        }

        public IActionResult Rss()
        {
            return View();
        }

        public IActionResult Rss(string category)
        {
            return View();
        }

        public IActionResult Atom()
        {
            return View();
        }

        public IActionResult Atom(string category)
        {
            return View();
        }

        public ActionResult Rsd()
        {
            return View();
        }
    }
}