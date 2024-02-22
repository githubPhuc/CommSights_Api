using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class CompanyColor
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? Color { get; set; }
        public int? MembershipId { get; set; }
    }
}
