using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class Product
    {
        public int Id { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? ParentId { get; set; }
        public string? Note { get; set; }
        public bool? Active { get; set; }
        public int? CategoryId { get; set; }
        public string? Title { get; set; }
        public string? Urlcode { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaKeyword { get; set; }
        public string? MetaDescription { get; set; }
        public string? Tags { get; set; }
        public string? Author { get; set; }
        public string? Image { get; set; }
        public string? ImageThumbnail { get; set; }
        public string? Description { get; set; }
        public string? ContentMain { get; set; }
        public decimal? Price { get; set; }
        public int? PriceUnitId { get; set; }
        public DateTime? DatePublish { get; set; }
        public string? Page { get; set; }
        public string? TitleEnglish { get; set; }
        public string? FileName { get; set; }
        public int? Liked { get; set; }
        public int? Comment { get; set; }
        public int? Share { get; set; }
        public int? Reach { get; set; }
        public string? Duration { get; set; }
        public bool? IsVideo { get; set; }
        public int? ArticleTypeId { get; set; }
        public int? CompanyId { get; set; }
        public int? AssessId { get; set; }
        public int? IndustryId { get; set; }
        public int? SegmentId { get; set; }
        public int? ProductId { get; set; }
        public string? Guicode { get; set; }
        public string? Source { get; set; }
        public string? DescriptionEnglish { get; set; }
        public bool? IsSummary { get; set; }
        public bool? IsData { get; set; }
        public int? SourceId { get; set; }
        public int? TargetId { get; set; }
        public int? ReportMonthlyId { get; set; }
        public string? Media { get; set; }
        public bool? IsError { get; set; }
        public int? Advalue { get; set; }
        public string? TitleProperty { get; set; }
        public bool? IsFilter { get; set; }
        public int? MembershipId { get; set; }
        public int? SourceProperty { get; set; }
        public string? FullName { get; set; }
        public bool? IsPriority { get; set; }
        public string? NoiDung { get; set; }
    }
}
