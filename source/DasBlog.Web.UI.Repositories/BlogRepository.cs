using System;
using System.Collections.Generic;
using System.Text;
using newtelligence.DasBlog.Runtime;
using DasBlog.Web.UI.Repositories.Interfaces;
using DasBlog.Web.UI.Core;
using newtelligence.DasBlog.Util;

namespace DasBlog.Web.UI.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private IBlogDataService _dataService;
        private ILoggingDataService _loggingDataService;
        private readonly IDasBlogSettings _dasBlogSettings;

        public BlogRepository(IDasBlogSettings settings)
        {
            _dasBlogSettings = settings;
            _loggingDataService = LoggingDataServiceFactory.GetService(_dasBlogSettings.WebRootPath + _dasBlogSettings.LogsDirectory);
            _dataService = BlogDataServiceFactory.GetService(_dasBlogSettings.WebRootPath + _dasBlogSettings.ContentDirectory, _loggingDataService);
        }

        public Entry GetBlogPost(string postid)
        {
            return _dataService.GetEntry(postid);
        }

        public EntryCollection GetFrontPagePosts()
        {
            DateTime fpDayUtc;
            TimeZone tz;

            //Need to insert the Request.Headers["Accept-Language"];
            string languageFilter = "en-US"; // Request.Headers["Accept-Language"];
            fpDayUtc = DateTime.UtcNow.AddDays(_dasBlogSettings.ContentLookAheadDays);

            if (_dasBlogSettings.AdjustDisplayTimeZone)
            {
                tz = WindowsTimeZone.TimeZones.GetByZoneIndex(_dasBlogSettings.DisplayTimeZoneIndex);
            }
            else
            {
                tz = new UTCTimeZone();
            }

            return _dataService.GetEntriesForDay(fpDayUtc, TimeZone.CurrentTimeZone,
                                languageFilter,
                                _dasBlogSettings.FrontPageDayCount, _dasBlogSettings.FrontPageEntryCount, string.Empty);
        }

        public EntryCollection GetEntriesForPage(int pageIndex)
        {
            Predicate<Entry> pred = null;

            //Shallow copy as we're going to modify it...and we don't want to modify THE cache.
            EntryCollection cache = _dataService.GetEntries(null, pred, Int32.MaxValue, Int32.MaxValue);

            // remove the posts from the front page
            EntryCollection fp = GetFrontPagePosts();

            cache.RemoveRange(0, fp.Count);

            int entriesPerPage = _dasBlogSettings.EntriesPerPage;

            // compensate for frontpage
            if ((pageIndex - 1) * entriesPerPage < cache.Count)
            {
                // Remove all entries before the current page's first entry.
                int end = (pageIndex - 1) * entriesPerPage;
                cache.RemoveRange(0, end);

                // Remove all entries after the page's last entry.
                if (cache.Count - entriesPerPage > 0)
                {
                    cache.RemoveRange(entriesPerPage, cache.Count - entriesPerPage);
                    // should match
                    bool postCount = cache.Count <= entriesPerPage;
                }

                return _dataService.GetEntries(null, EntryCollectionFilter.DefaultFilters.IsInEntryIdCacheEntryCollection(cache),
                    Int32.MaxValue,
                    Int32.MaxValue);
            }

            // The page index is out of range (i.e. too large).
            return new EntryCollection();
        }

    }
}
