using CommSights_Api.Core.Interfaces;
using CommSights_Api.Data.ModelCommSights;
using CommSights_Api.Database;
using CommSights_Api.Database.ModelCommSights;
using CommSights_Api.Library.Helps;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Abstractions.Services
{
    public class ProductPropertyRepositoryService: IProductPropertyRepository
    {
        private readonly CommSightsContext _context;
        private readonly AppGlobal appGlobal;
        public ProductPropertyRepositoryService(CommSightsContext context, AppGlobal appGlobal)
        {
            _context = context;
            this.appGlobal = appGlobal;
        }
        public bool IsExist(string? Code, int? ParentId,int? IndustryId,int? CompanyId)
        =>  _context.ProductProperties.AsNoTracking()
                                    .Any(item => item.ParentId == ParentId
                                                 && item.Code.Equals(Code)
                                                 && item.CompanyId == CompanyId
                                                 && item.IndustryId == IndustryId);
        public async Task<bool> IsExistAsync(string? Code, int? ParentId,int? IndustryId,int? CompanyId)
        => await _context.ProductProperties.AsNoTracking()
                                    .AnyAsync(item => item.ParentId == ParentId
                                                 && item.Code.Equals(Code)
                                                 && item.CompanyId == CompanyId
                                                 && item.IndustryId == IndustryId);

        public async Task<string>  Update_UserCoding_Bydate(DateTime DatePublishBegin, DateTime DatePublishEnd, int IndustryID, int EmplyeeID)
        {
            DatePublishBegin = new DateTime(DatePublishBegin.Year, DatePublishBegin.Month, DatePublishBegin.Day, 0, 0, 0);
            DatePublishEnd = new DateTime(DatePublishEnd.Year, DatePublishEnd.Month, DatePublishEnd.Day, 23, 59, 59);
            SqlParameter[] parameters =
                       {
                new SqlParameter("@DatePublishBegin",DatePublishBegin),
                new SqlParameter("@DatePublishEnd",DatePublishEnd),
                new SqlParameter("@IndustryID",IndustryID),
                 new SqlParameter("@EmployeeID",EmplyeeID),
            };
            return await SQLHelper.ExecuteNonQueryAsync(appGlobal.ConectionString, "Update_UserCoding_Bydate", parameters);
        }
        public async Task<string> Update_UserCoding(DateTime DatePublishBegin, int IndustryID, int EmplyeeID)
        {
            DatePublishBegin = new DateTime(DatePublishBegin.Year, DatePublishBegin.Month, DatePublishBegin.Day, 0, 0, 0);
            SqlParameter[] parameters =

                       {
                new SqlParameter("@DatePublishEnd",DatePublishBegin),
                new SqlParameter("@IndustryID",IndustryID),
                 new SqlParameter("@EmployeeID",EmplyeeID),
            };
            return await SQLHelper.ExecuteNonQueryAsync(appGlobal.ConectionString, "Update_UserCoding", parameters);
        }
    }
}
