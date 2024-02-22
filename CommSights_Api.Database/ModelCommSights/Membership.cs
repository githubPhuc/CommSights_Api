using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class Membership
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
        public string? FullName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime? Birthday { get; set; }
        public string? Address { get; set; }
        public string? CitizenIdentification { get; set; }
        public string? Passport { get; set; }
        public decimal? Points { get; set; }
        public string? Account { get; set; }
        public string? Password { get; set; }
        public string? Guicode { get; set; }
        public string? TaxCode { get; set; }
        public string? ShortName { get; set; }
        public string? EnglishName { get; set; }
        public string? Avatar { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string? Website { get; set; }
        public decimal? ContactValue { get; set; }
        public decimal? ContactValue1month { get; set; }
        public string? ContactMethod { get; set; }
        public string? ContactProcess { get; set; }
        public string? AcceptanceForm { get; set; }
        public string? InvoiceForm { get; set; }
        public string? PaymentForm { get; set; }
        public string? MailSendCs { get; set; }
        public string? Status { get; set; }
        public string? MailCustomerService { get; set; }
        public string? ContactNo { get; set; }
        public string? Color { get; set; }
        public bool? IsIrisDashBoardPlus { get; set; }
    }
}
