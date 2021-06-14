using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ys_j.Models
{
    public class Company
    {
        public string Id { get; set; }
        public string code { get; set; }
        public string name { get; set; }


        //分析數據

        public int jobCount { get; set; }
        public int titleLabelCount { get; set; }
        public int areaCount { get; set; }

        public List<Job> jobs { get; set; }
        public List<GroupByItem> titleLabelStatistics { get; set; }
        public List<GroupByItem> workExpStatistics { get; set; }
        public List<GroupByItem> educationStatistics { get; set; }
        public List<GroupByItem> areaStatistics { get; set; }
        public List<GroupByItem> payInfoStatistics { get; set; }
        public List<GroupByItem> applyRangeInfoStatistics { get; set; }

        
            

        public DateTime date { get; set; }
    }
}
