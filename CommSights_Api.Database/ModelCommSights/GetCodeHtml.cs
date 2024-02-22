using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class GetCodeHtml
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Site { get; set; }
        public string? TitleCode { get; set; }
        public string? DescriptionCode { get; set; }
        public string? DatePublishCode { get; set; }
    }
}
