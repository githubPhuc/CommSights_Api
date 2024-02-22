using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class ApiUrl
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Url { get; set; }
        public string? Method { get; set; }
    }
}
