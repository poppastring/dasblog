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
using Microsoft.Extensions.Options;

namespace DasBlog.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogDataService _dataService;
        private ILoggingDataService _loggingDataService;
        private readonly DasBlogSettings _dasBlogsettings;

        public HomeController(IOptions<DasBlogSettings> appSettings)
        {
            _dasBlogsettings = appSettings.Value;
            _loggingDataService = LoggingDataServiceFactory.GetService(_dasBlogsettings.Logs);
            _dataService = BlogDataServiceFactory.GetService(_dasBlogsettings.Content, _loggingDataService);
        }

        public IActionResult Index()
        {
            // Get post by title
            // ~/CommentView.aspx?title=MoralMachineTheProblemIsChoice
            var entryComment = _dataService.GetEntry("GeneralPatternsusedtoDetectaLeak");


            // Get post by Date and title
            // ~/Permalink.aspx?title=MoralMachineTheProblemIsChoice
            DayEntry dayEntry = _dataService.GetDayEntry(new DateTime(2016, 10, 13));
            var entryPermalink = dayEntry.GetEntryByTitle("GeneralPatternsusedtoDetectaLeak");            

            // Get all entries Archives
            var entries = _dataService.GetEntries(false);

            // Month View
            string languageFilter = Request.Headers["Accept-Language"];
            var daysWithEntries = _dataService.GetDaysWithEntries(TimeZone.CurrentTimeZone);

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
                        Content = "This is the body of the something that we need, give me the beat... or not at the case may be. We are not relying on knowledge!",
                        Categories = "Categories",
                        Description = "Description",
                        EntryId = "123-134-2341234-1324-123412",
                        PermaLink = "http://www.poppastring.com/blog/blog-title",
                        Title = "Blog Title"
                    },
                    new PostViewModel
                    {
                        Author = "Mark Downie",
                        Content = "This is the body of the something that we need, give me the beat... or not at the case may be. We are not relying on knowledge!",
                        Categories = "Categories",
                        Description = "Description",
                        EntryId = "123-134-2341234-1324-123412",
                        PermaLink = "http://www.poppastring.com/blog/blog-title",
                        Title = "Blog Title"
                    },
                    new PostViewModel
                    {
                        Author = "Mark Downie",
                        Content = "This is the body of the something that we need, give me the beat... or not at the case may be. We are not relying on knowledge!",
                        Categories = "Categories",
                        Description = "Description",
                        EntryId = "123-134-2341234-1324-123412",
                        PermaLink = "http://www.poppastring.com/blog/blog-title",
                        Title = "Blog Title"
                    }
                };

            return View(list);
        }
		
        [Route("comment/{Id:guid}")]
        public IActionResult Comment(Guid Id)
        {
            // Get post by GUID bbecae4b-e3a3-47a2-b6a6-b4cc405f8663
            Entry entry = _dataService.GetEntry(Id.ToString());

            ListPostsViewModel lvpm = new ListPostsViewModel();
            lvpm.Posts = new List<PostViewModel> {
                    new PostViewModel
                    {
                        Author = entry.Author,
                        Content = entry.Content,
                        Categories = entry.Categories,
                        Description = entry.Description,
                        EntryId = entry.EntryId,
                        AllowComments = entry.AllowComments,
                        IsPublic = entry.IsPublic,
                        PermaLink = entry.Link,
                        Title = entry.Title
                    }
                };

            ViewData["Message"] = "Comment...";
            
            return View(string.Format("/Themes/{0}/Page.cshtml", _dasBlogsettings.Theme), lvpm);
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

