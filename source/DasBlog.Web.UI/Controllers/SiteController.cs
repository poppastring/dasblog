using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DasBlog.Web.UI.Controllers
{
    [Produces("text/xml")]
    public class SiteController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }
    }
}