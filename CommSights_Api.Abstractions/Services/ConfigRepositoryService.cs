using CommSights_Api.Core.Interfaces;
using CommSights_Api.Data.ModelCommSights;
using CommSights_Api.Database.ModelCommSights;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Abstractions.Services
{
    public class ConfigRepositoryService: IConfigRepository
    {
        private readonly CommSightsContext _context;
        public ConfigRepositoryService(CommSightsContext context)
        {
            _context = context;
        }

        public async Task<Config> GetByGroupNameAndCodeAndCodeName(string groupName, string code, string codeName)
        {
            var item = await _context.Set<Config>().SingleOrDefaultAsync(item => item.GroupName.Equals(groupName) && item.Code.Equals(code) && item.CodeName.Equals(codeName));
            if (item == null)
            {
                item = await _context.Set<Config>().FirstOrDefaultAsync(item => item.GroupName.Equals(groupName) && item.Code.Equals(code) && item.Title.Equals(codeName));
            }
            if (item == null)
            {
                item = await _context.Set<Config>().FirstOrDefaultAsync(item => item.GroupName.Equals(groupName) && item.Code.Equals(code) && item.Note.Equals(codeName));
            }
            return item;
        }

        public async Task<Config> GetByGroupNameAndCodeAndCodeNameAsync(string groupName, string code, string codeName)
        {
            var item = await _context.Set<Config>().SingleOrDefaultAsync(item =>item.GroupName.Equals(groupName) 
                                                                                && item.Code.Equals(code) 
                                                                                && (item.CodeName.Equals(codeName) || item.Title.Equals(codeName) || item.Note.Equals(codeName)));
            return item;
        }
    }
}
