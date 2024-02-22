using CommSights_Api.Database.ModelCommSights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Database.DataTransferObject
{
    public class ProductDataTransfer : Product
    {
        public string DatePublishString
        {
            get
            {
                string result = "";
                if (DatePublish != null && DatePublish is DateTime)
                {
                    result = ((DateTime)DatePublish).ToString("dd/MM/yyyy");
                }
                return result;
            }
        }
        public string DatePublishStringEnglish
        {
            get
            {
                string result = "";
                if (DatePublish != null)
                {
                    result = ((DateTime)DatePublish).ToString("MM/dd/yyyy");
                }
                return result;
            }
        }
        public int? AdvertisementValue { get; set; }
        public string AdvertisementValueString
        {
            get
            {
                string result = "";
                if (AdvertisementValue != null)
                {
                    result = ((decimal)AdvertisementValue.Value).ToString("N0");
                }
                return result;
            }
        }
        public int ProductProPertyID { get; set; }
        public string Media { get; set; }
        public string MediaType { get; set; }
        public string MediaTypeVietnamese { get; set; }
        public string Summary { get; set; }
        public int Point { get; set; }
        public string ArticleTypeName { get; set; }
        public string ArticleTypeNameVietnamese { get; set; }
        public string AssessName { get; set; }
        public string AssessNameVietnamese { get; set; }
        public string CompanyName { get; set; }
        public string SegmentName { get; set; }
        public string IndustryName { get; set; }
        public string ProductName { get; set; }
        public string ParentName { get; set; }
        public string CategoryMain { get; set; }
        public string CategorySub { get; set; }
        public string SentimentCorp { get; set; }
        public string Frequency { get; set; }
        public string MediaTitle { get; set; }
        public int? MembershipTypeID { get; set; }
        public int? MembershipPermissionProductID { get; set; }
        public bool? IsSource { get; set; }
        public bool? IsCopy { get; set; }
        public ModelTemplate ArticleType { get; set; }
        public ModelTemplate Company { get; set; }
        public ModelTemplate AssessType { get; set; }
        public ModelTemplate Segment { get; set; }
        public ModelTemplate Product { get; set; }
    }
}
