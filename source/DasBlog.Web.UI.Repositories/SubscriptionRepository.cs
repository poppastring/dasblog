using DasBlog.Web.UI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using newtelligence.DasBlog.Web.Services.Rss20;
using newtelligence.DasBlog.Runtime;
using DasBlog.Web.UI.Core;

namespace DasBlog.Web.UI.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private IBlogDataService _dataService;
        private ILoggingDataService _loggingDataService;
        private readonly IDasBlogSettings _dasBlogSettings;

        public SubscriptionRepository(IDasBlogSettings settings)
        {
            _dasBlogSettings = settings;
            _loggingDataService = LoggingDataServiceFactory.GetService(_dasBlogSettings.WebRootPath + _dasBlogSettings.LogsDirectory);
            _dataService = BlogDataServiceFactory.GetService(_dasBlogSettings.WebRootPath + _dasBlogSettings.ContentDirectory, _loggingDataService);
        }

        public RssRoot GetRss()
        {
            throw new NotImplementedException();
        }

        public RssRoot GetRssCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public RssRoot GetAtom()
        {
            throw new NotImplementedException();
        }

        public RssRoot GetAtomCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        //private RssRoot GetRssCore(string category, int maxDayCount, int maxEntryCount)
        //{
        //    EntryCollection entries = null;
        //    //We only build the entries if blogcore doesn't exist and we'll need them later...
        //    if (_dataService.GetLastEntryUpdate() == DateTime.MinValue)
        //    {
        //        entries = BuildEntries(category, maxDayCount, maxEntryCount);
        //    }

        //    //Try to get out as soon as possible with as little CPU as possible
        //    if (inASMX)
        //    {
        //        DateTime lastModified = SiteUtilities.GetLatestModifedEntryDateTime(dataService, entries);
        //        if (SiteUtilities.GetStatusNotModified(lastModified))
        //            return null;
        //    }

        //    if (inASMX)
        //    {
        //        string referrer = Context.Request.UrlReferrer != null ? Context.Request.UrlReferrer.AbsoluteUri : "";
        //        if (ReferralBlackList.IsBlockedReferrer(referrer))
        //        {
        //            if (siteConfig.EnableReferralUrlBlackList404s)
        //            {
        //                return null;
        //            }
        //        }
        //        else
        //        {
        //            loggingService.AddReferral(
        //                new LogDataItem(
        //                Context.Request.RawUrl,
        //                referrer,
        //                Context.Request.UserAgent,
        //                Context.Request.UserHostName));
        //        }
        //    }

        //    //not-modified didn't work, do we have this in cache?
        //    string CacheKey = "Rss:" + category + ":" + maxDayCount.ToString() + ":" + maxEntryCount.ToString();
        //    RssRoot documentRoot = cache[CacheKey] as RssRoot;
        //    if (documentRoot == null) //we'll have to build it...
        //    {
        //        //However, if we made it this far, the not-modified check didn't work, and we may not have entries...
        //        if (entries == null)
        //        {
        //            entries = BuildEntries(category, maxDayCount, maxEntryCount);
        //        }

        //        documentRoot = new RssRoot();
        //        documentRoot.Namespaces.Add("dc", "http://purl.org/dc/elements/1.1/");
        //        documentRoot.Namespaces.Add("trackback", "http://madskills.com/public/xml/rss/module/trackback/");
        //        documentRoot.Namespaces.Add("pingback", "http://madskills.com/public/xml/rss/module/pingback/");
        //        if (siteConfig.EnableComments)
        //        {
        //            documentRoot.Namespaces.Add("wfw", "http://wellformedweb.org/CommentAPI/");
        //            documentRoot.Namespaces.Add("slash", "http://purl.org/rss/1.0/modules/slash/");
        //        }
        //        if (siteConfig.EnableGeoRss)
        //        {
        //            documentRoot.Namespaces.Add("georss", "http://www.georss.org/georss");
        //        }

        //        RssChannel ch = new RssChannel();

        //        if (category == null)
        //        {
        //            ch.Title = siteConfig.Title;
        //        }
        //        else
        //        {
        //            ch.Title = siteConfig.Title + " - " + category;
        //        }

        //        if (siteConfig.Description == null || siteConfig.Description.Trim().Length == 0)
        //        {
        //            ch.Description = siteConfig.Subtitle;
        //        }
        //        else
        //        {
        //            ch.Description = siteConfig.Description;
        //        }

        //        ch.Link = SiteUtilities.GetBaseUrl(siteConfig);
        //        ch.Copyright = siteConfig.Copyright;
        //        if (siteConfig.RssLanguage != null && siteConfig.RssLanguage.Length > 0)
        //        {
        //            ch.Language = siteConfig.RssLanguage;
        //        }
        //        ch.ManagingEditor = siteConfig.Contact;
        //        ch.WebMaster = siteConfig.Contact;
        //        ch.Image = null;
        //        if (siteConfig.ChannelImageUrl != null && siteConfig.ChannelImageUrl.Trim().Length > 0)
        //        {
        //            ChannelImage channelImage = new ChannelImage();
        //            channelImage.Title = ch.Title;
        //            channelImage.Link = ch.Link;
        //            if (siteConfig.ChannelImageUrl.StartsWith("http"))
        //            {
        //                channelImage.Url = siteConfig.ChannelImageUrl;
        //            }
        //            else
        //            {
        //                channelImage.Url = SiteUtilities.RelativeToRoot(siteConfig, siteConfig.ChannelImageUrl);
        //            }
        //            ch.Image = channelImage;
        //        }

        //        documentRoot.Channels.Add(ch);

        //        foreach (Entry entry in entries)
        //        {
        //            if (entry.IsPublic == false || entry.Syndicated == false)
        //            {
        //                continue;
        //            }
        //            XmlDocument doc2 = new XmlDocument();
        //            List<XmlElement> anyElements = new List<XmlElement>();
        //            RssItem item = new RssItem();
        //            item.Title = entry.Title;
        //            item.Guid = new Rss20.Guid();
        //            item.Guid.IsPermaLink = false;
        //            item.Guid.Text = SiteUtilities.GetPermaLinkUrl(siteConfig, entry.EntryId);
        //            item.Link = SiteUtilities.GetPermaLinkUrl(siteConfig, (ITitledEntry)entry);
        //            User user = SiteSecurity.GetUser(entry.Author);

        //            XmlElement trackbackPing = doc2.CreateElement("trackback", "ping", "http://madskills.com/public/xml/rss/module/trackback/");
        //            trackbackPing.InnerText = SiteUtilities.GetTrackbackUrl(siteConfig, entry.EntryId);
        //            anyElements.Add(trackbackPing);

        //            XmlElement pingbackServer = doc2.CreateElement("pingback", "server", "http://madskills.com/public/xml/rss/module/pingback/");
        //            pingbackServer.InnerText = new Uri(new Uri(SiteUtilities.GetBaseUrl(siteConfig)), "pingback.aspx").ToString();
        //            anyElements.Add(pingbackServer);

        //            XmlElement pingbackTarget = doc2.CreateElement("pingback", "target", "http://madskills.com/public/xml/rss/module/pingback/");
        //            pingbackTarget.InnerText = SiteUtilities.GetPermaLinkUrl(siteConfig, entry.EntryId);
        //            anyElements.Add(pingbackTarget);

        //            XmlElement dcCreator = doc2.CreateElement("dc", "creator", "http://purl.org/dc/elements/1.1/");
        //            if (user != null)
        //            {
        //                dcCreator.InnerText = user.DisplayName;
        //            }
        //            anyElements.Add(dcCreator);

        //            // Add GeoRSS if it exists.
        //            if (siteConfig.EnableGeoRss)
        //            {
        //                Nullable<double> latitude = new Nullable<double>();
        //                Nullable<double> longitude = new Nullable<double>();

        //                if (entry.Latitude.HasValue)
        //                {
        //                    latitude = entry.Latitude;
        //                }
        //                else
        //                {
        //                    if (siteConfig.EnableDefaultLatLongForNonGeoCodedPosts)
        //                    {
        //                        latitude = siteConfig.DefaultLatitude;
        //                    }
        //                }

        //                if (entry.Longitude.HasValue)
        //                {
        //                    longitude = entry.Longitude;
        //                }
        //                else
        //                {
        //                    if (siteConfig.EnableDefaultLatLongForNonGeoCodedPosts)
        //                    {
        //                        longitude = siteConfig.DefaultLongitude;
        //                    }
        //                }

        //                if (latitude.HasValue && longitude.HasValue)
        //                {
        //                    XmlElement geoLoc = doc2.CreateElement("georss", "point", "http://www.georss.org/georss");
        //                    geoLoc.InnerText = String.Format(CultureInfo.InvariantCulture, "{0:R} {1:R}", latitude, longitude);
        //                    anyElements.Add(geoLoc);
        //                }
        //            }

        //            if (siteConfig.EnableComments)
        //            {
        //                if (entry.AllowComments)
        //                {
        //                    XmlElement commentApi = doc2.CreateElement("wfw", "comment", "http://wellformedweb.org/CommentAPI/");
        //                    commentApi.InnerText = SiteUtilities.GetCommentViewUrl(siteConfig, entry.EntryId);
        //                    anyElements.Add(commentApi);
        //                }

        //                XmlElement commentRss = doc2.CreateElement("wfw", "commentRss", "http://wellformedweb.org/CommentAPI/");
        //                commentRss.InnerText = SiteUtilities.GetEntryCommentsRssUrl(siteConfig, entry.EntryId);
        //                anyElements.Add(commentRss);

        //                //for RSS conformance per FeedValidator.org
        //                int commentsCount = dataService.GetPublicCommentsFor(entry.EntryId).Count;
        //                if (commentsCount > 0)
        //                {
        //                    XmlElement slashComments = doc2.CreateElement("slash", "comments", "http://purl.org/rss/1.0/modules/slash/");
        //                    slashComments.InnerText = commentsCount.ToString();
        //                    anyElements.Add(slashComments);
        //                }
        //                item.Comments = SiteUtilities.GetCommentViewUrl(siteConfig, entry.EntryId);
        //            }
        //            item.Language = entry.Language;

        //            if (entry.Categories != null && entry.Categories.Length > 0)
        //            {
        //                if (item.Categories == null) item.Categories = new RssCategoryCollection();

        //                string[] cats = entry.Categories.Split(';');
        //                foreach (string c in cats)
        //                {
        //                    RssCategory cat = new RssCategory();
        //                    string cleanCat = c.Replace('|', '/');
        //                    cat.Text = cleanCat;
        //                    item.Categories.Add(cat);
        //                }
        //            }
        //            if (entry.Attachments.Count > 0)
        //            {
        //                // RSS currently supports only a single enclsoure so we return the first one	
        //                item.Enclosure = new Enclosure();
        //                item.Enclosure.Url = SiteUtilities.GetEnclosureLinkUrl(entry.EntryId, entry.Attachments[0]);
        //                item.Enclosure.Type = entry.Attachments[0].Type;
        //                item.Enclosure.Length = entry.Attachments[0].Length.ToString();
        //            }
        //            item.PubDate = entry.CreatedUtc.ToString("R");
        //            if (ch.LastBuildDate == null || ch.LastBuildDate.Length == 0)
        //            {
        //                ch.LastBuildDate = item.PubDate;
        //            }


        //            if (!siteConfig.AlwaysIncludeContentInRSS &&
        //                entry.Description != null &&
        //                entry.Description.Trim().Length > 0)
        //            {
        //                item.Description = PreprocessItemContent(entry.EntryId, entry.Description);

        //            }
        //            else
        //            {
        //                if (siteConfig.HtmlTidyContent == false)
        //                {
        //                    item.Description = "<div>" + PreprocessItemContent(entry.EntryId, entry.Content) + "</div>";
        //                }
        //                else
        //                {
        //                    item.Description = ContentFormatter.FormatContentAsHTML(PreprocessItemContent(entry.EntryId, entry.Content));


        //                    try
        //                    {
        //                        string xhtml = ContentFormatter.FormatContentAsXHTML(PreprocessItemContent(entry.EntryId, entry.Content));
        //                        doc2.LoadXml(xhtml);
        //                        anyElements.Add((XmlElement)doc2.SelectSingleNode("//*[local-name() = 'body'][namespace-uri()='http://www.w3.org/1999/xhtml']"));
        //                    }
        //                    catch //(Exception ex)
        //                    {
        //                        //Debug.Write(ex.ToString());
        //                        // absorb
        //                    }
        //                }
        //            }

        //            item.anyElements = anyElements.ToArray();
        //            ch.Items.Add(item);
        //        }
        //        cache.Insert(CacheKey, documentRoot, DateTime.Now.AddMinutes(5));
        //    }
        //    return documentRoot;
        //}
    }
}
