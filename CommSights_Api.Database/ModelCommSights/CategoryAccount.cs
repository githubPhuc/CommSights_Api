using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class CategoryAccount
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? CategorySubIndustry { get; set; }
        public string? CategoryAccount1 { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdated { get; set; }
        public int? DateUpdated { get; set; }
    }
}
