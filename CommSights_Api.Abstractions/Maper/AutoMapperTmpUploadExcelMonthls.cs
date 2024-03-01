using CommSights_Api.Database.ModelCommSights;
using AutoMapper;
using CommSights_Api.Database.ModelViews.QcMonthlyModelView;

namespace CommSights_Api.Abstractions.Maper
{
    public class AutoMapperTmpUploadExcelMonthls:Profile
    {
        public AutoMapperTmpUploadExcelMonthls() => CreateMap<UploadExcelMonthlyModelView, TmpUploadExcelMonthl>();
    }
}
