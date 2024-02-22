
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.IO;
using CommSights_Api.Abstractions.Enums;

namespace CommSights_Api.Library.Helps
{
  
    public class AppGlobal
    {
        private readonly IConfiguration _configuration;
        public AppGlobal (IConfiguration configuration)
        {
            _configuration = configuration;
        }
        #region Appsetting
        public string ConectionString => _configuration["AppSettings:ConectionString"] ?? "";
        public string Urlcode => _configuration["AppSettings:Urlcode"] ?? "";
        public string ProductFeature => _configuration["AppSettings:ProductFeature"] ?? "";
        public string IndustryCategory => _configuration["AppSettings:IndustryCategory"] ?? "";
        public string TV => _configuration["AppSettings:TV"] ?? "";
        public string Newspage => _configuration["AppSettings:Newspage"] ?? "";
        public string TotalSize => _configuration["AppSettings:TotalSize"] ?? "";
        public string FTPScanFiles => _configuration["AppSettings:FTPScanFiles"] ?? "";
        public string URLScanFiles => _configuration["AppSettings:URLScanFiles"] ?? "";
        public int AdValue => Convert.ToInt32(_configuration["AppSettings:AdValue"]);
        public int TierOtherID => Convert.ToInt32(_configuration["AppSettings:TierOtherID"]);
        public int TierPortalID => Convert.ToInt32(_configuration["AppSettings:TierPortalID"]);
        public int TierLocalMediaID => Convert.ToInt32(_configuration["AppSettings:TierLocalMediaID"]);
        public int TierIndustryID => Convert.ToInt32(_configuration["AppSettings:TierIndustryID"]);
        public int TierMassMediaID => Convert.ToInt32(_configuration["AppSettings:TierMassMediaID"]);
        public int FeatureID => Convert.ToInt32(_configuration["AppSettings:FeatureID"]);
        public int MentionID => Convert.ToInt32(_configuration["AppSettings:MentionID"]);
        public int DateBegin => Convert.ToInt32(_configuration["AppSettings:DateBegin"]);
        public int DateEnd => Convert.ToInt32(_configuration["AppSettings:DateEnd"]);
        public string IndustryKeyWord => _configuration["AppSettings:IndustryKeyWord"]??"";
        public string KeyMessage => _configuration["AppSettings:KeyMessage"] ??"";
        public string CampaignKeyMessage => _configuration["AppSettings:CampaignKeyMessage"] ??"";
        public string Campaign => _configuration["AppSettings:Campaign"] ??"";
        public string CorpCopy => _configuration["AppSettings:CorpCopy"] ??"";
        public string CategoryMain => _configuration["AppSettings:CategoryMain"] ??"";
        public string CategorySub => _configuration["AppSettings:CategorySub"] ??"";
        public string Feature => _configuration["AppSettings:Feature"] ??"";
        public string Sentiment => _configuration["AppSettings:Sentiment"] ??"";
        public int DailyReportColumnSegmentID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnSegmentID"]);
        public int DailyReportColumnSubCatID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnSubCatID"]);
        public int DailyReportColumnDatePublishID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnDatePublishID"]);
        public int DailyReportColumnCategoryID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnCategoryID"]);
        public int DailyReportColumnCompanyID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnCompanyID"]);
        public int DailyReportColumnSentimentID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnSentimentID"]);
        public int DailyReportColumnHeadlineVietnameseID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnHeadlineVietnameseID"]);
        public int DailyReportColumnHeadlineEnglishID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnHeadlineEnglishID"]);
        public int DailyReportColumnMediaTitleID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnMediaTitleID"]);
        public int DailyReportColumnMediaTypeID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnMediaTypeID"]);
        public int DailyReportColumnPageID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnPageID"]);
        public int DailyReportColumnAdvertisementID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnAdvertisementID"]);
        public int DailyReportColumnSummaryID => Convert.ToInt32(_configuration["AppSettings:DailyReportColumnSummaryID"]);
        public int DailyReportSectionDataID => Convert.ToInt32(_configuration["AppSettings:DailyReportSectionDataID"]);
        public int DailyReportSectionSummaryID => Convert.ToInt32(_configuration["AppSettings:DailyReportSectionSummaryID"]);
        public int DailyReportSectionExtraID => Convert.ToInt32(_configuration["AppSettings:DailyReportSectionExtraID"]);
        public string SourceAuto => _configuration["AppSettings:SourceAuto"] ??"";
        public string SourceGoogle => _configuration["AppSettings:SourceGoogle"] ??"";
        public string SourceScan => _configuration["AppSettings:SourceScan"] ??"";
        public string SourceAndi => _configuration["AppSettings:SourceAndi"] ??"";
        public string SourceYounet => _configuration["AppSettings:SourceYounet"] ??"";
        public string EmailSupport => _configuration["AppSettings:EmailSupport"] ??"";
        public string CommsightsWebsite => _configuration["AppSettings:CommsightsWebsite"] ??"";
        public string CommsightsWebsiteDisplay => _configuration["AppSettings:CommsightsWebsiteDisplay"] ??"";
        public string Tier => _configuration["AppSettings:Tier"] ??"";
        public string MediaTier => _configuration["AppSettings:MediaTier"] ??"";
        public string CompanyTitleEnglish => _configuration["AppSettings:CompanyTitleEnglish"] ??"";
        public string TaxCode => _configuration["AppSettings:TaxCode"] ??"";
        public string PhoneDisplay => _configuration["AppSettings:PhoneDisplay"] ??"";
        public string PhoneReport => _configuration["AppSettings:PhoneReport"] ??"";
        public string EmailReport => _configuration["AppSettings:EmailReport"] ??"";
        public string AddressReport => _configuration["AppSettings:AddressReport"]??"";
        public string GoogleMapID => _configuration["AppSettings:GoogleMapID"] ??"";
        public string ReportDailyTitle => _configuration["AppSettings:ReportDailyTitle"] ??"";
        public string Error001 => _configuration["AppSettings:Error001"] ??"";
        public int AdvertisementValue => Convert.ToInt32(_configuration["AppSettings:AdvertisementValue"]);
        public string TierID02 => _configuration["AppSettings:TierID02"] ??"";
        public int Hour => Convert.ToInt32(_configuration["AppSettings:Hour"]);
        public int DailyReportDataID => Convert.ToInt32(_configuration["AppSettings:DailyReportDataID"]);
        public int DailyReportSummaryID => Convert.ToInt32(_configuration["AppSettings:DailyReportSummaryID"]);
        public int DailyReportExtraID => Convert.ToInt32(_configuration["AppSettings:DailyReportExtraID"]);
        public int PositiveID => Convert.ToInt32(_configuration["AppSettings:PositiveID"]);
        public int NeutralID => Convert.ToInt32(_configuration["AppSettings:NeutralID"]);
        public int NegativeID => Convert.ToInt32(_configuration["AppSettings:NegativeID"]);
        public int IndustryID => Convert.ToInt32(_configuration["AppSettings:IndustryID"]);
        public int SegmentID => Convert.ToInt32(_configuration["AppSettings:SegmentID"]);
        public int CountryID => Convert.ToInt32(_configuration["AppSettings:CountryID"]);
        public int LanguageID => Convert.ToInt32(_configuration["AppSettings:LanguageID"]);
        public int FrequencyID => Convert.ToInt32(_configuration["AppSettings:FrequencyID"]);
        public int ColorTypeID => Convert.ToInt32(_configuration["AppSettings:ColorTypeID"]);
        public int CompetitorID => Convert.ToInt32(_configuration["AppSettings:CompetitorID"]);
        public int WebsiteID => Convert.ToInt32(_configuration["AppSettings:WebsiteID"]);
        public int ParentId => Convert.ToInt32(_configuration["AppSettings:ParentId"]);
        public int CompanyFeatureID => Convert.ToInt32(_configuration["AppSettings:CompanyFeatureID"]);
        public int CompanyMentionID => Convert.ToInt32(_configuration["AppSettings:CompanyMentionID"]);
        public int TinDoanhNghiepID => Convert.ToInt32(_configuration["AppSettings:TinDoanhNghiepID"]);
        public int TinNganhID => Convert.ToInt32(_configuration["AppSettings:TinNganhID"]);
        public int TinSanPhamID => Convert.ToInt32(_configuration["AppSettings:TinSanPhamID"]);
        public int ArticleTypeID => Convert.ToInt32(_configuration["AppSettings:ArticleTypeID"]);
        public int AssessID => Convert.ToInt32(_configuration["AppSettings:AssessID"]);
        public int ParentIdCompetitor => Convert.ToInt32(_configuration["AppSettings:ParentIdCompetitor"]);
        public int ParentIdCustomer => Convert.ToInt32(_configuration["AppSettings:ParentIdCustomer"]);
        public int ParentIdEmployee => Convert.ToInt32(_configuration["AppSettings:ParentIdEmployee"]);
        public string Channel => _configuration["AppSettings:Channel"]??"";
        public string KeywordNegative => _configuration["AppSettings:KeywordNegative"] ??"";
        public string KeywordPositive => _configuration["AppSettings:KeywordPositive"] ??"";
        public string ReportType => _configuration["AppSettings:ReportType"] ??"";
        public string DailyReportSection => _configuration["AppSettings:DailyReportSection"] ??"";
        public string DailyReportColumn => _configuration["AppSettings:DailyReportColumn"] ??"";
        public string File => _configuration["AppSettings:File"] ??"";
        public string Company => _configuration["AppSettings:Company"] ??"";
        public string CompanyName => _configuration["AppSettings:CompanyName"] ??"";
        public string Industry => _configuration["AppSettings:Industry"] ??"";
        public string Segment => _configuration["AppSettings:Segment"] ??"";
        public string Competitor => _configuration["AppSettings:Competitor"] ??"";
        public string Contact => _configuration["AppSettings:Contact"] ??"";
        public string ArticleType => _configuration["AppSettings:ArticleType"] ??"";
        public string AssessType => _configuration["AppSettings:AssessType"] ??"";
        public string PressList => _configuration["AppSettings:PressList"] ??"";
        public string EmailStorage => _configuration["AppSettings:EmailStorage"] ??"";
        public string EmailStorageCategory => _configuration["AppSettings:EmailStorageCategory"] ??"";
        public string Country => _configuration["AppSettings:Country"] ??"";
        public string Language => _configuration["AppSettings:Language"] ??"";
        public string Frequency => _configuration["AppSettings:Frequency"] ??"";
        public string Color => _configuration["AppSettings:Color"] ??"";
        public string Brand => _configuration["AppSettings:Brand"] ??"";
        public string Product => _configuration["AppSettings:Product"] ??"";
        public string SendMailSuccess => _configuration["AppSettings:SendMailSuccess"] ??"";
        public string ScanFinish => _configuration["AppSettings:ScanFinish"] ??"";
        public string Loading => _configuration["AppSettings:Loading"] ??"";
        public string Logo => _configuration["AppSettings:Logo"] ??"";
        public string Logo01 => _configuration["AppSettings:Logo01"] ??"";
        public string Logo160_160 => _configuration["AppSettings:Logo160_160"] ??"";
        public string Images => _configuration["AppSettings:Images"] ??"";
        public string Membership => _configuration["AppSettings:Membership"] ??"";
        public string Customer => _configuration["AppSettings:Customer"] ??"";
        public string Domain => _configuration["AppSettings:Domain"] ??"";
        public string Background_Logo_Opacity10_1400_1000 => _configuration["AppSettings:Background_Logo_Opacity10_1400_1000"] ??"";
        public string Facebook => _configuration["AppSettings:Facebook"] ??"";
        public string CRM => _configuration["AppSettings:CRM"] ??"";
        public string Website => _configuration["AppSettings:Website"] ??"";

