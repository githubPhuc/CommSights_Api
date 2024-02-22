using CommSights_Api.Core.Interfaces;
using CommSights_Api.Data.ModelCommSights;
using CommSights_Api.Database;
using CommSights_Api.Database.ModelCommSights;
using CommSights_Api.Library.Helps;
using Microsoft.Data.SqlClient;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Abstractions.Services
{
    //public class BaiVietUploadCountRepositoryService : RepositoryService<BaiVietUploadCount>, IBaiVietUploadCountRepository
    //{
    //    private readonly CommSightsContext _context;
    //    private readonly AppGlobal appGlobal;

    //    public BaiVietUploadCountRepositoryService(CommSightsContext context, AppGlobal appGlobal_) : base(context)
    //    {
    //        this._context = context;
    //        this.appGlobal = appGlobal_;
    //    }
    //    public List<BaiVietUpload> GetByDateBeginAndDateEndAndRequestUserIDAndIsFilterToList(DateTime dateBegin, DateTime dateEnd, int RequestUserID, bool isFilter)
    //    {
    //        List<BaiVietUpload> list = new List<BaiVietUpload>();
    //        if (RequestUserID > 0)
    //        {
    //            try
    //            {
    //                dateBegin = new DateTime(dateBegin.Year, dateBegin.Month, dateBegin.Day, 0, 0, 0);
    //                dateEnd = new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, 23, 59, 59);
    //                SqlParameter[] parameters =
    //                {
    //                    new SqlParameter("@DateBegin",dateBegin),
    //                    new SqlParameter("@DateEnd",dateEnd),
    //                    new SqlParameter("@RequestUserID",RequestUserID),
    //                    new SqlParameter("@IsFilter",isFilter),
    //                };
    //                DataTable dt = SQLHelper.Fill(appGlobal.ConectionString, "sp_BaiVietUploadSelectByDateBeginAndDateEndAndRequestUserIDAndIsFilter", parameters);
    //                list = SQLHelper.ToList<BaiVietUpload>(dt);
    //            }
    //            catch (Exception e)
    //            {
    //                string mes = e.Message;
    //            }
    //        }
    //        return list;
    //    }
    //}
}
