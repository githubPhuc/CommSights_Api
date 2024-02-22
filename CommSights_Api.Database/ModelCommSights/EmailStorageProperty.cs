using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class EmailStorageProperty
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
        public string? Code { get; set; }
        public string? Title { get; set; }
        public string? FileName { get; set; }
        public DateTime? DateRead { get; set; }
        public string? Email { get; set; }
    }
}
