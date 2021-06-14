using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ys_j.Models
{
    public class Job
    {
        public string Id { get; set; }
        public string code { get; set; }
        public string titleLabel { get; set; }
        public string title { get; set; }
        public string area { get; set; }
        public string workExp { get; set; }
        public string education { get; set; }
        public string payInfo { get; set; }
        public string applyRangeInfo { get; set; }
        public DateTime date { get; set; }
    }
}
