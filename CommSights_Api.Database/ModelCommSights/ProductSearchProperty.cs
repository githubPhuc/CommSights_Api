using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class ProductSearchProperty
    {
        public int Id { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? ParentId { get; set; }
        public string? Note { get; set; }
        public bool? Active { get; set; }
        public int? ProductSearchId { get; set; }
        public int? ProductId { get; set; }
        public int? ArticleTypeId { get; set; }
        public int? CompanyId { get; set; }
        public int? AssessId { get; set; }
        public int? IndustryId { get; set; }
        public int? SegmentId { get; set; }
        public int? ProductId001 { get; set; }
        public decimal? Point { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsSummary { get; set; }
        public string? Summary { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsData { get; set; }
        public int? ProductPropertyId { get; set; }
        public DateTime? DatePublishBegin { get; set; }
        public DateTime? DatePublishEnd { get; set; }
    }
}
