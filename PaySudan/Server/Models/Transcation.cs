using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySudan.Server.Models
{
    public class Transcation
    {
        public int account_id { get; set; }
        public int recived_id { get; set; }
        public double amount { get; set; }
        public DateTime time { get; set; }
    }
}
