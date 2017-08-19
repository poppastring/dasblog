using System;
using System.Collections.Generic;
using System.Text;

namespace DasBlog.Web.UI.Core
{
    public interface IDasBlogSettings
    {
        string Theme { get; }
        string LogsDirectory { get; }
        string WebRootPath { get; }
        string ContentDirectory { get; }
        int ContentLookAheadDays { get; }
        bool AdjustDisplayTimeZone { get; }
        int DisplayTimeZoneIndex { get; }
        int FrontPageDayCount { get; }
        int FrontPageEntryCount { get; }
        int EntriesPerPage { get; }
    }
}
