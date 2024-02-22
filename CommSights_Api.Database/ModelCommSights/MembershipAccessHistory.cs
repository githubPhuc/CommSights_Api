using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class MembershipAccessHistory
    {
        public int Id { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? ParentId { get; set; }
        public string? Note { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateTrack { get; set; }
        public int? MembershipId { get; set; }
        public string? Urlfull { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? QueryString { get; set; }
    }
}
