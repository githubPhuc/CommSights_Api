using CommSights_Api.Database.ModelCommSights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Database.ModelViews.CoreUploadGoogleModelView
{
    public class SplitExcelModelView
    {
        public List<List<ExcelUploadGoogleSearch>> excelUploadGoogleSearches { get; set; }
        public string fileName { get; set; }
        public int baiVietUploadId { get; set; }
    }
}
