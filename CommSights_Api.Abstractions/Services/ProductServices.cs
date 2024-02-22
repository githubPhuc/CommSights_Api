using CommSights_Api.Data.ModelCommSights;
using CommSights_Api.Database.ModelCommSights;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommSights_Api.Core.Interfaces;

namespace CommSights_Api.Abstractions.Services
{
    public class ProductServices: IProducts
    {
        private readonly CommSightsContext db_;
        public ProductServices(CommSightsContext context)
        {
            db_ = context;
        }
        public IEnumerable<Product> GetProducts()
        {
            try
            {
                return  db_.Products.AsNoTracking().Take(500000);//Phân trang SkipPage
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        public async Task<List<Product>> GetProducts2()
        {
            try
            {
                return await db_.Products.AsNoTracking().ToListAsync();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
