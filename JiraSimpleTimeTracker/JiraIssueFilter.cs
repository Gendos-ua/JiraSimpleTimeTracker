using System;

namespace JiraSimpleTimeTracker
{
    class JiraIssueFilter
    {
        public int ID { get; set; }
        public String title { get; set; }
        public String jql { get; set; }
    }
}
