using CommSights_Api.Database.ModelCommSights;
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
        public Task<List<TmpUploadExcelMonthly>> GetListTmpUploadExcelMonthly(int pageSize, int pageNumber);
        public Task<string> UpExcelToTmp(IFormFile file);
    }
}
