using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class ProductPermission
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
        public int? EmployeeId { get; set; }
        public int? IndustryId { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? RowBegin { get; set; }
        public int? RowEnd { get; set; }
        public int? SortOrder { get; set; }
        public int? RowPercent { get; set; }
    }
}
