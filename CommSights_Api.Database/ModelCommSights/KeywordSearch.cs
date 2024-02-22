using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class KeywordSearch
    {
        public int Id { get; set; }
        public string? Account { get; set; }
        public int? IndustryId { get; set; }
    }
}
