using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JiraSimpleTimeTracker
{
    class JiraIssueWorkLog
    {
        public int timeSpentSeconds { get; set; }
        //public String timeSpent { get; set; }
        public String started { get; set; }
        public String comment { get; set; } = "";
    }
}