        #endregion
        #region Init
        public static DateTime InitDateTime => DateTime.Now;

        public static string InitString => string.Empty;

        public static string DateTimeCode => DateTime.Now.ToString("yyyyMMddHHmmss");
        public static string HourCode => DateTime.Now.ToString("yyyyMMddHH");
        public static string DateTimeCodeYearMonthDay => DateTime.Now.ToString("yyyyMMdd");
        public static string InitGuiCode => Guid.NewGuid().ToString();
        #endregion

        #region AppSettings

        public string WebsiteHTML => "<a target='_blank' href='" + CommsightsWebsite + "' title='" + CommsightsWebsiteDisplay + "'>" + CommsightsWebsiteDisplay + "</a>";
        public string PhoneReportHTML => "<a target='_blank' href='" + PhoneReportURLFUll + "' title='" + PhoneReport + "'>" + PhoneDisplay + "</a>";
        public  string EmailReportHTML
        {
            get
            {
                return "<a target='_blank' href='" + EmailReportURLFUll + "' title='" + EmailReport + "'>" + EmailReport + "</a>";
            }
        }
        public  string FacebookHTML
        {
            get
            {
                return "<a target='_blank' href='" + FacebookURLFUll + "' title='" + Facebook + "'>" + Facebook + "</a>";
            }
        }
        public  string GoogleMapHTML => "<a target='_blank' href='" + GoogleMapURLFUll + "' title='" + AddressReport + "'>" + AddressReport + "</a>";
        public  string EmailReportURLFUll
        {
            get
            {
                string result = "https://mail.google.com/mail/u/0/?view=cm&fs=1&to=" + EmailReport + "&su=Hi_CommSights&body=https://www.commsights.com/&tf=1" + EmailReport;
                return result;
            }
        }
        public  string PhoneReportURLFUll
        {
            get
            {
                string result = "tel:" + PhoneReport;
                return result;
            }
        }
        public  string FacebookURLFUll
        {
            get
            {
                string result = "https://www.facebook.com/" + Facebook;
                return result;
            }
        }
        public  string GoogleMapURLFUll
        {
            get
            {
                string result = "https://www.google.com/maps/d/u/0/viewer?mid=" + GoogleMapID;
                return result;
            }
        }
        public  string URLImagesCustomer
        {
            get
            {
                string result = Images + "/" + Customer;
                return result;
            }
        }

        public  string GetURLImagesMembership()
        {
            string result = Images + "/" + Membership;
            return result;
        }
        public  string Background_Logo_Opacity10_1400_1000URLFUll
        {
            get
            {
                string result = Domain + Images + "/" + Background_Logo_Opacity10_1400_1000;
                return result;
            }
        }
        public string[] keywords = { "ngành", "industry", "Tin chung", "General News" };
        public string SetHeadline(string Headline)
        {
            string fileNameReturn = Headline;
            if (!string.IsNullOrEmpty(fileNameReturn))
            {
                fileNameReturn = fileNameReturn.Replace("‘", "\"");
                fileNameReturn = fileNameReturn.Replace("’", "\"");
                fileNameReturn = fileNameReturn.Replace("‘", "\"");
                fileNameReturn = fileNameReturn.Replace("‛", "\"");
                fileNameReturn = fileNameReturn.Replace("“", "\"");
                fileNameReturn = fileNameReturn.Replace("”", "\"");
                fileNameReturn = fileNameReturn.Replace("‟", "\"");
                fileNameReturn = fileNameReturn.Replace("′", "\"");
                fileNameReturn = fileNameReturn.Replace("″", "\"");
                fileNameReturn = fileNameReturn.Replace("‵", "\"");
                fileNameReturn = fileNameReturn.Replace("‶", "\"");
                fileNameReturn = fileNameReturn.Replace("❛", "\"");
                fileNameReturn = fileNameReturn.Replace("❜", "\"");
                fileNameReturn = fileNameReturn.Replace("❝", "\"");
                fileNameReturn = fileNameReturn.Replace("❞", "\"");
                fileNameReturn = fileNameReturn.Replace("ʹ", "\"");
                fileNameReturn = fileNameReturn.Replace("ʺ", "\"");
                fileNameReturn = fileNameReturn.Replace("ʻ", "\"");
                fileNameReturn = fileNameReturn.Replace("ʽ", "\"");
                fileNameReturn = fileNameReturn.Replace("ˈ", "\"");
                fileNameReturn = fileNameReturn.Replace("ˊ", "\"");
                fileNameReturn = fileNameReturn.Replace("ˋ", "\"");
                fileNameReturn = fileNameReturn.Replace("〝", "\"");
                fileNameReturn = fileNameReturn.Replace("〞", "\"");
                fileNameReturn = fileNameReturn.Replace("'", "\"");
                // Thay thế các kí tự - về -
                fileNameReturn = fileNameReturn.Replace("—", "-");
                fileNameReturn = fileNameReturn.Replace("–", "-");
                fileNameReturn = fileNameReturn.Replace("―", "-");
            }
            return fileNameReturn;
        }
        //public static string Background_Logo_Opacity10_1400_1000
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Background_Logo_Opacity10_1400_1000").Value;
        //    }
        //}

