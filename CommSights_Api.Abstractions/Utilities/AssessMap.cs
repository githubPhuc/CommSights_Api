using CommSights_Api.Library.Helps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommSights_Api.Abstractions.Utilities
{
    public class AssessMap
    {
        public Dictionary<string, int> Map { get; set; }
        public AssessMap(AppGlobal appGlobal)
        {
            Map = new Dictionary<string, int>
            {
                { "1", appGlobal.PositiveID },
                { "Tích cực", appGlobal.PositiveID },
                { "Tin tích cực", appGlobal.PositiveID },
                { "Positive", appGlobal.PositiveID },
                { "0", appGlobal.NeutralID },
                { "Tin trung lập", appGlobal.NeutralID },
                { "Trung Lập", appGlobal.NeutralID },
                { "Neutral", appGlobal.NeutralID },
                { "-1", appGlobal.NegativeID },
                { "Tin tiêu cực", appGlobal.NegativeID },
                { "Tiêu Cực", appGlobal.NegativeID },
                { "Negative", appGlobal.NegativeID }
            };
        }
    }
}
