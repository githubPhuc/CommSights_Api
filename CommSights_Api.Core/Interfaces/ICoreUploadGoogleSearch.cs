using CommSights_Api.Database.ModelCommSights;
using CommSights_Api.Database.ModelViews;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Core.Interfaces
{
    public interface ICoreUploadGoogleSearch
    {
        public Task<string> UploadGoogleSearch(IFormFile file, int RequestUserID, int IndustryIDUploadGoogleSearch, bool IsIndustryIDUploadGoogleSearch, bool IsPriority);
        public Task<SplitExcelModelView> SplitExcelFiles(IFormFile file, int RequestUserID, int IndustryIDUploadGoogleSearch);
        public Task<bool> UploadGoogleSearchUpdate(List<ExcelUploadGoogleSearch> file, string fileName, int baiVietUploadId, int RequestUserID, int IndustryIDUploadGoogleSearch, bool IsIndustryIDUploadGoogleSearch, bool IsPriority);
    }
}
