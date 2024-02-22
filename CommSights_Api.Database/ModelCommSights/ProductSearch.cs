using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class ProductSearch
    {
        public int Id { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? ParentId { get; set; }
        public string? Note { get; set; }
        public bool? Active { get; set; }
        public int? CompanyId { get; set; }
        public string? Title { get; set; }
        public string? Summary { get; set; }
        public string? SearchString { get; set; }
        public DateTime? DateSearch { get; set; }
        public DateTime? DatePublishBegin { get; set; }
        public DateTime? DatePublishEnd { get; set; }
        public int? CompanyCount { get; set; }
        public int? ProductCount { get; set; }
        public int? IndustryCount { get; set; }
        public int? SegmentCount { get; set; }
        public int? CompetitorCount { get; set; }
        public bool? IsSend { get; set; }
        public DateTime? DateSend { get; set; }
        public int? IndustryId { get; set; }
        public int? HourSearch { get; set; }
        public bool? IsDateUpdate { get; set; }
        public string? ReportFormat { get; set; }
        public string? HourString { get; set; }
    }
}
