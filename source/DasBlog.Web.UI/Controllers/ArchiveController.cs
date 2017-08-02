using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DasBlog.Web.UI.Controllers
{
    public class ArchiveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("archive/{year:int}")]
        public IActionResult Archive(int year)
        {
            return View();
        }

        [Route("archive/{year:int}/{month:int}")]
        public IActionResult Archive(int year, int month)
        {
            return View();
        }
    }
}