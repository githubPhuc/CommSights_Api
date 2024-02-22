using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class CrawlDataRecord
    {
        public int Id { get; set; }
        public DateTime? DateCreated { get; set; }
        public string? Title { get; set; }
        public string? UrlCode { get; set; }
        public string? KeySearch { get; set; }
        public string? Description { get; set; }
        public string? DatePublishString { get; set; }
    }
}
