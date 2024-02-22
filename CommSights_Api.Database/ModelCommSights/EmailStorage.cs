using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class EmailStorage
    {
        public int Id { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? ParentId { get; set; }
        public string? Note { get; set; }
        public bool? Active { get; set; }
        public int? CategoryId { get; set; }
        public int? IndustryId { get; set; }
        public int? CompanyId { get; set; }
        public string? Smtpserver { get; set; }
        public int? Smtpport { get; set; }
        public string? EmailFrom { get; set; }
        public string? Password { get; set; }
        public string? Display { get; set; }
        public string? Subject { get; set; }
        public string? EmailTo { get; set; }
        public string? EmailCc { get; set; }
        public string? EmailBcc { get; set; }
        public string? EmailBody { get; set; }
        public DateTime? DateSend { get; set; }
        public DateTime? DateRead { get; set; }
    }
}
