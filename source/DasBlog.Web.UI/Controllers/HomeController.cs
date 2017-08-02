using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DasBlog.Web.UI.Models;
using newtelligence.DasBlog.Runtime;
using newtelligence.DasBlog.Web.Core;
using DasBlog.Web.UI.Models.BlogViewModels;

namespace DasBlog.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogDataService _dataService;
        private ILoggingDataService _loggingDataService;

        public HomeController(IBlogDataService dataService, ILoggingDataService loggingDataService)
        {
            _dataService = dataService;
            _loggingDataService = loggingDataService;
        }

        public IActionResult Index()
        {
            var loggingService = LoggingDataServiceFactory.GetService("D:\\GitHub\\poppastring-dasblog\\dasblog\\source\\DasBlog.Web.UI\\logs\\");
            var dataService = BlogDataServiceFactory.GetService("D:\\GitHub\\poppastring-dasblog\\dasblog\\source\\DasBlog.Web.UI\\content\\", loggingService);

            // Get post by GUID
            var entryGuid = dataService.GetEntry("bbecae4b-e3a3-47a2-b6a6-b4cc405f8663");

            // Get post by title
            // ~/CommentView.aspx?title=MoralMachineTheProblemIsChoice
            var entryComment = dataService.GetEntry("GeneralPatternsusedtoDetectaLeak");


            // Get post by Date and title
            // ~/Permalink.aspx?title=MoralMachineTheProblemIsChoice
            DayEntry dayEntry = dataService.GetDayEntry(new DateTime(2016, 10, 13));
            var entryPermalink = dayEntry.GetEntryByTitle("GeneralPatternsusedtoDetectaLeak");            

            // Get all entries Archives
            var entries = dataService.GetEntries(false);

            // Month View
            string languageFilter = Request.Headers["Accept-Language"];
            var daysWithEntries = dataService.GetDaysWithEntries(TimeZone.CurrentTimeZone);

            //Initial page content ?????

            return View();
        }
		
        [Route("page/{index:int}")]
        public IActionResult Page(int index)
        {
            ViewData["Message"] = string.Format("Page {0}.", index);

            ListPostsViewModel list = new ListPostsViewModel();
            list.Posts = new List<PostViewModel>()
                {
                    new PostViewModel
                    {
                        Author = "Mark Downie",
                        Body = "This is the body of the something that we need, give me the beat... or not at the case may be. We are not relying on knowledge!",
                        Categories = "Categories",
                        Comment = "Comment",
                        Description = "Description",
                        Email = "mdownie@poppastring.com",
                        Guid = "123-134-2341234-1324-123412",
                        NextPost = "http://www.poppastring.com/blog/blog-title2",
                        PermaLink = "http://www.poppastring.com/blog/blog-title",
                        PreviousPost = "http://www.poppastring.com/blog/blog-title0",
                        Text = "text",
                        Title = "Blog Title"
                    },
                    new PostViewModel
                    {
                        Author = "Mark Downie",
                        Body = "This is the body of the something that we need, give me the beat... or not at the case may be. We are not relying on knowledge!",
                        Categories = "Categories",
                        Comment = "Comment",
                        Description = "Description",
                        Email = "mdownie@poppastring.com",
                        Guid = "123-134-2341234-1324-123412",
                        NextPost = "http://www.poppastring.com/blog/blog-title2",
                        PermaLink = "http://www.poppastring.com/blog/blog-title",
                        PreviousPost = "http://www.poppastring.com/blog/blog-title0",
                        Text = "text",
                        Title = "Blog Title"
                    },
                    new PostViewModel
                    {
                        Author = "Mark Downie",
                        Body = "This is the body of the something that we need, give me the beat... or not at the case may be. We are not relying on knowledge!",
                        Categories = "Categories",
                        Comment = "Comment",
                        Description = "Description",
                        Email = "mdownie@poppastring.com",
                        Guid = "123-134-2341234-1324-123412",
                        NextPost = "http://www.poppastring.com/blog/blog-title2",
                        PermaLink = "http://www.poppastring.com/blog/blog-title",
                        PreviousPost = "http://www.poppastring.com/blog/blog-title0",
                        Text = "text",
                        Title = "Blog Title"
                    }
                };

            return View(list);
        }
		
        [Route("comment/{index:guid}")]
        public IActionResult Comment(Guid Id)
        {
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

