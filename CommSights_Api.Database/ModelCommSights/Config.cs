using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class Config
    {
        public int Id { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? ParentId { get; set; }
        public string? Note { get; set; }
        public bool? Active { get; set; }
        public string? GroupName { get; set; }
        public string? Code { get; set; }
        public string? CodeName { get; set; }
        public string? CodeNameSub { get; set; }
        public int? SortOrder { get; set; }
        public string? Icon { get; set; }
        public string? Controller { get; set; }
        public string? Action { get; set; }
        public string? Urlfull { get; set; }
        public string? Urlsub { get; set; }
        public string? Title { get; set; }
        public bool? IsMenuLeft { get; set; }
        public int? BlackWhite { get; set; }
        public int? Color { get; set; }
        public int? CountryId { get; set; }
        public int? LanguageId { get; set; }
        public int? FrequencyId { get; set; }
        public int? ColorTypeId { get; set; }
        public int? IndustryId { get; set; }
        public int? TierId { get; set; }
    }
}