        //public static string Membership
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Membership").Value;
        //    }
        //}
        //public static string Customer
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Customer").Value;
        //    }
        //}
        //public static string FTPDownloadReprotMonth
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("FTPDownloadReprotMonth").Value;
        //    }
        //}
        //public static string FTPDownloadReprotDaily
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("FTPDownloadReprotDaily").Value;
        //    }
        //}
        //public static string URLDownloadReprotMonth
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("URLDownloadReprotMonth").Value;
        //    }
        //}
        //public static string URLDownloadReprotDaily
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("URLDownloadReprotDaily").Value;
        //    }
        //}
        //public static string HTML
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("HTML").Value;
        //    }
        //}
        //public static string Images
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Images").Value;
        //    }
        //}
        //public static string LoadingURLFull
        //{
        //    get
        //    {
        //        string result = AppGlobal.DomainMain + AppGlobal.Images + "/" + AppGlobal.Loading;
        //        return result;
        //    }
        //}
        //public static string LogoURLFull
        //{
        //    get
        //    {
        //        string result = AppGlobal.DomainMain + AppGlobal.Images + "/" + AppGlobal.Logo;
        //        return result;
        //    }
        //}
        //public static string Decor01
        //{
        //    get
        //    {
        //        string result = AppGlobal.DomainMain + "images/Report_Format/report_format5.png";
        //        return result;
        //    }
        //}
        //public static string logodrawning_1
        //{
        //    get
        //    {
        //        string result = AppGlobal.DomainMain + "images/Report_Format/logodrawning_1.png";
        //        return result;
        //    }
        //}
        //public static string logodrawning_2
        //{
        //    get
        //    {
        //        string result = AppGlobal.DomainMain + "images/Report_Format/logodrawning_2.png";
        //        return result;
        //    }
        //}
        //public static string LogoCustomer
        //{
        //    get
        //    {
        //        string result = AppGlobal.DomainMain + "images/Membership/";
        //        return result;
        //    }
        //}
        //public static string Logo01URLFull
        //{
        //    get
        //    {
        //        string result = AppGlobal.DomainMain + AppGlobal.Images + "/" + AppGlobal.Logo01;
        //        return result;
        //    }
        //}
        //public static string Logo160_160URLFull
        //{
        //    get
        //    {
        //        string result = AppGlobal.DomainMain + AppGlobal.Images + "/" + AppGlobal.Logo160_160;
        //        return result;
        //    }
        //}
        //public static string CRM
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("CRM").Value;
        //    }
        //}
        //public static string Menu
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Menu").Value;
        //    }
        //}
        //public static string Website
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Website").Value;
        //    }
        //}
        //public static string MembershipType
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("MembershipType").Value;
        //    }
        //}
        //public static string WebsiteType
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("WebsiteType").Value;
        //    }
        //}
        //public static string EditSuccess
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("EditSuccess").Value;
        //    }
        //}

        //public static string EditFail
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("EditFail").Value;
        //    }
        //}

        //public static string CreateSuccess
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("CreateSuccess").Value;
        //    }
        //}

        //public static string CreateFail
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("CreateFail").Value;
        //    }
        //}

        //public static string DeleteSuccess
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("DeleteSuccess").Value;
        //    }
        //}

        //public static string DeleteFail
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("DeleteFail").Value;
        //    }
        //}

        //public static string Success
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Success").Value;
        //    }
        //}

        //public static string Error
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Error").Value;
        //    }
        //}

        //public static string RedirectDefault
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("RedirectDefault").Value;
        //    }
        //}

        //public static string LoginFail
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("LoginFail").Value;
        //    }
        //}
        //public static string URLDownloadExcel
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("URLDownloadExcel").Value;
        //    }
        //}
        //public static string URLScan
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("URLScan").Value;
        //    }
        //}
        //public static string FTPUploadExcel
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("FTPUploadExcel").Value;
        //    }
        //}
        //public static string ConectionString
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("ConectionString").Value;
        //    }
        //}
        //public static string DomainMain
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("DomainMain").Value;
        //    }
        //}
        //public static string DomainMainCRM
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("DomainMainCRM").Value;
        //    }
        //}
        //public static string Domain
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Domain").Value;
        //    }
        //}
        //public static string DomainSub
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("DomainSub").Value;
        //    }
        //}

        //public static string SitemapFTP
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("SitemapFTP").Value;
        //    }
        //}

        //public static string CMSTitle
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("CMSTitle").Value;
        //    }
        //}

        //public static string MD5Key
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("MD5Key").Value;
        //    }
        //}

        //public static string PhoneContact
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("PhoneContact").Value;
        //    }
        //}

        //public static string EmailContact
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("EmailContact").Value;
        //    }
        //}

        //public static string AddressContact
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("AddressContact").Value;
        //    }
        //}

        //public static string Title
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Title").Value;
        //    }
        //}

        //public static string Facebook
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Facebook").Value;
        //    }
        //}

        //public static string Twitter
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Twitter").Value;
        //    }
        //}

        //public static string Youtube
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("Youtube").Value;
        //    }
        //}

        //public static string FacebookTitle
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("FacebookTitle").Value;
        //    }
        //}

        //public static string TwitterTitle
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("TwitterTitle").Value;
        //    }
        //}

        //public static string YoutubeTitle
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("YoutubeTitle").Value;
        //    }
        //}

        //public static string TopMenuCode
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("TopMenuCode").Value;
        //    }
        //}

        //public static string MenuLeftCode
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("MenuLeftCode").Value;
        //    }
        //}

        //public static string CarouselCode
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("CarouselCode").Value;
        //    }
        //}

        //public static int ProductPageSize
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return int.Parse(builder.Build().GetSection("AppSettings").GetSection("ProductPageSize").Value);
        //    }
        //}

        //public static string CategoryCode
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("CategoryCode").Value;
        //    }
        //}

        //public static string PriceUnit
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("PriceUnit").Value;
        //    }
        //}
        //public static string TagCode
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("TagCode").Value;
        //    }
        //}
        //public static string SMTPServer
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("SMTPServer").Value;
        //    }
        //}

        //public static int SMTPPort
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return int.Parse(builder.Build().GetSection("AppSettings").GetSection("SMTPPort").Value);
        //    }
        //}

        //public static int IsMailUsingSSL
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return int.Parse(builder.Build().GetSection("AppSettings").GetSection("IsMailUsingSSL").Value);
        //    }
        //}
        //public static string IsMailBodyHtml
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("IsMailBodyHtml").Value;
        //    }
        //}
        //public static string MasterEmailUser
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("MasterEmailUser").Value;
        //    }
        //}
        //public static string MasterEmailPassword
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("MasterEmailPassword").Value;
        //    }
        //}
        //public static string MasterEmailDisplay
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("MasterEmailDisplay").Value;
        //    }
        //}
        //public static string MasterEmailSubject
        //{
        //    get
        //    {
        //        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //        return builder.Build().GetSection("AppSettings").GetSection("MasterEmailSubject").Value;
        //    }
        //}
        #endregion
        #region Functions

