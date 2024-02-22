using CommSights_Api.Database.ModelCommSights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Database.DataTransferObject
{
    public  class ProductSearchPropertyDataTransfer : ProductSearchProperty
    {
        public string Summary { get; set; }
        public int? ProductSearchID { get; set; }
        public int? ProductID { get; set; }
        public int? ProductPropertyID { get; set; }
        public int? ArticleTypeID { get; set; }
        public int? CompanyID { get; set; }
        public int? AssessID { get; set; }
        public int? IndustryID { get; set; }
        public int? SegmentID { get; set; }
        public int? ProductID001 { get; set; }
        public decimal? Point { get; set; }
        public int? CategoryID { get; set; }
        public bool? IsSummary { get; set; }
        public int? SortOrder { get; set; }
    }
}
