using CommSights_Api.Core.Interfaces;
using CommSights_Api.Data.ModelCommSights;
using CommSights_Api.Database.ModelCommSights;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using OfficeOpenXml;
using CommSights_Api.Library.Helps;
using CommSights_Api.Abstractions.Utilities;
using System.Runtime.InteropServices.ComTypes;
using System;
using CommSights_Api.Database.ModelViews.CoreUploadGoogleModelView;


namespace CommSights_Api.Abstractions.Services
{
    public class CoreUploadGoogleSearchService: ICoreUploadGoogleSearch
    {
        private readonly CommSightsContext db_;
        private readonly AppGlobal appGlobal;
        private readonly IConfigRepository IConfig;
        private readonly IMembershipPermissionRepository IMembership;
        private readonly IProductPropertyRepository _productPropertyRepository;
        public CoreUploadGoogleSearchService (
            CommSightsContext db,
            AppGlobal appGlobal,
            IConfigRepository IConfigRepository,
            IMembershipPermissionRepository iMembership,
            IProductPropertyRepository productPropertyRepository)
        {
            this.db_ = db;
            this.appGlobal = appGlobal;
            this.IConfig = IConfigRepository;
            this.IMembership = iMembership;
            this._productPropertyRepository = productPropertyRepository;
        }
        public async Task<SplitExcelModelView> SplitExcelFiles(IFormFile file, int RequestUserID, int IndustryIDUploadGoogleSearch)
        {
            try
            {
                if (file == null || file.Length == 0) { throw new Exception("File not exist!!"); }
                else
                {
                    string ExtensionFile = Path.GetExtension(Path.GetFileName(file.FileName));
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName = appGlobal.SourceGoogle;
                    fileName = fileName + "-" + AppGlobal.DateTimeCode + ExtensionFile;

                    if ((ExtensionFile == ".xlsx") || (ExtensionFile == ".xls"))
                    {
                        using (var stream = new MemoryStream())
                        {
                            file.CopyTo(stream);
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (var package = new ExcelPackage(stream))
                            {
                                var worksheet = package.Workbook.Worksheets[0];
                                if (worksheet.Dimension == null)
                                {
                                    throw new Exception("The worksheet is empty!!");
                                }
                                else
                                {
                                    int totalRows = worksheet.Dimension.Rows;
                                    var baiVietUploadCount = new BaiVietUploadCount
                                    {
                                        Count = totalRows - 1,
                                        IndustryId = IndustryIDUploadGoogleSearch,
                                        DateCreated = AppGlobal.InitDateTime,
                                        UserCreated = RequestUserID,
                                        DateUpdated = AppGlobal.InitDateTime,
                                        UserUpdated = RequestUserID,
                                        Active = false
                                    };
                                    await db_.BaiVietUploadCounts.AddAsync(baiVietUploadCount);
                                    await db_.SaveChangesAsync();
                                    var dataToInsert = new List<ExcelUploadGoogleSearch>();
                                    for (int row = 2; row <= totalRows; row++)
                                    {
                                        dataToInsert.Add(new ExcelUploadGoogleSearch
                                        {
                                            Date = worksheet.Cells[row, 1].Value?.ToString() ?? null,
                                            Company = worksheet.Cells[row, 2].Value?.ToString() ?? null,
                                            Sentiment = worksheet.Cells[row, 3].Value?.ToString() ?? null,
                                            HeadlineVn = worksheet.Cells[row, 4].Value?.ToString() ?? null,
                                            HeadlineVnhyperlink = worksheet.Cells[row, 4].Hyperlink != null ? worksheet.Cells[row, 4].Hyperlink.AbsoluteUri.Trim() : null,
                                            HeadlineEng = worksheet.Cells[row, 5].Value?.ToString() ?? null,
                                            HeadlineEngHyperlink = worksheet.Cells[row, 5].Hyperlink != null ? worksheet.Cells[row, 5].Hyperlink.AbsoluteUri.Trim() : null,
                                            Url = worksheet.Cells[row, 6].Value?.ToString() ?? null,
                                            SummaryVn = worksheet.Cells[row, 7].Value?.ToString() ?? null,
                                            SummaryEng = worksheet.Cells[row, 8].Value?.ToString() ?? null,
                                            Author = worksheet.Cells[row, 9].Value?.ToString() ?? null,
                                            Segment = worksheet.Cells[row, 10].Value?.ToString() ?? null,
                                            Product = worksheet.Cells[row, 11].Value?.ToString() ?? null
                                        });
                                    }
                                    //using (var context = new CommSightsContext())
                                    //{
                                    //    context.ChangeTracker.AutoDetectChangesEnabled = false;
                                    //    await context.ExcelUploadGoogleSearches.AddRangeAsync(dataToInsert);
                                    //    await context.SaveChangesAsync();
                                    //    context.ChangeTracker.AutoDetectChangesEnabled = true;
                                    //}
                                    int batchSize = totalRows >= 100 ? totalRows / 10 : totalRows;
                                    var dataReponse = new SplitExcelModelView()
                                    {
                                        excelUploadGoogleSearches = dataToInsert.Select((x, index) => new { Index = index, Value = x })
                                                       .GroupBy(x => x.Index / batchSize)
                                                       .Select(g => g.Select(x => x.Value).ToList())
                                                       .ToList(),
                                        fileName = fileName,
                                        baiVietUploadId = baiVietUploadCount.Id,
                                    };


                                    return dataReponse;
                                }
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Not an excel file, please try again!!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<bool> UploadGoogleSearchUpdate(List<ExcelUploadGoogleSearch> file,string fileName,int baiVietUploadId, int RequestUserID, int IndustryIDUploadGoogleSearch, bool IsIndustryIDUploadGoogleSearch, bool IsPriority)
        {
            try
            {
                if(file.Count()>0)
                {
                    //var insertedIds = new List<int>();
                    var dataProduct = db_.Products.AsNoTracking();
                    var dataConfig = db_.Configs.AsNoTracking();
                    var dataMembershipPermission = db_.MembershipPermissions.AsNoTracking();
                    var dataCompany = db_.Memberships.AsNoTracking();
                    var dataproperty = db_.ProductProperties.AsNoTracking();
                    Dictionary<string, int> assessMap = new AssessMap(appGlobal).Map;
                    foreach (var item in file)
                    {
                        try
                        {
                            //insertedIds.Add(item.Id);
                            var model = new Product()
                            {
                                Note = fileName,
                                UserCreated = RequestUserID,
                                DateCreated = AppGlobal.InitDateTime,
                            };
                            string datePublish = "";
                            var cellValue = item.Date;
                            if (cellValue != null)
                            {
                                datePublish = cellValue!.ToString()!.Trim();
                                DateTime parsedDate;
                                if (DateTime.TryParse(datePublish, out parsedDate))
                                {
                                    model.DatePublish = parsedDate;
                                }
                                else
                                {
                                    DateTime DateTimeStandard = new DateTime(1899, 12, 30);
                                    model.DatePublish = DateTimeStandard.AddDays(int.Parse(datePublish));
                                }
                            }
                            if (item.HeadlineVn != null)
                            {
                                model.Title = appGlobal.SetHeadline(item.HeadlineVn!.Trim());
                                if (model.Title.Equals(model.Title.ToUpper()))
                                {
                                    model.Title = AppGlobal.ToUpperFirstLetter(model.Title);
                                }
                                if (item.HeadlineVnhyperlink != null)
                                {
                                    model.Urlcode = item.HeadlineVnhyperlink;
                                }
                            }
                            if (item.HeadlineEng != null)
                            {
                                model.TitleEnglish = item.HeadlineEng;
                                if (model.TitleEnglish.Equals(model.TitleEnglish.ToUpper()))
                                {
                                    model.TitleEnglish = AppGlobal.ToUpperFirstLetter(model.TitleEnglish);
                                }
                                if (item.HeadlineEngHyperlink != null)
                                {
                                    model.Urlcode = item.HeadlineEngHyperlink;
                                }
                            }
                            if (item.Url != null)
                            {
                                model.Urlcode = item.Url!.Trim();
                                if (!model.Urlcode.Contains("https://nghenhinvietnam.vn/"))
                                {
                                    model.Urlcode = model.Urlcode.ToString().Replace("https://", "http://").Replace("http://m.", "http://").Replace("http://www.", "http://").Replace("http://amp.", "http://");
                                }
                            }
                            model.Description = item.SummaryVn != null ? item.SummaryVn!.Trim() : model.Description;
                            model.DescriptionEnglish = item.SummaryEng != null ? item.SummaryEng!.Trim() : model.DescriptionEnglish;
                            model.IsSummary = (model.IsSummary == true) || (item.SummaryEng != null) || (item.SummaryVn != null);
                            model.Author = item.Author != null ? item.Author!.Trim() : model.Author;
                            if (!string.IsNullOrEmpty(model.Urlcode))
                            {
                                var baiVietUpload = new BaiVietUpload()
                                {
                                    ParentId = baiVietUploadId,
                                    Title = model.Title,
                                    Urlcode = model.Urlcode,
                                    UserCreated = RequestUserID,
                                    DateCreated = AppGlobal.InitDateTime,
                                    UserUpdated = RequestUserID,
                                    DateUpdated = AppGlobal.InitDateTime,
                                    Active = false
                                };
                                db_.BaiVietUploads.Add(baiVietUpload);
                                await db_.SaveChangesAsync();
                                var product = await dataProduct.Where(p => p.Urlcode == model.Urlcode).FirstOrDefaultAsync();//lâu
                                if (product == null)
                                {

                                    model.MetaTitle = AppGlobal.SetName(model.Title);
                                    model.Source = appGlobal.SourceGoogle;
                                    model.Guicode = AppGlobal.InitGuiCode;
                                    model.FileName = AppGlobal.SetDomainByURL(model.Urlcode);
                                    var website =await dataConfig.Where(p => p.Code == "Website" && p.GroupName == "CRM" && p.Title == model.FileName).FirstOrDefaultAsync();
                                    if (website == null)
                                    {
                                        website = new Config()
                                        {
                                            GroupName = appGlobal.CRM,
                                            Code = appGlobal.Website,
                                            Title = model.FileName,
                                            Urlfull = model.FileName,
                                            ParentId = appGlobal.ParentId,
                                            Color = appGlobal.AdvertisementValue,
                                            UserCreated = RequestUserID,
                                            DateCreated = AppGlobal.InitDateTime,
                                            UserUpdated = RequestUserID,
                                            DateUpdated = AppGlobal.InitDateTime,
                                            Active = false,
                                        };
                                        db_.Configs.Add(website);
                                        await db_.SaveChangesAsync();
                                    }
                                    model.IsPriority = IsPriority;
                                    model.ParentId = website.Id;
                                    db_.Products.Add(model);
                                    await db_.SaveChangesAsync();
                                    product = model;
                                }
                                if (product.Id > 0)
                                {
                                    if (product.IsPriority == false || product.IsPriority == null)
                                    {
                                        int checkInt = 0;
                                        if (!string.IsNullOrEmpty(model.TitleEnglish))
                                        {
                                            product.TitleEnglish = model.TitleEnglish;
                                            checkInt = checkInt + 1;
                                        }
                                        if (!string.IsNullOrEmpty(model.Description))
                                        {
                                            product.Description = model.Description;
                                            product.IsSummary = model.IsSummary;
                                            checkInt = checkInt + 1;
                                        }
                                        if (!string.IsNullOrEmpty(model.Author))
                                        {
                                            product.Author = model.Author;
                                            checkInt = checkInt + 1;
                                        }
                                        if (checkInt > 0)
                                        {
                                            product.UserUpdated = RequestUserID;
                                            product.DateUpdated = AppGlobal.InitDateTime;
                                            product.Active ??= false;
                                            var existModel = db_.Products.Find(product.Id);
                                            if (existModel != null)
                                            {
                                                db_.Entry(existModel).CurrentValues.SetValues(product);
                                                await db_.SaveChangesAsync();
                                            }
                                        }
                                    }
                                    int membershipPermissionProductID = 0;
                                    int membershipPermissionSegmentID = 0;
                                    if (item.Product != null)
                                    {
                                        string productName = item.Product!.Trim();
                                        var membershipPermission = await dataMembershipPermission.FirstOrDefaultAsync(p => p.ProductName == productName);
                                        if (membershipPermission != null)
                                        {
                                            membershipPermissionProductID = membershipPermission.Id;
                                            membershipPermissionSegmentID = membershipPermission.SegmentId!.Value;
                                        }
                                    }
                                    if (item.Segment != null)
                                    {
                                        string segmentName = item.Segment!.Trim();
                                        var config = await (from p in dataConfig
                                                            where p.Code == "Segment" && p.GroupName == "CRM" && p.CodeName == segmentName
                                                            select p).FirstOrDefaultAsync();
                                        membershipPermissionSegmentID = (config?.Id != null) ? (int)config.Id : membershipPermissionSegmentID;
                                    }
                                    int assessID = appGlobal.AssessID;
                                    #region Cột 3

                                    if (item.Sentiment != null)
                                    {
                                        string assessString = item.Sentiment!.Trim();
                                        if (assessMap.ContainsKey(assessString))
                                        {
                                            assessID = assessMap[assessString];
                                        }
                                        else
                                        {
                                            var assess = await IConfig.GetByGroupNameAndCodeAndCodeNameAsync(appGlobal.CRM, appGlobal.AssessType, assessString);
                                            if (assess == null)
                                            {
                                                assess = new Config()
                                                {
                                                    CodeName = assessString,
                                                    UserCreated = RequestUserID,
                                                    DateCreated = AppGlobal.InitDateTime,
                                                    UserUpdated = RequestUserID,
                                                    DateUpdated = AppGlobal.InitDateTime,
                                                    Active = false,
                                                };
                                                db_.Configs.Add(assess);
                                                await db_.SaveChangesAsync();
                                            }
                                            assessID = assess.Id;
                                        }
                                    }
                                    #endregion

                                    bool isCompany = true;
                                    if (item.Company != null)
                                    {
                                        string companyName = item.Company!.Trim();
                                        if (appGlobal.keywords.Any(keyword => companyName.Contains(keyword)))
                                        {
                                            isCompany = false;
                                        }
                                        else
                                        {
                                            var company = await dataCompany.FirstOrDefaultAsync(item => item.Account.Contains(companyName));

                                            if (IsIndustryIDUploadGoogleSearch)
                                            {
                                                if (_productPropertyRepository.IsExist(appGlobal.Industry, product.Id, IndustryIDUploadGoogleSearch, company.Id)==false)
                                                {
                                                    foreach (var Imem in IMembership.GetByMembershipIDAndCodeToAsNoTracking(company.Id, appGlobal.Industry))
                                                    {
                                                        var productProperty = new ProductProperty()
                                                        {
                                                            ProductId = membershipPermissionProductID,
                                                            SegmentId = membershipPermissionSegmentID,
                                                            ParentId = product.Id,
                                                            Guicode = product.Guicode,
                                                            AssessId = assessID,
                                                            IndustryId = Imem.IndustryId,
                                                            CompanyId = company.Id,
                                                            ArticleTypeId = appGlobal.TinDoanhNghiepID,
                                                            Code = appGlobal.Company,
                                                            IsDaily = true,
                                                            IsSummary = item.SummaryVn != null || item.SummaryEng != null,
                                                            Active = false,
                                                        };
                                                        db_.ProductProperties.Add(productProperty);
                                                        await _productPropertyRepository.Update_UserCoding((DateTime)model.DatePublish!, Convert.ToInt16(Imem.IndustryId), RequestUserID);
                                                    }
                                                    db_.SaveChanges();
                                                }
                                            }
                                            else
                                            {
                                                if (company == null)
                                                {
                                                    isCompany = false;
                                                }
                                                else
                                                {
                                                    if (_productPropertyRepository.IsExist(appGlobal.Company, product.Id, IndustryIDUploadGoogleSearch, company.Id) == false)
                                                    {
                                                        var productProperty = new ProductProperty()
                                                        {
                                                            UserCreated = RequestUserID,
                                                            DateCreated = AppGlobal.InitDateTime,
                                                            UserUpdated = RequestUserID,
                                                            DateUpdated = AppGlobal.InitDateTime,
                                                            ProductId = membershipPermissionProductID,
                                                            SegmentId = membershipPermissionSegmentID,
                                                            ParentId = product.Id,
                                                            Guicode = product.Guicode,
                                                            AssessId = assessID,
                                                            IndustryId = IndustryIDUploadGoogleSearch,
                                                            CompanyId = company.Id,
                                                            ArticleTypeId = appGlobal.TinDoanhNghiepID,
                                                            Code = appGlobal.Company,
                                                            IsDaily = true,
                                                            IsSummary = item.SummaryVn != null || item.SummaryEng != null,
                                                            Active = false,
                                                        };
                                                        db_.ProductProperties.Add(productProperty);
                                                        db_.SaveChanges();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        isCompany = false;
                                    }
                                    if (!isCompany && _productPropertyRepository.IsExist(appGlobal.Industry, product.Id, IndustryIDUploadGoogleSearch, null)==false)
                                    {
                                        var productProperty = new ProductProperty()
                                        {
                                            UserCreated = RequestUserID,
                                            DateCreated = AppGlobal.InitDateTime,
                                            UserUpdated = RequestUserID,
                                            DateUpdated = AppGlobal.InitDateTime,
                                            ProductId = membershipPermissionProductID,
                                            SegmentId = membershipPermissionSegmentID,
                                            ParentId = product.Id,
                                            Guicode = product.Guicode, 
                                            ArticleTypeId = appGlobal.TinNganhID,
                                            AssessId = assessID,
                                            Code = appGlobal.Industry,
                                            IndustryId = IndustryIDUploadGoogleSearch,
                                            IsDaily = true,
                                            IsSummary = item.SummaryVn != null || item.SummaryEng != null,
                                            Active = false
                                        };
                                        db_.ProductProperties.Add(productProperty);
                                        await db_.SaveChangesAsync();
                                    }
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                    //var itemsToRemove = db_.ExcelUploadGoogleSearches.Where(item => insertedIds.Contains(item.Id)).AsNoTracking();
                    //db_.ExcelUploadGoogleSearches.RemoveRange(itemsToRemove);
                    await db_.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new Exception("File not data!!");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<string> UploadGoogleSearch(IFormFile file, int RequestUserID,int IndustryIDUploadGoogleSearch,bool IsIndustryIDUploadGoogleSearch,bool IsPriority)
        {
            try
            {
                if(file == null || file.Length == 0) { throw new Exception("File not exist!!"); }
                else
                {
                    string ExtensionFile = Path.GetExtension(Path.GetFileName(file.FileName));
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName = appGlobal.SourceGoogle;
                    fileName = fileName + "-" + AppGlobal.DateTimeCode + ExtensionFile;

                    if ((ExtensionFile == ".xlsx") || (ExtensionFile == ".xls"))
                    {
                        using (var stream = new MemoryStream())
                        {
                            file.CopyTo(stream);
                            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                            using (var package = new ExcelPackage(stream))
                            {
                                var worksheet = package.Workbook.Worksheets[0];
                                if (worksheet.Dimension == null)
                                {
                                    throw new Exception("The worksheet is empty!!");
                                }
                                else
                                {
                                    int totalRows = worksheet.Dimension.Rows;
                                    var baiVietUploadCount = new BaiVietUploadCount
                                    {
                                        Count = totalRows - 1,
                                        IndustryId = IndustryIDUploadGoogleSearch,
                                        DateCreated = AppGlobal.InitDateTime,
                                        UserCreated = RequestUserID,
                                        DateUpdated = AppGlobal.InitDateTime,
                                        UserUpdated = RequestUserID,
                                        Active = false
                                    };
                                    await db_.BaiVietUploadCounts.AddAsync(baiVietUploadCount);
                                    await db_.SaveChangesAsync();
                                    var dataProduct = db_.Products.AsNoTracking();
                                    var dataConfig = db_.Configs.AsNoTracking();
                                    var dataMembershipPermission = db_.MembershipPermissions.AsNoTracking();
                                    var dataCompany = db_.Memberships.AsNoTracking();
                                    var dataproperty = db_.ProductProperties.AsNoTracking();
                                    Dictionary<string, int> assessMap = new AssessMap(appGlobal).Map;
                                    for (int i = 2; i <= totalRows; i++)
                                    {
                                        try
                                        {
                                            var model = new Product()
                                            {
                                                Note = fileName,
                                                UserCreated = RequestUserID,
                                                DateCreated = AppGlobal.InitDateTime,
                                            };
                                            string datePublish = "";
                                            var cellValue = worksheet.Cells[i, 1].Value;
                                            if (cellValue != null)
                                            {
                                                datePublish = cellValue!.ToString()!.Trim();
                                                DateTime parsedDate;
                                                if (DateTime.TryParse(datePublish, out parsedDate))
                                                {
                                                    model.DatePublish = parsedDate;
                                                }
                                                else
                                                {
                                                    DateTime DateTimeStandard = new DateTime(1899, 12, 30);
                                                    model.DatePublish = DateTimeStandard.AddDays(int.Parse(datePublish));
                                                }
                                            }
                                            if (worksheet.Cells[i, 4].Value != null)
                                            {
                                                model.Title = appGlobal.SetHeadline(worksheet.Cells[i, 4].Value.ToString()!.Trim());
                                                if (model.Title.Equals(model.Title.ToUpper()))
                                                {
                                                    model.Title = AppGlobal.ToUpperFirstLetter(model.Title);
                                                }
                                                if (worksheet.Cells[i, 4].Hyperlink != null)
                                                {
                                                    model.Urlcode = worksheet.Cells[i, 4].Hyperlink.AbsoluteUri.Trim();
                                                }
                                            }
                                            if (worksheet.Cells[i, 5].Value != null)
                                            {
                                                model.TitleEnglish = worksheet.Cells[i, 5].Value.ToString()!.Trim();
                                                if (model.TitleEnglish.Equals(model.TitleEnglish.ToUpper()))
                                                {
                                                    model.TitleEnglish = AppGlobal.ToUpperFirstLetter(model.TitleEnglish);
                                                }
                                                if (worksheet.Cells[i, 5].Hyperlink != null)
                                                {
                                                    model.Urlcode = worksheet.Cells[i, 5].Hyperlink.AbsoluteUri.Trim();
                                                }
                                            }
                                            if (worksheet.Cells[i, 6].Value != null)
                                            {
                                                model.Urlcode = worksheet.Cells[i, 6].Value.ToString()!.Trim();
                                                if (!model.Urlcode.Contains("https://nghenhinvietnam.vn/"))
                                                {
                                                    model.Urlcode = model.Urlcode.ToString().Replace("https://", "http://").Replace("http://m.", "http://").Replace("http://www.", "http://").Replace("http://amp.", "http://");
                                                }
                                            }
                                            model.Description = worksheet.Cells[i, 7].Value != null ? worksheet.Cells[i, 7].Value.ToString()!.Trim() : model.Description;
                                            model.DescriptionEnglish = worksheet.Cells[i, 8].Value != null ? worksheet.Cells[i, 8].Value.ToString()!.Trim() : model.DescriptionEnglish;
                                            model.IsSummary = (model.IsSummary == true) || (worksheet.Cells[i, 8].Value != null) || (worksheet.Cells[i, 7].Value != null);
                                            model.Author = worksheet.Cells[i, 9].Value != null ? worksheet.Cells[i, 9].Value.ToString()!.Trim() : model.Author;
                                            if (!string.IsNullOrEmpty(model.Urlcode))
                                            {
                                                var baiVietUpload = new BaiVietUpload()
                                                {
                                                    ParentId = baiVietUploadCount.Id,
                                                    Title = model.Title,
                                                    Urlcode = model.Urlcode,
                                                    UserCreated = RequestUserID,
                                                    DateCreated = AppGlobal.InitDateTime,
                                                    UserUpdated = RequestUserID,
                                                    DateUpdated = AppGlobal.InitDateTime,
                                                    Active = false
                                                };
                                                db_.BaiVietUploads.Add(baiVietUpload);
                                                await db_.SaveChangesAsync();
                                                var product = await dataProduct.Where(p => p.Urlcode == model.Urlcode).FirstOrDefaultAsync();//lâu
                                                if (product == null)
                                                {

                                                    model.MetaTitle = AppGlobal.SetName(model.Title);
                                                    model.Source = appGlobal.SourceGoogle;
                                                    model.Guicode = AppGlobal.InitGuiCode;
                                                    model.FileName = AppGlobal.SetDomainByURL(model.Urlcode);
                                                    var website =  dataConfig.Where(p => p.Code == "Website" && p.GroupName == "CRM" && p.Title == model.FileName).FirstOrDefault();
                                                    if (website == null)
                                                    {
                                                        website = new Config()
                                                        {
                                                            GroupName = appGlobal.CRM,
                                                            Code = appGlobal.Website,
                                                            Title = model.FileName,
                                                            Urlfull = model.FileName,
                                                            ParentId = appGlobal.ParentId,
                                                            Color = appGlobal.AdvertisementValue,
                                                            UserCreated = RequestUserID,
                                                            DateCreated = AppGlobal.InitDateTime,
                                                            UserUpdated = RequestUserID,
                                                            DateUpdated = AppGlobal.InitDateTime,
                                                            Active = false,
                                                        };
                                                        db_.Configs.Add(website);
                                                        await db_.SaveChangesAsync();
                                                    }
                                                    model.IsPriority = IsPriority;
                                                    model.ParentId = website.Id;
                                                    db_.Products.Add(model);
                                                    await db_.SaveChangesAsync();
                                                    product = model;
                                                }
                                                if (product.Id > 0)
                                                {
                                                    if (product.IsPriority == false || product.IsPriority == null)
                                                    {
                                                        int checkInt = 0;
                                                        if (!string.IsNullOrEmpty(model.TitleEnglish))
                                                        {
                                                            product.TitleEnglish = model.TitleEnglish;
                                                            checkInt = checkInt + 1;
                                                        }
                                                        if (!string.IsNullOrEmpty(model.Description))
                                                        {
                                                            product.Description = model.Description;
                                                            product.IsSummary = model.IsSummary;
                                                            checkInt = checkInt + 1;
                                                        }
                                                        if (!string.IsNullOrEmpty(model.Author))
                                                        {
                                                            product.Author = model.Author;
                                                            checkInt = checkInt + 1;
                                                        }
                                                        if (checkInt > 0)
                                                        {
                                                            product.UserUpdated = RequestUserID;
                                                            product.DateUpdated = AppGlobal.InitDateTime;
                                                            product.Active ??= false;
                                                            var existModel = db_.Products.Find(product.Id);
                                                            if (existModel != null)
                                                            {
                                                                db_.Entry(existModel).CurrentValues.SetValues(product);
                                                                await db_.SaveChangesAsync();
                                                            }
                                                        }
                                                    }
                                                    int membershipPermissionProductID = 0;
                                                    int membershipPermissionSegmentID = 0;
                                                    if (worksheet.Cells[i, 11].Value != null)
                                                    {
                                                        string productName = worksheet.Cells[i, 11].Value.ToString()!.Trim();
                                                        var membershipPermission =await dataMembershipPermission.FirstOrDefaultAsync(p => p.ProductName == productName);
                                                        if (membershipPermission != null)
                                                        {
                                                            membershipPermissionProductID = membershipPermission.Id;
                                                            membershipPermissionSegmentID = membershipPermission.SegmentId!.Value;
                                                        }
                                                    }
                                                    if (worksheet.Cells[i, 10].Value != null) 
                                                    {
                                                        string segmentName = worksheet.Cells[i, 10].Value.ToString()!.Trim();
                                                        var config = await (from p in dataConfig
                                                                       where p.Code == "Segment" && p.GroupName == "CRM" && p.CodeName == segmentName
                                                                       select p).FirstOrDefaultAsync();
                                                        membershipPermissionSegmentID = (config?.Id != null) ? (int)config.Id : membershipPermissionSegmentID;
                                                    }
                                                    int assessID = appGlobal.AssessID;
                                                    #region Cột 3
                                                    
                                                    if (worksheet.Cells[i, 3].Value != null)
                                                    {
                                                        string assessString = worksheet.Cells[i, 3].Value.ToString()!.Trim();
                                                        if (assessMap.ContainsKey(assessString))
                                                        {
                                                            assessID = assessMap[assessString];
                                                        }
                                                        else
                                                        {
                                                            var assess = await IConfig.GetByGroupNameAndCodeAndCodeNameAsync(appGlobal.CRM, appGlobal.AssessType, assessString);
                                                            if (assess == null)
                                                            {
                                                                assess = new Config()
                                                                {
                                                                    CodeName = assessString,
                                                                    UserCreated = RequestUserID,
                                                                    DateCreated = AppGlobal.InitDateTime,
                                                                    UserUpdated = RequestUserID,
                                                                    DateUpdated = AppGlobal.InitDateTime,
                                                                    Active = false,
                                                                };
                                                                db_.Configs.Add(assess);
                                                                db_.SaveChanges();
                                                            }
                                                            assessID = assess.Id;
                                                        }
                                                    }
                                                    #endregion

                                                    bool isCompany = true;
                                                    if (worksheet.Cells[i, 2].Value != null)
                                                    {
                                                        string companyName = worksheet.Cells[i, 2].Value.ToString()!.Trim();
                                                        if ( appGlobal.keywords.Any(keyword => companyName.Contains(keyword)))
                                                        {
                                                            isCompany = false;
                                                        }
                                                        else
                                                        {
                                                            var company = await dataCompany.FirstOrDefaultAsync(item => item.Account.Contains(companyName));

                                                            if (IsIndustryIDUploadGoogleSearch)
                                                            {
                                                                if (!await _productPropertyRepository.IsExistAsync(appGlobal.Industry, product.Id, IndustryIDUploadGoogleSearch, company.Id))
                                                                {
                                                                    foreach (var item in IMembership.GetByMembershipIDAndCodeToAsNoTracking(company.Id, appGlobal.Industry))
                                                                    {
                                                                        var productProperty = new ProductProperty()
                                                                        {
                                                                            ProductId = membershipPermissionProductID,
                                                                            SegmentId = membershipPermissionSegmentID,
                                                                            ParentId = product.Id,
                                                                            Guicode = product.Guicode,
                                                                            AssessId = assessID,
                                                                            IndustryId = item.IndustryId,
                                                                            CompanyId = company.Id,
                                                                            ArticleTypeId = appGlobal.TinDoanhNghiepID,
                                                                            Code = appGlobal.Company,
                                                                            IsDaily = true,
                                                                            IsSummary = worksheet.Cells[i, 7].Value != null || worksheet.Cells[i, 8].Value != null,
                                                                            Active=false,
                                                                        };
                                                                        db_.ProductProperties.Add(productProperty);
                                                                        await _productPropertyRepository.Update_UserCoding((DateTime)model.DatePublish!, Convert.ToInt16(item.IndustryId), RequestUserID);
                                                                    }
                                                                    await db_.SaveChangesAsync();
                                                                } 
                                                            }
                                                            else
                                                            {
                                                                if (company == null)
                                                                {
                                                                    isCompany = false;
                                                                }
                                                                else
                                                                {
                                                                    if (!await _productPropertyRepository.IsExistAsync(appGlobal.Company, product.Id, IndustryIDUploadGoogleSearch, company.Id) == true)
                                                                    {
                                                                        var productProperty = new ProductProperty()
                                                                        {
                                                                            UserCreated = RequestUserID,
                                                                            DateCreated = AppGlobal.InitDateTime,
                                                                            UserUpdated = RequestUserID,
                                                                            DateUpdated = AppGlobal.InitDateTime,
                                                                            ProductId = membershipPermissionProductID,
                                                                            SegmentId = membershipPermissionSegmentID,
                                                                            ParentId = product.Id,
                                                                            Guicode = product.Guicode,
                                                                            AssessId = assessID,
                                                                            IndustryId = IndustryIDUploadGoogleSearch,
                                                                            CompanyId = company.Id,
                                                                            ArticleTypeId = appGlobal.TinDoanhNghiepID,
                                                                            Code = appGlobal.Company,
                                                                            IsDaily = true,
                                                                            IsSummary = worksheet.Cells[i, 7].Value != null || worksheet.Cells[i, 8].Value != null,
                                                                            Active = false,
                                                                        };
                                                                        db_.ProductProperties.Add(productProperty);
                                                                        await db_.SaveChangesAsync();
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        isCompany = false;
                                                    }
                                                    if (!isCompany && !await _productPropertyRepository.IsExistAsync(appGlobal.Industry, product.Id, IndustryIDUploadGoogleSearch, null))
                                                    {
                                                        var productProperty = new ProductProperty()
                                                        {
                                                            UserCreated = RequestUserID,
                                                            DateCreated = AppGlobal.InitDateTime,
                                                            UserUpdated = RequestUserID,
                                                            DateUpdated = AppGlobal.InitDateTime,
                                                            ProductId = membershipPermissionProductID,
                                                            SegmentId = membershipPermissionSegmentID,
                                                            ParentId = product.Id,
                                                            Guicode = product.Guicode,
                                                            ArticleTypeId = appGlobal.TinNganhID,
                                                            AssessId = assessID,
                                                            Code = appGlobal.Industry,
                                                            IndustryId = IndustryIDUploadGoogleSearch,
                                                            IsDaily = true,
                                                            IsSummary = worksheet.Cells[i, 7].Value != null || worksheet.Cells[i, 8].Value != null,
                                                            Active = false
                                                        };
                                                        db_.ProductProperties.Add(productProperty);
                                                        await db_.SaveChangesAsync();
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            throw new Exception(ex.Message);
                                        }
                                    }
                                }
                            }    
                        }
                        return "Thành công";
                    }
                    else
                    {
                        throw new Exception("Not an excel file, please try again!!");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
