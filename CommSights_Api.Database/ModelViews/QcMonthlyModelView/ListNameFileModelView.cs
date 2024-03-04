using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Database.ModelViews.QcMonthlyModelView
{
    public class ListNameFileModelView
    {
        public string FileName { get; set; }
        public DateTime DateCreated { get; set; }
        public int Count { get; set; }
    }
}
