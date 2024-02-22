using System;
using System.Collections.Generic;

namespace CommSights_Api.Database.ModelCommSights
{
    public partial class ApiGoogleSamsung
    {
        public int Id { get; set; }
        public string? Param { get; set; }
        public string? Value { get; set; }
        public bool? IsHieuluc { get; set; }
    }
}
