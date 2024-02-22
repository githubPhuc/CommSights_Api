﻿using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class BaiVietUpload
    {
        public int Id { get; set; }
        public int? UserCreated { get; set; }
        public DateTime? DateCreated { get; set; }
        public int? UserUpdated { get; set; }
        public DateTime? DateUpdated { get; set; }
        public int? ParentId { get; set; }
        public string? Note { get; set; }
        public bool? Active { get; set; }
        public string? Title { get; set; }
        public string? Urlcode { get; set; }
        public bool? IsFilter { get; set; }
    }
}
