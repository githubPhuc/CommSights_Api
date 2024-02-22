using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class ApiCountQuery
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public int? SummaryQuery { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
