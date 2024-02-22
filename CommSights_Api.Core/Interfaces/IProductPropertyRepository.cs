using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Core.Interfaces
{
    public interface IProductPropertyRepository
    {
        public bool IsExist(string? Code, int? ParentId, int? IndustryId, int? CompanyId);
        public Task<bool> IsExistAsync(string? Code, int? ParentId, int? IndustryId, int? CompanyId);
        public Task<string> Update_UserCoding_Bydate(DateTime DatePublishBegin, DateTime DatePublishEnd, int IndustryID, int EmplyeeID);
        public  Task<string> Update_UserCoding(DateTime DatePublishBegin, int IndustryID, int EmplyeeID);
    }
}
