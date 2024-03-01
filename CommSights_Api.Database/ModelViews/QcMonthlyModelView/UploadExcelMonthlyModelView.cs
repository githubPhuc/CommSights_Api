using CommSights_Api.Library.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Database.ModelViews.QcMonthlyModelView
{
    public class UploadExcelMonthlyModelView
    {
        public UploadExcelMonthlyModelView()
        {
            ColorCompany = ColorHelper.ColorNone;
            ColorCorpCopy = ColorHelper.ColorNone;
            ColorSoeCorp = ColorHelper.ColorNone;
            ColorFeatureCorp = ColorHelper.ColorNone;
            ColorSentimentCorp = ColorHelper.ColorNone;
            ColorSegmentProduct = ColorHelper.ColorNone;
            ColorProductName = ColorHelper.ColorNone;
            ColorSoeProduct = ColorHelper.ColorNone;
            ColorFeatureProduct = ColorHelper.ColorNone;
            ColorSentimentProduct = ColorHelper.ColorNone;
            ColorHeadline = ColorHelper.ColorNone;
            ColorHeadlineHyperLink = ColorHelper.ColorNone;
            ColorHeadlineEnglish = ColorHelper.ColorNone;
            ColorHeadlineEnglishHyperLink = ColorHelper.ColorNone;
            ColorUrl = ColorHelper.ColorNone;
        }
        public int? Username { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? FileName { get; set; }
        public string? Source { get; set; }
        public string? Date { get; set; }
        public string? MainCategory { get; set; }
        public string? SubCategory { get; set; }
        public string? Company { get; set; }
        public string? ColorCompany { get; set; }
        public string? CorpCopy { get; set; }
        public string? ColorCorpCopy { get; set; }
        public string? SoeCorp { get; set; }
        public string? ColorSoeCorp { get; set; }
        public string? FeatureCorp { get; set; }
        public string? ColorFeatureCorp { get; set; }
        public string? SentimentCorp { get; set; }
        public string? ColorSentimentCorp { get; set; }
        public string? SegmentProduct { get; set; }
        public string? ColorSegmentProduct { get; set; }
        public string? ProductName { get; set; }
        public string? ColorProductName { get; set; }
        public string? SoeProduct { get; set; }
        public string? ColorSoeProduct { get; set; }
        public string? FeatureProduct { get; set; }
        public string? ColorFeatureProduct { get; set; }
        public string? SentimentProduct { get; set; }
        public string? ColorSentimentProduct { get; set; }
        public string? Headline { get; set; }
        public string? ColorHeadline { get; set; }
        public string? HeadlineHyperLink { get; set; }
        public string? ColorHeadlineHyperLink { get; set; }
        public string? HeadlineEnglish { get; set; }
        public string? ColorHeadlineEnglish { get; set; }
        public string? HeadlineEnglishHyperLink { get; set; }
        public string? ColorHeadlineEnglishHyperLink { get; set; }
        public string? Url { get; set; }
        public string? ColorUrl { get; set; }
        public string? Page { get; set; }
        public string? Duration { get; set; }
        public string? Journalist { get; set; }
        public string? TierCommSights { get; set; }
        public string? TierCustomer { get; set; }
        public string? SpokePersonName { get; set; }
        public string? SpokePersonTitle { get; set; }
        public string? ToneValue { get; set; }
        public string? HeadlineValue { get; set; }
        public string? SpokePersonValue { get; set; }
        public string? FeatureValue { get; set; }
        public string? TierValue { get; set; }
        public string? PictureValue { get; set; }
        public string? Mps { get; set; }
        public string? RomeCorp { get; set; }
        public string? RomeProduct { get; set; }
        public string? MediaTitle { get; set; }
        public string? MediaType { get; set; }
        public string? Advalue { get; set; }
    }
}
