using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkWebCore.Models
{
    public class WorkRecords
    {
        public int Id { get; set; }

        public string WorkName { get; set; }

        public int WorkProcss { get; set; }

        public int WorkLevel { get; set; }

        public string WorkMark { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string UserName { get; set; }
    }
}
