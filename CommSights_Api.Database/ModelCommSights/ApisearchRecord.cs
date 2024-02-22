using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class ApisearchRecord
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public string? Author { get; set; }
        public string? Displaylink { get; set; }
        public string? Snippet { get; set; }
        public DateTime? PublishDate { get; set; }
        public string? KeySearch { get; set; }
        public string? UrlApi { get; set; }
        public int? IndustryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public bool? IsDelete { get; set; }
        public string? SearchByList { get; set; }
    }
}
