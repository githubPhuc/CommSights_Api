using AutoMapper;
using CommSights_Api.Abstractions.Maper;
using CommSights_Api.Core.Interfaces;
using CommSights_Api.Data.ModelCommSights;
using CommSights_Api.Database.ModelCommSights;
using CommSights_Api.Database.ModelViews.QcMonthlyModelView;
using CommSights_Api.Library.Helps;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

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
        public async Task<(List<TmpUploadExcelMonthl> results, int totalPages)> GetListTmpUploadExcelMonthlyWithTotalPages(int pageSize, int pageNumber, string filename, int RequestUserID)
        {
            try
            { 
                var data = db_.TmpUploadExcelMonthls
                    .Where(a => a.Username == RequestUserID && a.FileName == filename).AsNoTracking();
                var totalPages = (int)Math.Ceiling(data.Count() / (double)pageSize);
                var results = await data
                    .OrderBy(p => p.Headline)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return (results, totalPages);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public async Task<List<ListNameFileModelView>> getListNameFile(int RequestUserID)
        {
            try
            {
                var data = db_.TmpUploadExcelMonthls.AsNoTracking().Where(a=>a.Username==RequestUserID).GroupBy(row => new { row.FileName,row.DateCreated })
                    .Select(grp => new ListNameFileModelView
                    {
                        FileName = grp.Key.FileName,
                        DateCreated = (DateTime)grp.Key.DateCreated,
                        Count = grp.ToList().Count()
                    }).ToList(); 

                return data;
            }catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Đọc file excel
        /// </summary>
        /// <param name="file"></param>
        /// <param name="RequestUserID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ExcelMonthlyModelView> UpExcelToTmp(IFormFile file, int RequestUserID)
        {
            try
            {
                if (file == null || file.Length == 0) { throw new Exception("File not exist!!"); }
                else
                {
                    string ExtensionFile = Path.GetExtension(Path.GetFileName(file.FileName));
                    string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                    fileName = RequestUserID.ToString();
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
                                    var dataToInsert = new List<UploadExcelMonthlyModelView>();
                                    DateTime time_ = DateTime.UtcNow.AddHours(7);
                                    for (int row = 2; row <= totalRows; row++)
                                    {
                                        dataToInsert.Add(new UploadExcelMonthlyModelView
                                        {
                                            Username= RequestUserID,
                                            DateCreated= time_,
                                            FileName = fileName,
                                            Source = worksheet.Cells[row, 1].Value?.ToString() ?? "",
                                            Date = worksheet.Cells[row, 2].Value?.ToString() ?? "",
                                            MainCategory = worksheet.Cells[row, 3].Value?.ToString() ?? "",
                                            SubCategory = worksheet.Cells[row, 4].Value?.ToString() ?? "",
                                            Company = worksheet.Cells[row, 5].Value?.ToString() ?? "",
                                            ColorCompany = string.IsNullOrEmpty(worksheet.Cells[row, 5].Value?.ToString() ?? "") ? ColorHelper.ColorOrange : ColorHelper.ColorNone,
                                            CorpCopy = worksheet.Cells[row, 6].Value?.ToString() ?? "",
                                            ColorCorpCopy = string.IsNullOrEmpty(worksheet.Cells[row, 6].Value?.ToString() ?? "") ?ColorHelper.ColorOrange : ColorHelper.ColorNone,
                                            SoeCorp = worksheet.Cells[row, 7].Value?.ToString() ?? "",
                                            ColorSoeCorp= string.IsNullOrEmpty(worksheet.Cells[row, 7].Value?.ToString() ?? "") ? ColorHelper.ColorOrange : ColorHelper.ColorNone,
                                            FeatureCorp = worksheet.Cells[row, 8].Value?.ToString() ?? "",
                                            ColorFeatureCorp = string.IsNullOrEmpty(worksheet.Cells[row, 8].Value?.ToString() ?? "") ? ColorHelper.ColorOrange : ColorHelper.ColorNone,
                                            SentimentCorp = worksheet.Cells[row, 9].Value?.ToString() ?? "",
                                            ColorSentimentCorp = string.IsNullOrEmpty(worksheet.Cells[row, 9].Value?.ToString() ?? "") ? ColorHelper.ColorOrange : ColorHelper.ColorNone,
                                            SegmentProduct = worksheet.Cells[row, 10].Value?.ToString() ?? "",
                                            ProductName = worksheet.Cells[row, 11].Value?.ToString() ?? "",
                                            ColorProductName = string.IsNullOrEmpty(worksheet.Cells[row, 11].Value?.ToString() ?? "") ? ColorHelper.ColorOrange : ColorHelper.ColorNone,
                                            SoeProduct = worksheet.Cells[row, 12].Value?.ToString() ?? "",
                                            ColorSoeProduct = string.IsNullOrEmpty(worksheet.Cells[row, 12].Value?.ToString() ?? "") ? ColorHelper.ColorOrange : ColorHelper.ColorNone,
                                            FeatureProduct = worksheet.Cells[row, 13].Value?.ToString() ?? "",
                                            ColorFeatureProduct = string.IsNullOrEmpty(worksheet.Cells[row, 13].Value?.ToString() ?? "") ? ColorHelper.ColorOrange : ColorHelper.ColorNone,
                                            SentimentProduct = worksheet.Cells[row, 14].Value?.ToString() ?? "",
                                            ColorSentimentProduct = string.IsNullOrEmpty(worksheet.Cells[row, 14].Value?.ToString() ?? "") ? ColorHelper.ColorOrange : ColorHelper.ColorNone,
                                            Headline = worksheet.Cells[row, 15].Value?.ToString() ?? "",
                                            ColorHeadline = string.IsNullOrEmpty(worksheet.Cells[row, 15].Value?.ToString() ?? "") ? ColorHelper.ColorOrange : ColorHelper.ColorNone,
                                            HeadlineHyperLink = worksheet.Cells[row, 15].Hyperlink != null ? worksheet.Cells[row, 15].Hyperlink.AbsoluteUri.Trim() : "",
                                            HeadlineEnglish = worksheet.Cells[row, 16].Value?.ToString() ?? "",
                                            HeadlineEnglishHyperLink = worksheet.Cells[row, 16].Hyperlink != null ? worksheet.Cells[row, 16].Hyperlink.AbsoluteUri.Trim() : "",
                                            Url =  worksheet.Cells[row, 17].Value?.ToString() ?? "",
                                            ColorUrl = string.IsNullOrEmpty(worksheet.Cells[row, 17].Value.ToString()) ? ColorHelper.ColorOrange : ColorHelper.ColorNone,
                                            Page = worksheet.Cells[row, 18].Value?.ToString() ?? "",
                                            Duration = worksheet.Cells[row, 19].Value?.ToString() ?? "",
                                            Journalist = worksheet.Cells[row, 20].Value?.ToString() ?? "",
                                            TierCommSights = worksheet.Cells[row, 21].Value?.ToString() ?? "",
                                            TierCustomer = worksheet.Cells[row, 22].Value?.ToString() ?? "",
                                            SpokePersonName = worksheet.Cells[row, 23].Value?.ToString() ?? "",
                                            SpokePersonTitle = worksheet.Cells[row, 24].Value?.ToString() ?? "",
                                            ToneValue = worksheet.Cells[row, 25].Value?.ToString() ?? "",
                                            HeadlineValue = worksheet.Cells[row, 26].Value?.ToString() ?? "",
                                            SpokePersonValue = worksheet.Cells[row, 27].Value?.ToString() ?? "",
                                            FeatureValue = worksheet.Cells[row, 28].Value?.ToString() ?? "",
                                            TierValue = worksheet.Cells[row, 29].Value?.ToString() ?? "",
                                            PictureValue = worksheet.Cells[row, 30].Value?.ToString() ?? "",
                                            Mps = worksheet.Cells[row, 32].Value?.ToString() ?? "",
                                            RomeCorp = worksheet.Cells[row, 32].Value?.ToString() ?? "",
                                            RomeProduct = worksheet.Cells[row, 33].Value?.ToString() ?? "",
                                            MediaTitle = worksheet.Cells[row, 34].Value?.ToString() ?? "",
                                            MediaType = worksheet.Cells[row, 35].Value?.ToString() ?? "",
                                            Advalue = worksheet.Cells[row, 36].Value?.ToString() ?? "",
                                        });
                                    }
                                    var result = new List<UploadExcelMonthlyModelView>();
                                    result = CoreQc(dataToInsert.OrderBy(item => item.Headline).ToList());
                                    int batchSize = totalRows >= 10000 ? totalRows / (totalRows / 1000) : totalRows >= 1000 ? totalRows / (totalRows / 100) : totalRows >= 100 ? totalRows / (totalRows / 10) : totalRows;
                                    var dataReponse = new ExcelMonthlyModelView()
                                    {
                                        countArr = dataToInsert.Count(),
                                        UploadExcelMonthlyModelVies = result.Select((x, index) => new { Index = index, Value = x })
                                               .GroupBy(x => x.Index / batchSize)
                                               .Select(g => g.Select(x => x.Value).ToList())
                                               .ToList(),
                                        fileName = fileName,
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
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        /// <summary>
        /// Thêm data vào bảng tạm
        /// </summary>
        /// <param name="Arr"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> InsertDataTmp(List<UploadExcelMonthlyModelView> Arr)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperTmpUploadExcelMonthls>());
                IMapper mapper = config.CreateMapper();
                var entityList = mapper.Map<List<TmpUploadExcelMonthl>>(Arr);
                db_.ChangeTracker.AutoDetectChangesEnabled = false;
                await db_.TmpUploadExcelMonthls.AddRangeAsync(entityList);
                await db_.SaveChangesAsync();
                db_.ChangeTracker.AutoDetectChangesEnabled = true;
                return true;
            }catch(Exception ex) { throw new Exception(ex.Message); }
        }


        public async Task<string>UpdateTmp(int id,UpdateTmpExcelMonthlyModelView model)
        {
            try
            {
                var Query = db_.TmpUploadExcelMonthls.Find(id);
                if(Query==null)
                {
                    db_.Entry(Query).CurrentValues.SetValues(model);
                    await db_.SaveChangesAsync();
                }    
                return "The temporary data table was updated successfully";
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }    
        /// <summary>
        /// tìm dòng cùng headline
        /// </summary>
        /// <param name="Arr"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<UploadExcelMonthlyModelView> CoreQc(List<UploadExcelMonthlyModelView> Arr)
        {
            try {
                var data = new List<UploadExcelMonthlyModelView>();
                var Result = new List<UploadExcelMonthlyModelView>();
                for (int i = 0; i < Arr.Count(); i++)
                {
                    data.Add(Arr[i]);
                    if (i == Arr.Count() - 1)
                    {
                        var dataCheck = CheckAllCases(data);
                        if (dataCheck != null)
                            foreach (var item in dataCheck)
                            {
                                Result.Add(item);
                            }
                        data.Clear();
                        continue;
                    }
                    for (int j = i + 1; j <= Arr.Count(); j++)
                    {                         
                        if (j == Arr.Count() || Arr[i].Headline != Arr[j].Headline)
                        {
                            var dataCheck = CheckAllCases(data);
                            if (dataCheck != null)
                                foreach (var item in dataCheck)
                                {

                                    Result.Add(item);
                                }
                            data.Clear();
                            i = j - 1;
                            break;
                        }
                        else
                        {
                            data.Add(Arr[j]);
                        }

                    }
                }
                return Result;

            } catch (Exception ex) { throw new Exception(ex.Message); }
        }

        /// <summary>
        /// Kiểm tra các trường hợp set màu column
        /// </summary>
        /// <param name="Arr"></param>
        /// <returns></returns>

        private List<UploadExcelMonthlyModelView> CheckAllCases(List<UploadExcelMonthlyModelView> Arr)
        {
            if(Arr.Count() > 1)
            {
                var optimizedQuery1 = Arr.GroupBy(row => new { row.Company, row.ProductName })
                    .Select(grp => new
                    {
                        company = grp.Key.Company,
                        product = grp.Key.ProductName,
                        entries = grp.ToList()
                    });
                foreach (var item in optimizedQuery1)
                {
                    var distinctSentiments = item.entries.Select(x => x.SentimentCorp).Distinct().ToList();
                    if (distinctSentiments.Count != 1)
                    {
                        foreach (var entry in item.entries)
                        {
                            entry.ColorSentimentCorp = ColorHelper.ColorRed;
                        }
                    }
                }
                var optimizedQuery2 = Arr.GroupBy(row => new { row.Company, row.Url })
                    .Select(grp => new
                    {
                        company = grp.Key.Company,
                        Url = grp.Key.Url,
                        entries = grp.ToList()
                    });
                foreach (var item in optimizedQuery2)
                {
                    var corpCopyCount = item.entries.Count(v => v.CorpCopy != "");
                    if (item.entries.Count > 1 && corpCopyCount != 1)
                    {
                        foreach (var entry in item.entries)
                        {
                            entry.ColorCorpCopy = ColorHelper.ColorRed;
                        }
                    }
                    else if (corpCopyCount == 0)
                    {
                        foreach (var entry in item.entries)
                        {
                            entry.ColorCorpCopy = ColorHelper.ColorRed;
                        }
                    }
                }
                var optimizedQuery3 = Arr.GroupBy(row => new { row.Company, row.Url })
                    .Select(grp => new
                    {
                        Company = grp.Key.Company,
                        Url = grp.Key.Url,
                        numberCompany = grp.Count(),
                        sumSoeCorp = grp.Where(v => !string.IsNullOrEmpty(v.SoeCorp))
                            .Sum(v => int.TryParse(v.SoeCorp, out int result) ? result : 0)
                    })
                    .Where(item => item.sumSoeCorp > 100);
                foreach (var item in optimizedQuery3)
                {
                    foreach (var entry in Arr.Where(a => a.Company == item.Company && a.Url==item.Url && !string.IsNullOrEmpty(a.SoeCorp)))
                    {
                        entry.ColorSoeCorp = ColorHelper.ColorRed;
                    }
                }
            }
            else
            {
                if (string.IsNullOrEmpty(Arr[0].Headline))
                    Arr[0].ColorHeadline = ColorHelper.ColorOrange;
                if (string.IsNullOrEmpty(Arr[0].Company))
                    Arr[0].ColorCompany = ColorHelper.ColorOrange;
                if (string.IsNullOrEmpty(Arr[0].SentimentCorp))
                    Arr[0].ColorSentimentCorp = ColorHelper.ColorOrange;
                if (string.IsNullOrEmpty(Arr[0].ProductName))
                    Arr[0].ColorProductName = ColorHelper.ColorOrange;
            }
            return Arr;
        }


        /// <summary>
        /// Tách file cắt đầu cuối cùng headline
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="batchSize"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private List<List<UploadExcelMonthlyModelView>> SplitData(List<List<UploadExcelMonthlyModelView>> arr, int batchSize)
        {
            try
            {
                var datalast = new List<UploadExcelMonthlyModelView>();
                if (arr.Count > 1)
                {
                    for (int i = 0; i < arr.Count - 1; i++)
                    {
                        string currentHeadline = arr[i][arr[i].Count - 1].Headline!;

                        if (arr[i + 1] != null && currentHeadline == arr[i + 1][0].Headline)
                        {
                            int j = 0;
                            while (j < arr[i + 1].Count && currentHeadline == arr[i + 1][j].Headline)
                            {
                                datalast.Add(arr[i + 1][j]);
                                arr[i + 1].RemoveAt(j);

                                if (datalast.Count == batchSize)
                                {
                                    arr.Add(datalast);
                                    datalast = new List<UploadExcelMonthlyModelView>();
                                }
                                else
                                {
                                    j++;
                                }
                            }
                            for (int k = arr[i].Count - 1; k >= 0; k--)
                            {
                                if (currentHeadline == arr[i][k].Headline)
                                {
                                    datalast.Add(arr[i][k]);
                                    arr[i].RemoveAt(k);

                                    if (datalast.Count == batchSize)
                                    {
                                        arr.Add(datalast);
                                        datalast = new List<UploadExcelMonthlyModelView>();
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (datalast.Count > 0)
                    {
                        arr.Add(datalast);
                    }
                }
                return arr;
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }


    }
}
