using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;
using DasBlog.Web.UI.Repositories.Interfaces;
using newtelligence.DasBlog.Web.Services.Rss20;

namespace DasBlog.Web.UI.Controllers
{
    [Produces("text/xml")]
    [Route("feed")]
    public class FeedController : Controller
    {
        private IMemoryCache _cache;
        private ISubscriptionRepository _subscriptionRepository;
        private const string RSS_CACHE_KEY = "RSS_CACHE_KEY";

        public FeedController(ISubscriptionRepository subscriptionRepository, IMemoryCache memoryCache)
        {
            _subscriptionRepository = subscriptionRepository;
            _cache = memoryCache;
        }

        [HttpGet]
        [Route("")]
        [Route("rss")]
        public IActionResult Rss()
        {
            RssRoot rss = null; 

            if (!_cache.TryGetValue(RSS_CACHE_KEY, out rss))
            {
                rss = _subscriptionRepository.GetRss();

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _cache.Set(RSS_CACHE_KEY, rss, cacheEntryOptions);
            }

            return Ok(rss);
        }

        [HttpGet("rss/{category}")]
        public IActionResult RssByCategory(string category)
        {
            RssRoot rss = null;

            if (!_cache.TryGetValue(RSS_CACHE_KEY + "_" + category, out rss))
            {
                rss = _subscriptionRepository.GetRssCategory(category);

                var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(5));

                _cache.Set(RSS_CACHE_KEY + "_" + category, rss, cacheEntryOptions);
            }

            return Ok(rss);
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