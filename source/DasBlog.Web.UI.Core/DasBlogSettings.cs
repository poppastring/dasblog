using System;

namespace DasBlog.Web.UI.Core
{
    public class DasBlogSettings : IDasBlogSettings
    {
        public DasBlogSettings(string logdirectory, string contentdirectory, string theme, string webrootpath)
        {
            Theme = theme;
            ContentDirectory = contentdirectory;
            LogsDirectory = logdirectory;
            WebRootPath = webrootpath;
            ContentLookAheadDays = 2;
            AdjustDisplayTimeZone = false;
            DisplayTimeZoneIndex = 3;
            FrontPageDayCount = 200;
            FrontPageEntryCount = 200;
            EntriesPerPage = 5;
        }

        public string Theme { get; }

        public string LogsDirectory { get; }

        public string ContentDirectory { get; }

        public int ContentLookAheadDays { get; }

        public bool AdjustDisplayTimeZone { get; }

        public int DisplayTimeZoneIndex { get; }

        public int FrontPageDayCount { get; }

        public int FrontPageEntryCount { get; }

        public int EntriesPerPage { get; }

        public string WebRootPath { get; }
    }
}
