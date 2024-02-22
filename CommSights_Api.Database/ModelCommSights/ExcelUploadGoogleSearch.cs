using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class ExcelUploadGoogleSearch
    {
        public int Id { get; set; }
        public string? Date { get; set; }
        public string? Company { get; set; }
        public string? Sentiment { get; set; }
        public string? HeadlineVn { get; set; }
        public string? HeadlineVnhyperlink { get; set; }
        public string? HeadlineEng { get; set; }
        public string? HeadlineEngHyperlink { get; set; }
        public string? Url { get; set; }
        public string? SummaryVn { get; set; }
        public string? SummaryEng { get; set; }
        public string? Author { get; set; }
        public string? Segment { get; set; }
        public string? Product { get; set; }
    }
}
