using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class BaiVietUploadCount
    {
        public int Id { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? ParentId { get; set; }
        public string? Note { get; set; }
        public bool? Active { get; set; }
        public int? IndustryId { get; set; }
        public int? Count { get; set; }
    }
}
