using CommSights_Api.Database.ModelCommSights;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Core.Interfaces
{
    public interface IConfigRepository
    {
        public Task<Config> GetByGroupNameAndCodeAndCodeNameAsync(string groupName, string code, string codeName);
        public Task<Config> GetByGroupNameAndCodeAndCodeName(string groupName, string code, string codeName);
    }
}
