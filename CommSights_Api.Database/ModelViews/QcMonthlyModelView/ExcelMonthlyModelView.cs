using CommSights_Api.Database.ModelCommSights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Database.ModelViews.QcMonthlyModelView
{
    public class ExcelMonthlyModelView
    {
        public List<List<UploadExcelMonthlyModelView>> UploadExcelMonthlyModelVies { get; set; }
        public string fileName { get; set; }
    }
}
