using CommSights_Api.Core.Interfaces;
using CommSights_Api.Data.ModelCommSights;
using CommSights_Api.Database.ModelCommSights;
using CommSights_Api.Database.ModelViews;
using CommSights_Api.Library.Helps;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Abstractions.Services
{
    public class QcMonthlyService: IQcMonthly
    {
        private readonly CommSightsContext db_;
        private readonly AppGlobal appGlobal;
        public QcMonthlyService(CommSightsContext context, AppGlobal appGlobal)
        {
            db_ = context;
            this.appGlobal = appGlobal;
        }
        public async Task<List<TmpUploadExcelMonthly>> GetListTmpUploadExcelMonthly(int pageSize,int pageNumber)
        {
            try
            {
                return await db_.TmpUploadExcelMonthlies.AsNoTracking().OrderBy(p=>p.Headline).Skip((pageNumber - 1)*pageSize).Take(pageSize).ToListAsync();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        public async Task<string> UpExcelToTmp(IFormFile file)
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
                                    var insertedIds = new List<int>();
                                    var dataToInsert = new List<TmpUploadExcelMonthly>();
                                    for (int row = 2; row <= totalRows; row++)
                                    {
                                        dataToInsert.Add(new TmpUploadExcelMonthly
                                        {
                                            Source = worksheet.Cells[row, 1].Value?.ToString() ?? null,
                                            Date = worksheet.Cells[row, 2].Value?.ToString() ?? null,
                                            MainCategory = worksheet.Cells[row, 3].Value?.ToString() ?? null,
                                            SubCategory = worksheet.Cells[row, 4].Value?.ToString() ?? null,
                                            Company = worksheet.Cells[row, 5].Value?.ToString() ?? null,
                                            CorpCopy = worksheet.Cells[row, 6].Value?.ToString() ?? null,
                                            SoeCorp = worksheet.Cells[row, 7].Value?.ToString() ?? null,
                                            FeatureCorp = worksheet.Cells[row, 8].Value?.ToString() ?? null,
                                            SentimentCorp = worksheet.Cells[row, 9].Value?.ToString() ?? null,
                                            SegmentProduct = worksheet.Cells[row, 10].Value?.ToString() ?? null,
                                            ProductName = worksheet.Cells[row, 11].Value?.ToString() ?? null,
                                            SoeProduct = worksheet.Cells[row, 12].Value?.ToString() ?? null,
                                            FeatureProduct = worksheet.Cells[row, 13].Value?.ToString() ?? null,
                                            SentimentProduct = worksheet.Cells[row, 14].Value?.ToString() ?? null,
                                            Headline = worksheet.Cells[row, 15].Value?.ToString() ?? null,
                                            HeadlineHyperLink = worksheet.Cells[row, 15].Hyperlink != null ? worksheet.Cells[row, 15].Hyperlink.AbsoluteUri.Trim() : null,
                                            HeadlineEnglish = worksheet.Cells[row, 16].Value?.ToString() ?? null,
                                            HeadlineEnglishHyperLink = worksheet.Cells[row, 16].Hyperlink != null ? worksheet.Cells[row, 16].Hyperlink.AbsoluteUri.Trim() : null,
                                            Url =  worksheet.Cells[row, 17].Value?.ToString() ?? null,
                                            Page = worksheet.Cells[row, 18].Value?.ToString() ?? null,
                                            Duration = worksheet.Cells[row, 19].Value?.ToString() ?? null,
                                            Journalist = worksheet.Cells[row, 20].Value?.ToString() ?? null,
                                            TierCommSights = worksheet.Cells[row, 21].Value?.ToString() ?? null,
                                            TierCustomer = worksheet.Cells[row, 22].Value?.ToString() ?? null,
                                            SpokePersonName = worksheet.Cells[row, 23].Value?.ToString() ?? null,
                                            SpokePersonTitle = worksheet.Cells[row, 24].Value?.ToString() ?? null,
                                            ToneValue = worksheet.Cells[row, 25].Value?.ToString() ?? null,
                                            HeadlineValue = worksheet.Cells[row, 26].Value?.ToString() ?? null,
                                            SpokePersonValue = worksheet.Cells[row, 27].Value?.ToString() ?? null,
                                            FeatureValue = worksheet.Cells[row, 28].Value?.ToString() ?? null,
                                            TierValue = worksheet.Cells[row, 29].Value?.ToString() ?? null,
                                            PictureValue = worksheet.Cells[row, 30].Value?.ToString() ?? null,
                                            Mps = worksheet.Cells[row, 32].Value?.ToString() ?? null,
                                            RomeCorp = worksheet.Cells[row, 32].Value?.ToString() ?? null,
                                            RomeProduct = worksheet.Cells[row, 33].Value?.ToString() ?? null,
                                            MediaTitle = worksheet.Cells[row, 34].Value?.ToString() ?? null,
                                            MediaType = worksheet.Cells[row, 35].Value?.ToString() ?? null,
                                            Advalue = worksheet.Cells[row, 36].Value?.ToString() ?? null,
                                        });
                                    }
                                    using (var context = new CommSightsContext())
                                    {
                                        context.ChangeTracker.AutoDetectChangesEnabled = false;
                                        await context.TmpUploadExcelMonthlies.AddRangeAsync(dataToInsert);
                                        await context.SaveChangesAsync();
                                        foreach (var item in dataToInsert)
                                        {
                                            insertedIds.Add(item.Id);
                                        }
                                        context.ChangeTracker.AutoDetectChangesEnabled = true;
                                    }
                                    return "Successfully uploaded Excel, total number of rows is "+totalRows;
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
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
