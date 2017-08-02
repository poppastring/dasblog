using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DasBlog.Web.UI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("category/{cat}")]
        public IActionResult Index(string cat)
        {
            return View("Index.chtml");
        }
    }
}