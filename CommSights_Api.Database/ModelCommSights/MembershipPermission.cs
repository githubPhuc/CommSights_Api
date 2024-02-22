using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class MembershipPermission
    {
        public int Id { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? ParentId { get; set; }
        public string? Note { get; set; }
        public bool? Active { get; set; }
        public string? Code { get; set; }
        public int? MembershipId { get; set; }
        public int? MenuId { get; set; }
        public bool? IsView { get; set; }
        public int? CategoryId { get; set; }
        public int? IndustryId { get; set; }
        public int? SegmentId { get; set; }
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public int? CompanyId { get; set; }
        public int? IndustryCompareId { get; set; }
        public int? ProductCompareId { get; set; }
        public int? SortOrder { get; set; }
        public decimal? Hour { get; set; }
        public decimal? Minute { get; set; }
        public decimal? Second { get; set; }
        public int? LanguageId { get; set; }
        public bool? IsDaily { get; set; }
        public bool? IsWeekly { get; set; }
        public bool? IsMonthly { get; set; }
        public bool? IsQuarterly { get; set; }
        public bool? IsYearly { get; set; }
        public bool? IsBiWeekly { get; set; }
        public bool? IsMorning { get; set; }
        public bool? IsNoon { get; set; }
        public bool? IsAfternoon { get; set; }
        public int? ServicesId { get; set; }
        public int? ReportTypeId { get; set; }
        public int? ServicesFormatId { get; set; }
        public bool? IsHalfYear { get; set; }
        public bool? IsNegativeAlert { get; set; }
        public bool? IsCrisis { get; set; }
        public bool? IsCampaign { get; set; }
        public bool? IsIndustry { get; set; }
        public bool? IsAdHoc { get; set; }
        public bool? IsProject { get; set; }
        public bool? IsOther { get; set; }
    }
}