        public static List<int> InitializationHourToList()
        {
            List<int> list = new List<int>();
            for (int i = 1; i < 25; i++)
            {
                list.Add(i);
            }
            return list;
        }
        public static int CheckContentAndKeyword(string content, string keyword)
        {
            int check = 0;
            int checkSub = 0;
            int index = content.IndexOf(keyword);
            if (index == 0)
            {
                checkSub = checkSub + 1;
            }
            else
            {
                string word01 = content[index - 1].ToString();
                if ((word01 == " ") || (word01 == "(") || (word01 == "[") || (word01 == "{") || (word01 == "<"))
                {
                    checkSub = checkSub + 1;
                }
            }
            int index001 = index + keyword.Length;
            if (index001 < content.Length)
            {
                string word02 = content[index001].ToString();
                if ((word02 != " ") && (word02 != ",") && (word02 != ".") && (word02 != ";") && (word02 != ")") && (word02 != "]") && (word02 != "}") && (word02 != ">"))
                {
                }
                else
                {
                    checkSub = checkSub + 1;
                }
            }
            if (checkSub == 2)
            {
                check = 1;
            }
            return check;
        }
        public static string GetContentByURL(string url, int ParentId)
        {
            WebClient webClient = new WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            string html = "";
            try
            {
                html = webClient.DownloadString(url);
            }
            catch
            {

            }
            string content = html;
            if (!string.IsNullOrEmpty(content))
            {
                content = content.Replace(@"</body>", @"</body>~");
                content = content.Split('~')[0];
                content = content.Replace(@"</head>", @"~");
                if (content.Split('~').Length > 1)
                {
                    content = content.Split('~')[1];
                    content = content.Replace(@"<footer", @"~");
                    content = content.Split('~')[0];
                    switch (ParentId)
                    {
                        default:
                            content = content.Replace(@"</h1>", @"~");
                            int length = content.Split('~').Length;
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 492:
                            content = content.Replace(@"</h1>", @"~");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[2];
                            }
                            break;
                        case 168:
                            content = content.Replace(@"(ANTV)", @"~(ANTV)");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 187:
                            content = content.Replace(@"<div class=""article-body cmscontents"">", @"~<div class=""article-body cmscontents"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 196:
                            content = content.Replace(@"<div id=""content_detail_news"">", @"~<div id=""content_detail_news"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 229:
                            content = content.Replace(@"<!-- main content -->", @"~");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 278:
                            content = content.Replace(@"<div id=""ArticleContent""", @"~<div id=""ArticleContent""");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 294:
                            content = content.Replace(@"<div data-check-position=""af_detail_body_start"">", @"~<div data-check-position=""af_detail_body_start"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 295:
                            content = content.Replace(@"<div class=""sapo_news"">", @"~<div class=""sapo_news"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 296:
                            content = content.Replace(@"<div class=""article-content"">", @"~<div class=""article-content"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 301:
                            content = content.Replace(@"<div class=""article-detail"">", @"~<div class=""article-detail"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 343:
                            content = content.Replace(@"<div class=""boxdetail"">", @"~<div class=""boxdetail"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 363:
                            content = content.Replace(@"<div id=""divContents""", @"~<div id=""divContents""");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 378:
                            content = content.Replace(@"<div class=""main-content"">", @"~<div class=""main-content"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 394:
                            content = content.Replace(@"<strong class=""d_Txt"">", @"~<strong class=""d_Txt"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 420:
                            content = content.Replace(@"<div id=""sevenBoxNewContentInfo"" class=""sevenPostContentCus"">", @"~<div id=""sevenBoxNewContentInfo"" class=""sevenPostContentCus"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 421:
                            content = content.Replace(@"<div class=""detail-content"">", @"~<div class=""detail-content"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 454:
                            content = content.Replace(@"<span id=""ctl00_mainContent_bodyContent_lbBody"">", @"~<span id=""ctl00_mainContent_bodyContent_lbBody"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 530:
                            content = content.Replace(@"<div id=""admwrapper"">", @"~<div id=""admwrapper"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 851:
                            content = content.Replace(@"<div id=""wrap-detail"" class=""cms-body"">", @"~<div id=""wrap-detail"" class=""cms-body"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 855:
                            content = content.Replace(@"<div class=""knc-content"" id=""ContentDetail"">", @"~<div class=""knc-content"" id=""ContentDetail"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 859:
                            content = content.Replace(@"<div type=""RelatedOneNews"" class=""VCSortableInPreviewMode"">", @"~<div type=""RelatedOneNews"" class=""VCSortableInPreviewMode"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 865:
                            content = content.Replace(@"<div type=""abdf"">", @"~<div type=""abdf"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 870:
                            content = content.Replace(@"<div class=""entry-content"">", @"~<div class=""entry-content"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 969:
                            content = content.Replace(@"<div id=""cotent_detail"" class=""pkg"">", @"~<div id=""cotent_detail"" class=""pkg"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 1002:
                            content = content.Replace(@"<!-- BEGIN .shortcode-content -->", @"~");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 1052:
                            content = content.Replace(@"<article class=""article-content"" itemprop=""articleBody"">", @"~<article class=""article-content"" itemprop=""articleBody"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 1177:
                            content = content.Replace(@"(Tieudung.vn)", @"~(Tieudung.vn)");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 1289:
                            content = content.Replace(@"<div class=""entry-content"">", @"~<div class=""entry-content"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 1307:
                            content = content.Replace(@"<div class=""entry-content"">", @"~<div class=""entry-content"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 1352:
                            content = content.Replace(@"<div class=""inline-image-caption", @"~<div class=""inline-image-caption");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 1357:
                            content = content.Replace(@"<div class=""content article-body cms-body AdAsia""", @"~<div class=""content article-body cms-body AdAsia""");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 1383:
                            content = content.Replace(@"<div class=""article-content""", @"~<div class=""article-content""");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 1398:
                            content = content.Replace(@"<div class=""article__body""", @"~<div class=""article__body""");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                        case 1403:
                            content = content.Replace(@"<div class=""edittor-content box-cont clearfix"" itemprop=""articleBody"">", @"~<div class=""edittor-content box-cont clearfix"" itemprop=""articleBody"">");
                            if (content.Split('~').Length > 1)
                            {
                                content = content.Split('~')[1];
                            }
                            break;
                    }
                    content = content.Replace(@"<div class=""VnnAdsPos clearfix"" data-pos=""vt_article_bottom"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<ul class=""list-news hidden"" data-campaign=""Box-Related"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<!-- Begin Dable In_article Widget / For inquiries, visit http://dable.io -->", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""tagandnetwork"" id=""tagandnetwork"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"</em></p><div class=""inner-article"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""print_back"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""func-bot"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""news-other row10""><div class=""cate-header"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""sharing_tool atbottom"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""CustomContentObject LinkInlineObject"" data-type=""insertlinkbottom"" contenteditable=""false"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""news_relate_one d-flex mb30"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div id=""adsctl00_mainContent_AdsHome1"" class=""qc simplebanner"" data-position=""PC_below_Author"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""VCSortableInPreviewMode link-content-footer IMSCurrentEditorEditObject"" type=""link"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""inner-article"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""ads_detail"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<!-- Composite Start -->", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""attachmentsContainer"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""news-share article-social clearfix"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""tags-wp"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div id=""plhMain_NewsDetail1_divTags"" class=""keysword"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<p style=""text-align: center;""><iframe allowfullscreen="""" frameborder=""0"" height=""400px""", @"~<p style=""text-align: center;""><iframe allowfullscreen="""" frameborder=""0"" height=""400px""");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""related-news"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""tag_detail"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""tag_detail"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""over-dk"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""share_bt"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""w640right"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""link-source-wrapper is-web clearfix fr"" id=""urlSourceCafeF"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<center style=""margin:10px 0px; float:left;width:100%;margin:auto;"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<!-- CAND-detail-338x280 -->", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""dtContentTxtAuthor"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""explus_related_1404022217 explus_related_1404022217_bottom _tlq"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""VCSortableInPreviewMode link-content-footer"" type=""link"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div>Bạn đang đọc bài viết", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<p><strong><span style=""color: rgb(51, 51, 255);"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div data-check-position=""vnb_detail_body_end"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div id=""ContentPlaceHolder1_Detail1_pnTlq"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""social pkg""  style=""margin-top:20px;clear:both"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<h2 class=""related-news-title red-title"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""like_share"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<!--CBV1 -->", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<!-- END .shortcode-content -->", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""related-inline-story clearfix cms-relate"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div itemprop=""publisher"" itemscope", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div itemprop=""publisher"" itemscope", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<span style=""text-decoration:underline;""><strong>Xem thêm:", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""_MB_ITEM_SOURCE_URL"" align=""right"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<i class=""social-sticky-stop""></i>", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""vnnews-ft-post"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""vnnews-ft-post"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""topic"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<p class=""pSource"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""social-btn"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""sharemxhbot"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""article__foot"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""ads-item lh0"" data-zone=""native_1"">", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"Mời quý độc giả theo dõi các chương trình đã phát sóng của Đài Truyền hình Việt Nam", @"~");
                    content = content.Split('~')[0];
                    content = content.Replace(@"<div class=""like-share""><div class=""like"">", @"~");
                    content = content.Split('~')[0];
                }
                content = RemoveHTMLTags(content);
            }
            return content;
        }
     

        public static string SetDomainByURL(string url)
        {
            string domain = url;
            domain = domain.Replace(@"https://", @"");
            domain = domain.Replace(@"http://", @"");
            domain = domain.Split('/')[0];
            domain = domain.Replace(@"www.", @"");
            return domain;
        }
        public static string SetContent(string content)
        {
            content = content.Replace(@"</br>", @"");
            content = content.Replace(@"</a>", @"");
            content = content.Replace(@"<div>", @"");
            content = content.Replace(@"</div>", @"");
            content = content.Replace(@"<p>", @"");
            content = content.Replace(@"</p>", @"");
            content = content.Replace(@"/>", @"");
            content = content.Replace(@"content=""", @"");
            return content;
        }
        public static List<string> SetEmailContact(string content)
        {
            content = content.Replace(@",", @";");
            List<string> list = new List<string>();
            foreach (string contact in content.Split(';'))
            {
                string email = "";
                if (contact.Split('<').Length > 1)
                {
                    email = contact.Split('<')[1];
                    email = email.Replace(@">", @"");

                }
                else
                {
                    email = contact.Trim();
                }
                if (!string.IsNullOrEmpty(email))
                {
                    list.Add(email.Trim());
                }
            }
            return list;
        }
        public static List<string> SetContentByDauChamPhay(string content)
        {
            List<string> list = new List<string>();
            content = content.Replace(@",", @";");
            foreach (string item in content.Split(';'))
            {
                if (!string.IsNullOrEmpty(item))
                {
                    list.Add(item.Trim());
                }
            }
            return list;
        }
        public static string RemoveHTMLTags(string content)
        {
            Regex regex = new Regex("\\<[^\\>]*\\>");
            content = regex.Replace(content, String.Empty);
            content = content.Trim();
            return content;
        }
        public static string ToUpperFirstLetter(string title)
        {
            if (!string.IsNullOrEmpty(title))
            {
                string result = "";
                string[] words = title.Split(' ');
                foreach (string word in words)
                {
                    if (word.Trim() != "")
                    {
                        if (word.Length > 1)
                            result += word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower() + " ";
                        else
                            result += word.ToUpper() + " ";
                    }
                }
                title = result;
            }
            return title;
        }
        public static string SetName(string fileName)
        {
            string fileNameReturn = fileName;
            if (!string.IsNullOrEmpty(fileNameReturn))
            {
                fileNameReturn = fileNameReturn.ToLower();
                fileNameReturn = fileNameReturn.Replace("’", "-");
                fileNameReturn = fileNameReturn.Replace("“", "-");
                fileNameReturn = fileNameReturn.Replace("--", "-");
                fileNameReturn = fileNameReturn.Replace("+", "-");
                fileNameReturn = fileNameReturn.Replace("/", "-");
                fileNameReturn = fileNameReturn.Replace(@"\", "-");
                fileNameReturn = fileNameReturn.Replace(":", "-");
                fileNameReturn = fileNameReturn.Replace(";", "-");
                fileNameReturn = fileNameReturn.Replace("%", "-");
                fileNameReturn = fileNameReturn.Replace("`", "-");
                fileNameReturn = fileNameReturn.Replace("~", "-");
                fileNameReturn = fileNameReturn.Replace("#", "-");
                fileNameReturn = fileNameReturn.Replace("$", "-");
                fileNameReturn = fileNameReturn.Replace("^", "-");
                fileNameReturn = fileNameReturn.Replace("&", "-");
                fileNameReturn = fileNameReturn.Replace("*", "-");
                fileNameReturn = fileNameReturn.Replace("(", "-");
                fileNameReturn = fileNameReturn.Replace(")", "-");
                fileNameReturn = fileNameReturn.Replace("|", "-");
                fileNameReturn = fileNameReturn.Replace("'", "-");
                fileNameReturn = fileNameReturn.Replace(",", "-");
                fileNameReturn = fileNameReturn.Replace(".", "-");
                fileNameReturn = fileNameReturn.Replace("?", "-");
                fileNameReturn = fileNameReturn.Replace("<", "-");
                fileNameReturn = fileNameReturn.Replace(">", "-");
                fileNameReturn = fileNameReturn.Replace("]", "-");
                fileNameReturn = fileNameReturn.Replace("[", "-");
                fileNameReturn = fileNameReturn.Replace(@"""", "-");
                fileNameReturn = fileNameReturn.Replace(@" ", "-");
                fileNameReturn = fileNameReturn.Replace("á", "a");
                fileNameReturn = fileNameReturn.Replace("à", "a");
                fileNameReturn = fileNameReturn.Replace("ả", "a");
                fileNameReturn = fileNameReturn.Replace("ã", "a");
                fileNameReturn = fileNameReturn.Replace("ạ", "a");
                fileNameReturn = fileNameReturn.Replace("ă", "a");
                fileNameReturn = fileNameReturn.Replace("ắ", "a");
                fileNameReturn = fileNameReturn.Replace("ằ", "a");
                fileNameReturn = fileNameReturn.Replace("ẳ", "a");
                fileNameReturn = fileNameReturn.Replace("ẵ", "a");
                fileNameReturn = fileNameReturn.Replace("ặ", "a");
                fileNameReturn = fileNameReturn.Replace("â", "a");
                fileNameReturn = fileNameReturn.Replace("ấ", "a");
                fileNameReturn = fileNameReturn.Replace("ầ", "a");
                fileNameReturn = fileNameReturn.Replace("ẩ", "a");
                fileNameReturn = fileNameReturn.Replace("ẫ", "a");
                fileNameReturn = fileNameReturn.Replace("ậ", "a");
                fileNameReturn = fileNameReturn.Replace("í", "i");
                fileNameReturn = fileNameReturn.Replace("ì", "i");
                fileNameReturn = fileNameReturn.Replace("ỉ", "i");
                fileNameReturn = fileNameReturn.Replace("ĩ", "i");
                fileNameReturn = fileNameReturn.Replace("ị", "i");
                fileNameReturn = fileNameReturn.Replace("ý", "y");
                fileNameReturn = fileNameReturn.Replace("ỳ", "y");
                fileNameReturn = fileNameReturn.Replace("ỷ", "y");
                fileNameReturn = fileNameReturn.Replace("ỹ", "y");
                fileNameReturn = fileNameReturn.Replace("ỵ", "y");
                fileNameReturn = fileNameReturn.Replace("ó", "o");
                fileNameReturn = fileNameReturn.Replace("ò", "o");
                fileNameReturn = fileNameReturn.Replace("ỏ", "o");
                fileNameReturn = fileNameReturn.Replace("õ", "o");
                fileNameReturn = fileNameReturn.Replace("ọ", "o");
                fileNameReturn = fileNameReturn.Replace("ô", "o");
                fileNameReturn = fileNameReturn.Replace("ố", "o");
                fileNameReturn = fileNameReturn.Replace("ồ", "o");
                fileNameReturn = fileNameReturn.Replace("ổ", "o");
                fileNameReturn = fileNameReturn.Replace("ỗ", "o");
                fileNameReturn = fileNameReturn.Replace("ộ", "o");
                fileNameReturn = fileNameReturn.Replace("ơ", "o");
                fileNameReturn = fileNameReturn.Replace("ớ", "o");
                fileNameReturn = fileNameReturn.Replace("ờ", "o");
                fileNameReturn = fileNameReturn.Replace("ở", "o");
                fileNameReturn = fileNameReturn.Replace("ỡ", "o");
                fileNameReturn = fileNameReturn.Replace("ợ", "o");
                fileNameReturn = fileNameReturn.Replace("ú", "u");
                fileNameReturn = fileNameReturn.Replace("ù", "u");
                fileNameReturn = fileNameReturn.Replace("ủ", "u");
                fileNameReturn = fileNameReturn.Replace("ũ", "u");
                fileNameReturn = fileNameReturn.Replace("ụ", "u");
                fileNameReturn = fileNameReturn.Replace("ư", "u");
                fileNameReturn = fileNameReturn.Replace("ứ", "u");
                fileNameReturn = fileNameReturn.Replace("ừ", "u");
                fileNameReturn = fileNameReturn.Replace("ử", "u");
                fileNameReturn = fileNameReturn.Replace("ữ", "u");
                fileNameReturn = fileNameReturn.Replace("ự", "u");
                fileNameReturn = fileNameReturn.Replace("é", "e");
                fileNameReturn = fileNameReturn.Replace("è", "e");
                fileNameReturn = fileNameReturn.Replace("ẻ", "e");
                fileNameReturn = fileNameReturn.Replace("ẽ", "e");
                fileNameReturn = fileNameReturn.Replace("ẹ", "e");
                fileNameReturn = fileNameReturn.Replace("ê", "e");
                fileNameReturn = fileNameReturn.Replace("ế", "e");
                fileNameReturn = fileNameReturn.Replace("ề", "e");
                fileNameReturn = fileNameReturn.Replace("ể", "e");
                fileNameReturn = fileNameReturn.Replace("ễ", "e");
                fileNameReturn = fileNameReturn.Replace("ệ", "e");
                fileNameReturn = fileNameReturn.Replace("đ", "d");
                fileNameReturn = fileNameReturn.Replace("--", "-");
            }
            return fileNameReturn;
        }
       
        //public  void GetURLByURLAndi(Product model, List<ProductProperty> listProductPropertyUrlcode, int RequestUserID)
        //{
        //    model.Urlcode = model.ImageThumbnail;
        //    string html = "";
        //    try
        //    {
        //        WebClient webClient = new WebClient();
        //        webClient.Encoding = System.Text.Encoding.UTF8;
        //        html = webClient.DownloadString(model.ImageThumbnail);
        //        if (html.Contains(@"andi.vn") == true)
        //        {
        //            string html01 = html;
        //            html = html.Replace(@"~", @"A");
        //            model.IsVideo = false;
        //            string content = html;
        //            if (content.Contains(@"onclick=""showVideo('") == true)
        //            {
        //                content = content.Replace(@"onclick=""showVideo('", @"~");
        //                if (content.Split('~').Length > 1)
        //                {
        //                    content = content.Split('~')[1];
        //                    content = content.Replace(@"'", @"~");
        //                    content = content.Split('~')[0];
        //                    model.Image = "http://video.andi.vn/" + content;
        //                    model.IsVideo = true;
        //                }
        //            }
        //            html = html.Replace(@"<div style=""text-align:center;"">", @"~");
        //            if (html.Split('~').Length > 1)
        //            {
        //                html = html.Split('~')[1];
        //                html = html.Replace(@"</div>", @"~");
        //                html = html.Split('~')[0];
        //                html = html.Replace(@"src='", @"~");
        //                html = html.Replace(@"'", @"~");
        //                foreach (string url in html.Split('~'))
        //                {
        //                    if (url.Contains(@"http://") == true)
        //                    {
        //                        ProductProperty productProperty = new ProductProperty();
        //                        productProperty.Guicode = model.Guicode;
        //                        productProperty.Note = url;
        //                        productProperty.ProductId = 0;
        //                        productProperty.Code = Urlcode;
        //                        productProperty.Initialization(InitType.Insert, RequestUserID);
        //                        listProductPropertyUrlcode.Add(productProperty);
        //                    }
        //                }
        //            }
        //        }
        //        else
        //        {
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        string message = e.Message;
        //    }
        //}
        //public static List<LinkItem> LinkFinder(string html, string urlRoot)
        //{
        //    List<LinkItem> list = new List<LinkItem>();
        //    if (!string.IsNullOrEmpty(html))
        //    {
        //        Uri root = new Uri(urlRoot);
        //        string host = root.Host;
        //        string scheme = root.Scheme;
        //        string localPath = root.LocalPath;
        //        MatchCollection m1 = Regex.Matches(html, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);
        //        foreach (Match m in m1)
        //        {
        //            string value = m.Groups[1].Value;
        //            LinkItem i = new LinkItem();
        //            string t = Regex.Replace(value, @"\s*<.*?>\s*", "", RegexOptions.Singleline);
        //            i.Text = t;
        //            Match m2 = Regex.Match(value, @"href=\""(.*?)\""", RegexOptions.Singleline);
        //            if (m2.Success)
        //            {
        //                i.Href = m2.Groups[1].Value;
        //            }
        //            else
        //            {
        //                string url = value.Replace(@"'", @"""");
        //                url = url.Replace(@"href=""", @"~");
        //                if (url.Split('~').Length > 1)
        //                {
        //                    url = url.Split('~')[1];
        //                    url = url.Split('"')[0];
        //                    i.Href = url;
        //                }
        //            }
        //            if ((!string.IsNullOrEmpty(i.Href)) && (!string.IsNullOrEmpty(i.Text)))
        //            {

        //                if ((i.Href.Contains(@"http") == false) && (i.Href.Contains(@"#") == false) && (i.Href.Contains(@";") == false) && (i.Href.Contains(@"(") == false) && (i.Href.Contains(@")") == false) && (i.Href.Contains(@"{") == false) && (i.Href.Contains(@"}") == false) && (i.Href.Contains(@"[") == false) && (i.Href.Contains(@"]") == false))
        //                {
        //                    string firstlyChar = i.Href[0].ToString();
        //                    if (firstlyChar.Contains(@"/") == true)
        //                    {
        //                        i.Href = i.Href.Substring(1, i.Href.Length - 1);
        //                    }
        //                    if (localPath.Contains(@".") == true)
        //                    {
        //                        localPath = localPath.Split('.')[0];
        //                    }
        //                    string localPath001 = "";
        //                    for (int j = 0; j < localPath.Split('/').Length - 1; j++)
        //                    {
        //                        localPath001 = localPath001 + "/" + localPath.Split('/')[j];
        //                    }
        //                    i.Href = host + localPath001 + "/" + i.Href;
        //                    i.Href = i.Href.Replace(@"//", @"/");
        //                    i.Href = scheme + "://" + i.Href;
        //                }
        //                string extension = i.Href.Split('/')[i.Href.Split('/').Length - 1];
        //                if ((i.Href.Contains(@"/tim-kiem") == false) && (i.Href.Contains(@"?tim-kiem") == false) && (i.Href.Contains(@"/tin-lien-quan") == false) && (i.Href.Contains(@"?tin-lien-quan") == false) && (i.Href.Contains(@"?tu-khoa") == false) && (i.Href.Contains(@"/tu-khoa") == false) && (i.Href.Contains(@"?search") == false) && (i.Href.Contains(@"/search") == false) && (i.Href.Contains(@"?tag") == false) && (i.Href.Contains(@"/tag") == false) && (i.Href.Contains(@"/blogs") == false) && (i.Href.Contains(@"/danh-muc") == false) && (i.Href.Contains(@"#") == false) && (i.Href.Contains(@";") == false) && (i.Href.Contains(@"(") == false) && (i.Href.Contains(@")") == false) && (i.Href.Contains(@"{") == false) && (i.Href.Contains(@"}") == false) && (i.Href.Contains(@"[") == false) && (i.Href.Contains(@"]") == false))
        //                {
        //                    string year = DateTime.Now.Year.ToString();
        //                    i.Text = i.Text.Trim();
        //                    if (i.Text.Split(' ').Length > 1)
        //                    {
        //                        if ((i.Text.Length > 10) && (i.Text.Contains("/") == true) && (i.Text.Contains(year) == true))
        //                        {
        //                        }
        //                        else
        //                        {
        //                            try
        //                            {
        //                                int number = int.Parse(i.Text);
        //                            }
        //                            catch
        //                            {
        //                                try
        //                                {
        //                                    DateTime date = DateTime.Parse(i.Text);
        //                                }
        //                                catch
        //                                {
        //                                    try
        //                                    {
        //                                        DateTime date = new DateTime(int.Parse(i.Text.Split('/')[2]), int.Parse(i.Text.Split('/')[1]), int.Parse(i.Text.Split('/')[0]));
        //                                    }
        //                                    catch
        //                                    {
        //                                        if ((i.Text.Contains("{") == false) && (i.Text.Contains("[]") == false) && (i.Text.Contains("' trước") == false) && (i.Text.Contains("h trước") == false))
        //                                        {
        //                                            Uri myUri = new Uri(i.Href);
        //                                            if (myUri.Host == root.Host)
        //                                            {
        //                                                list.Add(i);
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return list;
        //}
        //public static void LinkFinder001(string urlCategory, string urlRoot, bool repeat, List<LinkItem> list)
        //{
        //    try
        //    {
        //        int index = -1;
        //        Uri root = new Uri(urlRoot);
        //        Uri myUri = new Uri(urlRoot);
        //        string html = "";
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlCategory);
        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            Stream receiveStream = response.GetResponseStream();
        //            StreamReader readStream = null;
        //            if (response.CharacterSet == null)
        //            {
        //                readStream = new StreamReader(receiveStream, Encoding.UTF8);
        //            }
        //            else
        //            {
        //                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
        //            }
        //            html = readStream.ReadToEnd();
        //            response.Close();
        //            readStream.Close();
        //        }
        //        List<LinkItem> listCategory = new List<LinkItem>();
        //        if (!string.IsNullOrEmpty(html))
        //        {
        //            index = -1;
        //            MatchCollection m1 = Regex.Matches(html, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);
        //            foreach (Match m in m1)
        //            {
        //                index = index + 1;
        //                string value = m.Groups[1].Value;
        //                LinkItem i = new LinkItem();
        //                Match m2 = Regex.Match(value, @"href=\""(.*?)\""", RegexOptions.Singleline);
        //                if (m2.Success)
        //                {
        //                    i.Href = m2.Groups[1].Value;
        //                }
        //                else
        //                {
        //                    m2 = Regex.Match(value, @"href=\'(.*?)\'", RegexOptions.Singleline);
        //                    if (m2.Success)
        //                    {
        //                        i.Href = m2.Groups[1].Value;
        //                    }
        //                }
        //                if (!string.IsNullOrEmpty(i.Href))
        //                {
        //                    bool checkHref = false;
        //                    try
        //                    {
        //                        myUri = new Uri(i.Href);
        //                        checkHref = true;
        //                    }
        //                    catch (Exception e)
        //                    {
        //                        string mes = e.Message;
        //                        i.Href = root.OriginalString + i.Href;
        //                        try
        //                        {
        //                            myUri = new Uri(i.Href);
        //                            checkHref = true;
        //                        }
        //                        catch (Exception e1)
        //                        {
        //                            string mes1 = e1.Message;
        //                        }
        //                    }
        //                    if (checkHref == true)
        //                    {
        //                        if (myUri.Host == root.Host)
        //                        {
        //                            string rootOriginalString = root.OriginalString + "/";
        //                            if (myUri.OriginalString != rootOriginalString)
        //                            {
        //                                string localPath = myUri.LocalPath;
        //                                if (localPath.Contains(@".") == true)
        //                                {
        //                                    string extension = localPath.Split('.')[1];
        //                                    if ((extension.Contains(@"/") == false) && (extension.Contains(@"#") == false))
        //                                    {
        //                                        Match m3 = Regex.Match(value, @"title=\""(.*?)\""", RegexOptions.Singleline);
        //                                        if (m3.Success)
        //                                        {
        //                                            i.Text = m3.Groups[1].Value;
        //                                        }
        //                                        else
        //                                        {
        //                                            m3 = Regex.Match(value, @"title=\'(.*?)\'", RegexOptions.Singleline);
        //                                            if (m3.Success)
        //                                            {
        //                                                i.Text = m3.Groups[1].Value;
        //                                            }
        //                                        }
        //                                        if (string.IsNullOrEmpty(i.Text))
        //                                        {
        //                                            string t = Regex.Replace(value, @"\s*<.*?>\s*", "", RegexOptions.Singleline);
        //                                            i.Text = t;
        //                                        }
        //                                        if (!string.IsNullOrEmpty(i.Text))
        //                                        {
        //                                            if (i.Text.Split(' ').Length > 4)
        //                                            {
        //                                                checkHref = false;
        //                                                for (int j = 0; j < list.Count; j++)
        //                                                {
        //                                                    if (list[j].Href == i.Href)
        //                                                    {
        //                                                        checkHref = true;
        //                                                        j = list.Count;
        //                                                    }
        //                                                }
        //                                                if (checkHref == false)
        //                                                {
        //                                                    list.Add(i);
        //                                                }
        //                                            }
        //                                            else
        //                                            {
        //                                                if (repeat == true)
        //                                                {
        //                                                    checkHref = false;
        //                                                    for (int j = 0; j < listCategory.Count; j++)
        //                                                    {
        //                                                        if (listCategory[j].Href == i.Href)
        //                                                        {
        //                                                            checkHref = true;
        //                                                            j = listCategory.Count;
        //                                                        }
        //                                                    }
        //                                                    if (checkHref == false)
        //                                                    {
        //                                                        listCategory.Add(i);
        //                                                    }
        //                                                }
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                                else
        //                                {
        //                                    if (repeat == true)
        //                                    {
        //                                        checkHref = false;
        //                                        for (int j = 0; j < listCategory.Count; j++)
        //                                        {
        //                                            if (listCategory[j].Href == i.Href)
        //                                            {
        //                                                checkHref = true;
        //                                                j = listCategory.Count;
        //                                            }
        //                                        }
        //                                        if (checkHref == false)
        //                                        {
        //                                            listCategory.Add(i);
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (repeat == true)
        //        {
        //            foreach (LinkItem item in listCategory)
        //            {
        //                LinkFinder001(item.Href, urlRoot, false, list);
        //            }
        //        }
        //    }
        //    catch (Exception e1)
        //    {
        //        string mes1 = e1.Message;
        //    }
        //}

        //public static string LinkFinder002(string urlCategory, string urlRoot, bool repeat, List<LinkItem> list)
        //{
        //    #region code cũ
        //    try
        //    {
        //        Uri root = new Uri(urlRoot);
        //        Uri myUri = new Uri(urlRoot);
        //        string html = "";
        //        ServicePointManager.SecurityProtocol =
        //                       SecurityProtocolType.Tls |
        //                       SecurityProtocolType.Tls11 |
        //                       SecurityProtocolType.Tls12;
        //        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlCategory);
        //        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            Stream receiveStream = response.GetResponseStream();
        //            StreamReader readStream = null;
        //            if (response.CharacterSet == null)
        //            {
        //                readStream = new StreamReader(receiveStream, Encoding.UTF8);
        //            }
        //            else
        //            {
        //                readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
        //            }
        //            html = readStream.ReadToEnd();
        //            response.Close();
        //            readStream.Close();
        //        }
        //        List<LinkItem> listTrue = new List<LinkItem>();
        //        if (!string.IsNullOrEmpty(html))
        //        {
        //            MatchCollection m1 = Regex.Matches(html, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);
        //            foreach (Match m in m1)
        //            {
        //                string value = m.Groups[1].Value;
        //                LinkItem i = new LinkItem();
        //                Match m2 = Regex.Match(value, @"href=\""(.*?)\""", RegexOptions.Singleline);
        //                if (m2.Success)
        //                {
        //                    i.Href = m2.Groups[1].Value;
        //                }
        //                else
        //                {
        //                    m2 = Regex.Match(value, @"href=\'(.*?)\'", RegexOptions.Singleline);
        //                    if (m2.Success)
        //                    {
        //                        i.Href = m2.Groups[1].Value;
        //                    }
        //                }
        //                if (!string.IsNullOrEmpty(i.Href))
        //                {
        //                    bool checkHref = false;
        //                    try
        //                    {
        //                        myUri = new Uri(i.Href);
        //                        checkHref = true;
        //                    }
        //                    catch (Exception e)
        //                    {
        //                        string mes = e.Message;
        //                        i.Href = root.OriginalString + "/" + i.Href;
        //                        i.Href = i.Href.Replace(@"://", @"~SOHU~");
        //                        i.Href = i.Href.Replace(@"//", @"/");
        //                        i.Href = i.Href.Replace(@"~SOHU~", @"://");
        //                        try
        //                        {
        //                            myUri = new Uri(i.Href);
        //                            checkHref = true;
        //                        }
        //                        catch (Exception e1)
        //                        {
        //                            string mes1 = e1.Message;
        //                        }
        //                    }
        //                    if (checkHref == true)
        //                    {
        //                        if (myUri.Host == root.Host)
        //                        {
        //                            string rootOriginalString = root.OriginalString + "/";
        //                            if (myUri.OriginalString != rootOriginalString)
        //                            {
        //                                string localPath = myUri.LocalPath;
        //                                if (localPath.Contains(@".") == true)
        //                                {
        //                                    string extension = localPath.Split('.')[1];
        //                                    if ((extension.Contains(@"/") == false) || (extension.Contains(@"#") == false))
        //                                    {
        //                                        if (i.Href.Contains(@"#") == true)
        //                                        {

        //                                        }
        //                                        else
        //                                        {
        //                                            checkHref = true;
        //                                            for (int j = 0; j < list.Count; j++)
        //                                            {
        //                                                if (list[j].Href == i.Href)
        //                                                {
        //                                                    checkHref = false;
        //                                                    j = list.Count;
        //                                                }
        //                                            }
        //                                            if (checkHref == true)
        //                                            {
        //                                                list.Add(i);
        //                                                if (repeat == true)
        //                                                {
        //                                                    listTrue.Add(i);
        //                                                }
        //                                            }
        //                                        }
        //                                    }
        //                                }
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        if (repeat == true)
        //        {
        //            foreach (LinkItem item in listTrue)
        //            {
        //                LinkFinder002(item.Href, urlRoot, false, list);
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        string mes = e.Message;
        //    }
        //    return "";
        //    #endregion
        //    //try
        //    //{
        //    //    int index = -1;
        //    //    Uri root = new Uri(urlRoot);
        //    //    Uri myUri = new Uri(urlRoot);
        //    //    string html = "";
        //    //    ServicePointManager.SecurityProtocol =
        //    //                    SecurityProtocolType.Tls |
        //    //                    SecurityProtocolType.Tls11 |
        //    //                    SecurityProtocolType.Tls12;
        //    //    //SecurityProtocolType.Ssl3;
        //    //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlCategory);
        //    //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        //    //    if (response.StatusCode == HttpStatusCode.OK)
        //    //    {
        //    //        Stream receiveStream = response.GetResponseStream();
        //    //        StreamReader readStream = null;


        //    //        if (response.CharacterSet == null)
        //    //        {
        //    //            readStream = new StreamReader(receiveStream, Encoding.UTF8);
        //    //        }
        //    //        else
        //    //        {
        //    //            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

        //    //        }
        //    //        html = readStream.ReadToEnd();
        //    //        response.Close();
        //    //        readStream.Close();
        //    //    }

        //    //    List<LinkItem> listCategory = new List<LinkItem>();
        //    //    if (!string.IsNullOrEmpty(html))
        //    //    {
        //    //        index = -1;

        //    //        MatchCollection m1 = Regex.Matches(html, @"(<a.*?>.*?</a>)", RegexOptions.Singleline);
        //    //        foreach (Match m in m1)
        //    //        {
        //    //            index = index + 1;
        //    //            string value = m.Groups[1].Value;
        //    //            LinkItem i = new LinkItem();
        //    //            Match m2 = Regex.Match(value, @"href=\""(.*?)\""", RegexOptions.Singleline);
        //    //            if (m2.Success)
        //    //            {
        //    //                i.Href = m2.Groups[1].Value;
        //    //            }
        //    //            else
        //    //            {
        //    //                m2 = Regex.Match(value, @"href=\'(.*?)\'", RegexOptions.Singleline);
        //    //                if (m2.Success)
        //    //                {
        //    //                    i.Href = m2.Groups[1].Value;
        //    //                }
        //    //            }
        //    //            if (!string.IsNullOrEmpty(i.Href))
        //    //            {
        //    //                bool checkHref = false;
        //    //                try
        //    //                {
        //    //                    myUri = new Uri(i.Href);
        //    //                    checkHref = true;
        //    //                }
        //    //                catch (Exception e)
        //    //                {
        //    //                    string mes = e.Message;
        //    //                    i.Href = root.OriginalString + i.Href;
        //    //                    try
        //    //                    {
        //    //                        myUri = new Uri(i.Href);
        //    //                        checkHref = true;
        //    //                    }
        //    //                    catch (Exception e1)
        //    //                    {
        //    //                        string mes1 = e1.Message;
        //    //                    }
        //    //                }
        //    //                if (checkHref == true)
        //    //                {
        //    //                    if (myUri.Host == root.Host)
        //    //                    {
        //    //                        string rootOriginalString = root.OriginalString + "/";
        //    //                        if (myUri.OriginalString != rootOriginalString)
        //    //                        {
        //    //                            string localPath = myUri.LocalPath;
        //    //                            if (localPath.Contains(@".") == true)
        //    //                            {
        //    //                                string extension = localPath.Split('.')[1];
        //    //                                if ((extension.Contains(@"/") == false) && (extension.Contains(@"#") == false))
        //    //                                {
        //    //                                    Match m3 = Regex.Match(value, @"title=\""(.*?)\""", RegexOptions.Singleline);
        //    //                                    if (m3.Success)
        //    //                                    {
        //    //                                        i.Text = m3.Groups[1].Value;
        //    //                                    }
        //    //                                    else
        //    //                                    {
        //    //                                        m3 = Regex.Match(value, @"title=\'(.*?)\'", RegexOptions.Singleline);
        //    //                                        if (m3.Success)
        //    //                                        {
        //    //                                            i.Text = m3.Groups[1].Value;
        //    //                                        }
        //    //                                    }
        //    //                                    if (string.IsNullOrEmpty(i.Text))
        //    //                                    {
        //    //                                        string t = Regex.Replace(value, @"\s*<.*?>\s*", "", RegexOptions.Singleline);
        //    //                                        i.Text = t;
        //    //                                    }
        //    //                                    if (!string.IsNullOrEmpty(i.Text))
        //    //                                    {
        //    //                                        if (i.Text.Split(' ').Length > 4)
        //    //                                        {
        //    //                                            checkHref = false;
        //    //                                            for (int j = 0; j < list.Count; j++)
        //    //                                            {
        //    //                                                if (list[j].Href == i.Href)
        //    //                                                {
        //    //                                                    checkHref = true;
        //    //                                                    j = list.Count;
        //    //                                                }
        //    //                                            }
        //    //                                            if (checkHref == false)
        //    //                                            {
        //    //                                                list.Add(i);
        //    //                                            }
        //    //                                        }
        //    //                                        else
        //    //                                        {
        //    //                                            if (repeat == true)
        //    //                                            {
        //    //                                                checkHref = false;
        //    //                                                for (int j = 0; j < listCategory.Count; j++)
        //    //                                                {
        //    //                                                    if (listCategory[j].Href == i.Href)
        //    //                                                    {
        //    //                                                        checkHref = true;
        //    //                                                        j = listCategory.Count;
        //    //                                                    }
        //    //                                                }
        //    //                                                if (checkHref == false)
        //    //                                                {
        //    //                                                    listCategory.Add(i);
        //    //                                                }
        //    //                                            }
        //    //                                        }
        //    //                                    }
        //    //                                }
        //    //                            }
        //    //                            else
        //    //                            {
        //    //                                if (repeat == true)
        //    //                                {
        //    //                                    checkHref = false;
        //    //                                    for (int j = 0; j < listCategory.Count; j++)
        //    //                                    {
        //    //                                        if (listCategory[j].Href == i.Href)
        //    //                                        {
        //    //                                            checkHref = true;
        //    //                                            j = listCategory.Count;
        //    //                                        }
        //    //                                    }
        //    //                                    if (checkHref == false)
        //    //                                    {
        //    //                                        listCategory.Add(i);
        //    //                                    }
        //    //                                }
        //    //                            }
        //    //                        }
        //    //                    }
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //    if (repeat == true)
        //    //    {
        //    //        foreach (LinkItem item in listCategory)
        //    //        {
        //    //            LinkFinder002(item.Href, urlRoot, false, list);
        //    //        }
        //    //    }
        //    //}
        //    //catch (Exception e1)
        //    //{
        //    //    string mes1 = e1.Message;
        //    //}
        //    //return "";
        //}
        
       
        #endregion
    }

}
