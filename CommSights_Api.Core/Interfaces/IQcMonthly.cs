using CommSights_Api.Database.ModelCommSights;
using CommSights_Api.Database.ModelViews.QcMonthlyModelView;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Core.Interfaces
{
    public interface IQcMonthly
    {
        public Task<List<TmpUploadExcelMonthl>> GetListTmpUploadExcelMonthly(int pageSize, int pageNumber);
        public Task<ExcelMonthlyModelView> UpExcelToTmp(IFormFile file, int RequestUserID);
        public Task<List<TmpUploadExcelMonthl>> InsertDataTmp(List<UploadExcelMonthlyModelView> Arr);
        //public Task<List<UploadExcelMonthlyModelView>> CoreQc(List<UploadExcelMonthlyModelView> Arr);
    }
}
