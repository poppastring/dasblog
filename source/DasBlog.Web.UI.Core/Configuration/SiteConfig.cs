﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using newtelligence.DasBlog.Runtime;
using newtelligence.DasBlog.Web.Core;

namespace DasBlog.Web.UI.Core.Configuration
{
    public class SiteConfig : ISiteConfig
    {
        public SiteConfig()
        {

        }

        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Theme { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Root { get; set; }
        public string Copyright { get; set; }
        public int RssDayCount { get; set; }
        public int RssMainEntryCount { get; set; }
        public int RssEntryCount { get; set; }
        public bool EnableRssItemFooters { get; set; }
        public string RssItemFooter { get; set; }
        public int FrontPageDayCount { get; set; }
        public int FrontPageEntryCount { get; set; }
        public bool CategoryAllEntries { get; set; }
        public string FrontPageCategory { get; set; }
        public bool AlwaysIncludeContentInRSS { get; set; }
        public bool EntryTitleAsLink { get; set; }
        public bool ObfuscateEmail { get; set; }
        public string NotificationEMailAddress { get; set; }
        public bool SendCommentsByEmail { get; set; }
        public bool SendReferralsByEmail { get; set; }
        public bool SendTrackbacksByEmail { get; set; }
        public bool SendPingbacksByEmail { get; set; }
        public bool SendPostsByEmail { get; set; }
        public bool EnableBloggerApi { get; set; }
        public bool EnableComments { get; set; }
        public bool EnableCommentApi { get; set; }
        public bool EnableConfigEditService { get; set; }
        public bool EnableEditService { get; set; }
        public bool EnableAutoPingback { get; set; }
        public bool ShowCommentCount { get; set; }
        public bool EnableTrackbackService { get; set; }
        public bool EnablePingbackService { get; set; }
        public bool EnableStartPageCaching { get; set; }
        public bool EnableBlogrollDescription { get; set; }
        public bool EnableUrlRewriting { get; set; }
        public bool EnableCrossposts { get; set; }
        public bool UseUserCulture { get; set; }
        public bool ShowItemDescriptionInAggregatedViews { get; set; }
        public bool EnableClickThrough { get; set; }
        public bool EnableAggregatorBugging { get; set; }
        public int DisplayTimeZoneIndex { get; set; }
        public bool AdjustDisplayTimeZone { get; set; }
        public string EditPassword { get; set; }
        public string ContentDir { get; set; }
        public string LogDir { get; set; }
        public string BinariesDir { get; set; }
        public string ProfilesDir { get; set; }
        public string BinariesDirRelative { get; set; }
        public string SmtpServer { get; set; }
        public bool EnablePop3 { get; set; }
        public string Pop3Server { get; set; }
        public string Pop3Username { get; set; }
        public string Pop3Password { get; set; }
        public string Pop3SubjectPrefix { get; set; }
        public int Pop3Interval { get; set; }
        public bool Pop3InlineAttachedPictures { get; set; }
        public int Pop3InlinedAttachedPicturesThumbHeight { get; set; }
        public bool ApplyContentFiltersToWeb { get; set; }
        public bool ApplyContentFiltersToRSS { get; set; }
        public bool EnableXSSUpstream { get; set; }
        public string XSSUpstreamEndpoint { get; set; }
        public string XSSUpstreamUsername { get; set; }
        public string XSSUpstreamPassword { get; set; }
        public string XSSRSSFilename { get; set; }
        public int XSSUpstreamInterval { get; set; }
        public ContentFilterCollection ContentFilters { get; set; }
        public ContentFilter[] ContentFilterArray { get; set; }
        public CrosspostSiteCollection CrosspostSites { get; set; }
        public CrosspostSite[] CrosspostSiteArray { get; set; }
        public bool Pop3DeleteAllMessages { get; set; }
        public bool Pop3LogIgnoredEmails { get; set; }
        public bool EnableReferralUrlBlackList { get; set; }
        public string ReferralUrlBlackList { get; set; }
        public string[] ReferralUrlBlackListArray { get; set; }
        public bool EnableCaptcha { get; set; }
        public bool EnableReferralUrlBlackList404s { get; set; }
        public bool EnableMovableTypeBlackList { get; set; }
        public string ChannelImageUrl { get; set; }
        public bool EnableCrossPostFooter { get; set; }
        public string CrossPostFooter { get; set; }
        public bool ExtensionlessUrls { get; set; }
        public bool EnableTitlePermaLink { get; set; }
        public bool EnableTitlePermaLinkUnique { get; set; }
        public bool EnableTitlePermaLinkSpaces { get; set; }
        public bool EncryptLoginPassword { get; set; }
        public bool EnableSmtpAuthentication { get; set; }
        public string SmtpUserName { get; set; }
        public string SmtpPassword { get; set; }
        public string RssLanguage { get; set; }
        public bool EnableSearchHighlight { get; set; }
        public bool EnableEntryReferrals { get; set; }
        public PingService[] PingServiceArray { get; set; }
        public PingServiceCollection PingServices { get; set; }
        public string FeedBurnerName { get; set; }
        public int DaysCommentsAllowed { get; set; }
        public bool EnableCommentDays { get; set; }
        public bool SupressEmailAddressDisplay { get; set; }
        public string EntryEditControl { get; set; }
        public bool LogBlockedReferrals { get; set; }
        public bool ShowCommentsWhenViewingEntry { get; set; }
        public bool UseFeedSchemeForSyndication { get; set; }
        public int ContentLookaheadDays { get; set; }
        public bool EnableAutoSave { get; set; }
        public int SmtpPort { get; set; }
        public bool CommentsAllowGravatar { get; set; }
        public string CommentsGravatarNoImgPath { get; set; }
        public string CommentsGravatarSize { get; set; }
        public string CommentsGravatarBorder { get; set; }
        public string CommentsGravatarRating { get; set; }
        public bool CommentsRequireApproval { get; set; }
        public bool CommentsAllowHtml { get; set; }
        public ValidTagCollection XmlAllowedTagsArray { get; set; }
        public ValidTagCollection AllowedTags { get; set; }
        public string XmlAllowedTags { get; set; }
        public bool EnableCoComment { get; set; }
        public bool EnableSpamBlockingService { get; set; }
        public string SpamBlockingServiceApiKey { get; set; }
        public ISpamBlockingService SpamBlockingService { get; set; }
        public bool EnableSpamModeration { get; set; }
        public int EntriesPerPage { get; set; }
        public bool EnableDailyReportEmail { get; set; }
        public bool UseSSLForSMTP { get; set; }
        public string PreferredBloggingAPI { get; set; }
        public bool EnableGoogleMaps { get; set; }
        public string GoogleMapsApiKey { get; set; }
        public bool EnableGeoRss { get; set; }
        public double DefaultLatitude { get; set; }
        public double DefaultLongitude { get; set; }
        public bool EnableDefaultLatLongForNonGeoCodedPosts { get; set; }
        public bool HtmlTidyContent { get; set; }
        public bool ResolveCommenterIP { get; set; }
        public bool AllowOpenIdComments { get; set; }
        public bool AllowOpenIdAdmin { get; set; }
        public bool BypassSpamOpenIdComment { get; set; }
        public string TitlePermalinkSpaceReplacement { get; set; }
        public bool AMPPagesEnabled { get; set; }
        public string RSSEndPointRewrite { get; set; }
        public string CheesySpamQ { get; set; }
        public string CheesySpamA { get; set; }
        public XmlElement[] anyElements { get; set; }
        public XmlAttribute[] anyAttributes { get; set; }
    }
}
