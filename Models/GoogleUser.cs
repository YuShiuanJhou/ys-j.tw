using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ys_j.Models
{
    public class GoogleUser
    {
        public string Id { get; set; }
        public string uId { get; set; }
        public string fullName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }

        public DateTime date { get; set; }
    }
}
